//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CodeFactory.Logging;

namespace CodeFactory.VisualStudio.Loader
{

    /// <summary>
    /// Utility class that loads a CFX file libraries into memory and creates instances of all the visual studio actions and makes them available to visual studio for usage.
    /// </summary>
    public static class CodeFactoryConfigurationLoader
    {

        //Logger for the class.
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(CodeFactoryConfigurationLoader));

         /// <summary>
        /// Constant that holds the name of the code factory directory.
        /// </summary>
        public const string CodeFactoryDirectoryName = "CodeFactory";

        /// <summary>
        /// Constant that holds the name of the code factory file extension.
        /// </summary>
        public const string CodeFactoryExtension = ".cfx";

        /// <summary>
        /// Helper method that determines if a code factory extension file is located in the directory. This will return the first CFX file that is located in the directory.
        /// </summary>
        /// <param name="sourceDirectory">The directory to search for the code factory extension file.</param>
        /// <returns>The fully qualified path to the code factory extension file, or null if no file was found. </returns>
        public static string LocateFactoryPackage(string sourceDirectory)
        {
            _logger.DebugEnter();
            if (string.IsNullOrEmpty(sourceDirectory))
            {
                _logger.DebugExit();
                return null;
            }

            
            
            string result = null;
            try
            {
                var directoryData = new DirectoryInfo(sourceDirectory);

                if (!directoryData.Exists)
                {
                    _logger.DebugExit();
                    return null;

                }
             

                var files = directoryData.GetFiles("*.cfx");

                var fileData = files.FirstOrDefault();

                if (fileData != null) result = fileData.FullName;
              
            }
            catch (Exception locateFactoryPackageError)
            {
                _logger.Error("Exception occurred while locating the factory package. See exception for details.",
                    locateFactoryPackageError);
                result = null;
            }

            _logger.DebugExit();
            return result;
        }

        /// <summary>
        /// Helper method that gets the list of all the assembly files that need to copied from the code factory package.
        /// </summary>
        /// <param name="packageDirectory">The target directory all files are to be copied to.</param>
        /// <param name="config">The factory configuration to load the files from.</param>
        /// <returns>List of the assembly and support files to load, or null if a load failure error occurred.</returns>
        public static List<string> GetAssembliesToLoadFromPackage(string packageDirectory, VsFactoryConfiguration config)
        {

            _logger.DebugEnter();
            if (string.IsNullOrEmpty(packageDirectory) | config == null)
            {
                _logger.DebugExit();
                return null;
            }
            
            var result = new List<string>();

            var libraries = new List<VsLibraryConfiguration>();

            try
            {
                if (config.SupportLibraries != null) libraries.AddRange(config.SupportLibraries);
                

                if (config.CodeFactoryLibraries != null) libraries.AddRange(config.CodeFactoryLibraries);
                

                if (!libraries.Any()) return result;
                

                foreach (var library in libraries)
                {
                    if (library == null) continue;

                    if (library.IsStoredInGac) continue;

                    var libraryPath = Path.Combine(packageDirectory, library.AssemblyFilePath.Trim());

                    if (!File.Exists(libraryPath)) result.Add(libraryPath);

                    if (!library.HasDebugInformation) continue;

                    var debugPath = Path.Combine(packageDirectory,$"{Path.GetFileNameWithoutExtension(library.AssemblyFilePath.Trim())}.pdb");

                    if (!File.Exists(debugPath)) result.Add(debugPath);
                }
            }
            catch (Exception getAssembliesToLoadFromPackageError)
            {
                _logger.Error("Unhandled error occurred check exception for details.",
                    getAssembliesToLoadFromPackageError);
                result = null;
            }

            _logger.DebugExit();
            return result;
        }

        /// <summary>
        /// Loads the factory libraries into the running visual studio instance.
        /// </summary>
        /// <param name="config">The code factory configuration to load assemblies from.</param>
        /// <param name="packageDirectory">The directory where the packages are found.</param>
        /// <returns>Data object that holds the status of loaded factory libraries. This will always return an instance of the status.</returns>
        public static LibraryLoadStatus LoadFactoryLibraries(VsFactoryConfiguration config, string packageDirectory)
        {
            _logger.DebugEnter();
            var result = new LibraryLoadStatus();

            if (config == null)
            {
                result.HasErrors = true;
                result.Errors.Add(ConfigurationMessages.LibraryNotLoaded);
                _logger.DebugExit();
                return result;
            }

            if (string.IsNullOrEmpty(packageDirectory))
            {
                result.HasErrors = true;
                result.Errors.Add(ConfigurationMessages.LibraryNotLoaded);
                _logger.DebugExit();
                return result;
            }

            try
            {
                if (!Directory.Exists(packageDirectory))
                {
                    result.HasErrors = true;
                    result.Errors.Add(ConfigurationMessages.LibraryNotLoaded);
                    _logger.DebugExit();
                    return result;
                }

                var libraries = config.CodeFactoryLibraries;

                if (libraries == null)
                {
                    result.HasErrors = true;
                    result.Errors.Add(ConfigurationMessages.LibraryNotLoaded);
                    _logger.DebugExit();
                    return result;
                }

                foreach (var libraryConfiguration in libraries)
                {
                    if (libraryConfiguration == null) continue;

                    Assembly loadedLibrary = null;
                    if (libraryConfiguration.IsStoredInGac)
                    {
                        loadedLibrary = Assembly.Load(libraryConfiguration.AssemblyStrongName);
                    }
                    else
                    {
                        var assemblyPath = Path.Combine(packageDirectory, libraryConfiguration.AssemblyFilePath.Trim());


                        loadedLibrary = Assembly.LoadFrom(assemblyPath);
                    }

                    if (loadedLibrary != null)
                    {
                        SdkSupport.SupportedAssembly(loadedLibrary);
                        continue;
                    }

                    result.HasErrors = true;
                    result.Errors.Add(ConfigurationMessages.LibraryNotLoaded);
                    _logger.DebugExit();
                    return result;
                }
            }
            catch (UnsupportedSdkLibraryException)
            {
                //Throwing to the caller to notify which library could not be loaded due to SDK being out of date.
                throw;
            }
            catch (Exception loadFactoryLibrariesError)
            {
                _logger.Error("Unhandled exception occurred see exception for details.", loadFactoryLibrariesError);
                result.HasErrors = true;
                result.Errors.Add(ConfigurationMessages.LibraryNotLoaded);
            }

            _logger.DebugExit();
            return result;
        }


        /// <summary>
        /// Loads a code factory configuration into memory and returns the target visual studio actions to be used by code factory.
        /// </summary>
        /// <param name="codeFactoryPackageFile">The fully qualified path to the code factory package file.</param>
        /// <param name="unpackDirectory">The fully qualified path to the unpackDirectory for the code factory libraries.</param>
        /// <param name="actions">The implementation of the actions interface to be injected into each created visual studio action.</param>
        /// <returns></returns>
        public static IVsCodeFactoryLoadStatus LoadCodeFactoryConfiguration(string codeFactoryPackageFile, string unpackDirectory, IVsActions actions)
        {
            _logger.DebugEnter();
            var result = new VsCodeFactoryLoadStatus
            {
                IsLoaded = false,
                VisualStudioFactoryActions = new List<IVsCommandInformation>()
            };

            if (string.IsNullOrEmpty(codeFactoryPackageFile))
            {
                result.HasErrors = true;
                result.ErrorMessages.Add(ConfigurationMessages.NoPackageFile);
                _logger.DebugExit();
                return result;
            }

            if (string.IsNullOrEmpty(unpackDirectory))
            {
                result.HasErrors = true;
                result.ErrorMessages.Add(ConfigurationMessages.NoPackageDirectory);
                _logger.DebugExit();
                return result;
            }

            if (actions == null)
            {
                result.HasErrors = true;
                result.ErrorMessages.Add(ConfigurationMessages.NoVisualStudioActions);
            }

            if (!File.Exists(codeFactoryPackageFile))
            {
                result.HasErrors = true;
                result.ErrorMessages.Add(string.Format(ConfigurationMessages.PackageFileNotFound,codeFactoryPackageFile));
                _logger.DebugExit();
                return result;
            }

            if (!Directory.Exists(unpackDirectory))
            {
                result.HasErrors = true;
                result.ErrorMessages.Add(string.Format(ConfigurationMessages.CannotLocatePackageDirectory,unpackDirectory));
                _logger.DebugExit();
                return result;
            }

            try
            {
                var packageResult = ConfigManager.LoadFactoryConfiguration(codeFactoryPackageFile);

                if (packageResult.HasError)
                {
                    result.HasErrors = true;
                    result.ErrorMessages.Add(packageResult.Error);
                    _logger.DebugExit();
                    return result;
                }

                var packageConfig = packageResult.Result;

                if (packageConfig == null)
                {

                    result.HasErrors = true;
                    result.ErrorMessages.Add(ConfigurationMessages.PackageLoadError);
                    _logger.DebugExit();
                    return result;
                }

                var factoryActions = packageConfig.CodeFactoryActions;
                if (factoryActions == null)
                {
                    result.HasErrors = false;
                    result.IsLoaded = true;
                    _logger.DebugExit();
                    return result;
                }

                var packageDirectory = Path.Combine(unpackDirectory, CodeFactoryDirectoryName,
                    packageConfig.Id.ToString());

                bool hasPackageDirectory = Directory.Exists(packageDirectory);

                if (!hasPackageDirectory)
                {
                    var packageDirectoryInfo = Directory.CreateDirectory(packageDirectory);

                    if (!packageDirectoryInfo.Exists)
                    {
                        result.HasErrors = true;
                        result.ErrorMessages.Add(string.Format(ConfigurationMessages.PackageDirectoryCannotBeCreated,
                            Path.GetFileName(codeFactoryPackageFile)));
                        _logger.DebugExit();
                        return result;
                    }
                }

                var assembliesToExtract = GetAssembliesToLoadFromPackage(packageDirectory, packageConfig);

                if (assembliesToExtract == null)
                {
                    result.HasErrors = true;
                    result.ErrorMessages.Add(ConfigurationMessages.PackageLoadError);
                    _logger.DebugExit();
                    return result;
                }

                if (assembliesToExtract.Any())
                {
                    var assemblyExtractResults = ConfigManager.ExtractLibrariesFromPackage(codeFactoryPackageFile,
                        packageDirectory,
                        assembliesToExtract);

                    if (assemblyExtractResults.HasErrors)
                    {

                        result.HasErrors = true;
                        result.ErrorMessages.AddRange(assemblyExtractResults.Errors);
                        _logger.DebugExit();
                        return result;
                    }
                }

                var assemblyLoadResults = LoadFactoryLibraries(packageConfig, packageDirectory);

                if (assemblyLoadResults.HasErrors)
                {
                    result.HasErrors = true;
                    result.ErrorMessages.AddRange(assemblyLoadResults.Errors);
                    _logger.DebugExit();
                    return result;
                }

                var loadedActions = new List<IVsCommandInformation>();

                foreach (var factoryAction in factoryActions)
                {
                    var assemblyPath = factoryAction.ActionAssemblyFullName;
                    if (string.IsNullOrEmpty(assemblyPath))
                    {
                        result.HasErrors = true;
                        result.ErrorMessages.Add(string.Format(ConfigurationMessages.InvalidAssemblyPath,
                            factoryAction.Title));
                        continue;
                    }

                    try
                    {
                        var actionType = Type.GetType(assemblyPath, false);
                        if (actionType == null)
                        {
                            result.HasErrors = true;
                            result.ErrorMessages.Add(string.Format(ConfigurationMessages.InvalidAssemblyPath,
                                factoryAction.Title));
                            continue;
                        }

                        ILogger logger = LogManager.GetLogger(actionType);

                        object[] constructorArgs = {logger,actions};

                        var action =
                            Activator.CreateInstance(actionType, constructorArgs) as IVsCommandInformation;

                        if (action == null)
                        {
                            result.HasErrors = true;
                            result.ErrorMessages.Add(string.Format(ConfigurationMessages.FailedToLoadAction,
                                factoryAction.Title));
                            continue;
                        }
                        loadedActions.Add(action);

                    }
                    catch (Exception actionFailedToLoad)
                    {
                        _logger.Error("Unhandled error occurred see exception for details.", actionFailedToLoad);
                        result.HasErrors = true;
                        result.ErrorMessages.Add(string.Format(ConfigurationMessages.FailedToLoadAction,
                            factoryAction.Title));
                        continue;
                    }

                }

                if (loadedActions.Any())
                {
                    result.IsLoaded = true;
                    result.VisualStudioFactoryActions = loadedActions;
                }

            }
            catch (Exception loadPackageError)
            {
                _logger.Error("An unhandled exception has occurred see the exception for details", loadPackageError);
                result.HasErrors = true;
                result.ErrorMessages.Add(ConfigurationMessages.PackageLoadError);
            }

            return result;
        }
    }
}
