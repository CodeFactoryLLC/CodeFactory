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
    public static class LibraryManager
    {
        /// <summary>
        /// Logger for the class.
        /// </summary>
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(LibraryManager));

        private const string CODE_FACTORY = "CodeFactory";
        private const string CODE_FACTORY_DOT_NET = "CodeFactory.DotNet";
        private const string CODE_FACTORY_LOGGING = "CodeFactory.Logging";
        private const string CODE_FACTORY_VISUAL_STUDIO = "CodeFactory.VisualStudio";
        private const string CODE_FACTORY_FORMATTING_CSHARP = "CodeFactory.Formatting.CSharp";

        /// <summary>
        /// Loads the information about an automation library.
        /// </summary>
        /// <param name="filePath">The fully qualified path to the automation library file to load information from.</param>
        /// <returns>Fully populated automation library information, or null if the library could not be loaded.</returns>
        public static VsAutomationLibrary GetLibraryInformation(string filePath)
        {
            _logger.DebugEnter();

            if (string.IsNullOrEmpty(filePath))
            {
                _logger.Information(
                    "No file path was provided for the library, no library information will be loaded.");
                _logger.DebugExit();
                return null;
            }
           
            var result = new VsAutomationLibrary();

            try
            {
                if (!File.Exists(filePath))
                {
                    _logger.Information(
                        $"The library file '{filePath}' was not found, no library information will be loaded.");
                    _logger.DebugExit();
                    return null;
                }

                var assemblyDirectory = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(assemblyDirectory))
                {
                    _logger.Information(
                        $"The directory path could not be extracted from the library file path of '{filePath}', no library information will be loaded.");
                    _logger.DebugExit();
                    return null;
                }

                var libraryAssembly = Assembly.LoadFrom(filePath);

                result.LibraryActions = libraryAssembly.GetLibraryActions();
                result.SupportLibraries = libraryAssembly.GetExternalDependentLibraries(assemblyDirectory);
                result.LibraryFilePath = filePath;

            }
            catch (Exception getLibraryInformationError)
            {
                _logger.Error(
                    $"The following unhandled exception occurred while loading the library information for '{filePath}'",
                    getLibraryInformationError);
                result = null;
            }

            _logger.DebugExit();
            return result;
        }



        /// <summary>
        /// Extension method that loads all library commands from the current assembly.
        /// </summary>
        /// <param name="source">Source assembly that holds the commands to be loaded.</param>
        /// <returns>List of the library command information or null if the assembly information can't be loaded.</returns>
        public static List<VsActionConfiguration> GetLibraryActions(this Assembly source)
        {
            _logger.DebugEnter();


            if (source == null)
            {
                _logger.Information(
                    "No target assembly was provided to load the library commands from. No commands will be returned.");
                _logger.DebugExit();
                return null;
            }
           
            var result = new List<VsActionConfiguration>();

            try
            {
                var publicTypes = source.GetExportedTypes();

                var vsActionType = typeof(IVsCommandInformation);
                IVsActions commands = null;
                ILogger logger = null;
                object[] commandArgs = {logger,commands};
                Type[] constructorArgTypes = {typeof(ILogger),typeof(IVsActions)};
                foreach (var publicType in publicTypes.Where(publicType => publicType.IsClass).Where(publicType => publicType.InheritsInterface(vsActionType)))
                {

                    //var constructor = publicType.GetConstructor(BindingFlags.Public,null,constructorArgTypes, null);
                    
                    if (!(Activator.CreateInstance(publicType, commandArgs) is IVsCommandInformation vsAction)) continue;
                    result.Add(new VsActionConfiguration{ActionAssemblyFullName = publicType.AssemblyQualifiedName,Title = vsAction.CommandTitle, VisualStudioActionType = vsAction.CommandType});
                }
            }
            catch (Exception getLibraryActionsError)
            {
                _logger.Error(
                    $"An unhandled exception occurred while loading library commands for assembly '{source.FullName}'",
                    getLibraryActionsError);
                result = null;
            }

            if (result == null) return null;
            if (!result.Any()) result = null;

            _logger.DebugExit();
            return result;
        }

        /// <summary>
        /// Static extension method information configuration information about external assemblies used by the source assembly.
        /// </summary>
        /// <param name="source">Source assembly to get external dependencies from.</param>
        /// <param name="assemblyDirectory">The directory in which the external dependent libraries are stored at.</param>
        /// <returns>List of dependent libraries or null if not dependent libraries were found. </returns>
        public static List<VsLibraryConfiguration> GetExternalDependentLibraries(
            this Assembly source, string assemblyDirectory)
        {
            _logger.DebugEnter();

            if (source == null)
            {
                _logger.Information(
                    "The target assembly to load external dependencies from was not provided. No libraries will be loaded.");
                _logger.DebugExit();
                return null;
            }

            var referenceAssemblies = source.GetReferencedAssemblies();

            var externalAssemblies = new List<VsLibraryConfiguration>();



            foreach (var referenceAssembly in referenceAssemblies)
            {
                try
                {
                    if (referenceAssembly == null) continue;

                    //Validating that the SDK components are being pulled in.
                    var assemblyName = referenceAssembly.Name.Trim();
                    if (string.Compare(assemblyName, CODE_FACTORY, StringComparison.InvariantCulture) == 0) continue;
                    if (string.Compare(assemblyName, CODE_FACTORY_DOT_NET, StringComparison.InvariantCulture) == 0) continue;
                    if (string.Compare(assemblyName, CODE_FACTORY_LOGGING, StringComparison.InvariantCulture) == 0) continue;
                    if (string.Compare(assemblyName, CODE_FACTORY_VISUAL_STUDIO, StringComparison.InvariantCulture) == 0) continue;
                    if (string.Compare(assemblyName,CODE_FACTORY_FORMATTING_CSHARP,StringComparison.InvariantCulture) ==0) continue;

                    var referenceAssemblyPath = $"{assemblyDirectory}\\{referenceAssembly.Name}.dll";

                    Assembly referenceAssemblyInfo = null;
                    referenceAssemblyInfo = File.Exists(referenceAssemblyPath) ? Assembly.ReflectionOnlyLoadFrom(referenceAssemblyPath) : Assembly.ReflectionOnlyLoad(referenceAssembly.FullName);

                    

                    if (referenceAssemblyInfo == null) continue;

                    externalAssemblies.Add(new VsLibraryConfiguration
                    {
                        AssemblyFilePath = referenceAssemblyInfo.Location,
                        AssemblyStrongName = referenceAssemblyInfo.FullName,
                        IsStoredInGac = referenceAssemblyInfo.GlobalAssemblyCache,
                        HasErrors = false,
                        ErrorType = LibraryErrorType.None,
                        ErrorDetails = null
                    });

                }
                catch (BadImageFormatException badImageError)
                {
                    _logger.Error("A bad image error occurred while trying to load a dependent assembly.",
                        badImageError);
                    if (referenceAssembly != null)
                    {
                        externalAssemblies.Add(new VsLibraryConfiguration
                        {
                            AssemblyFilePath = referenceAssembly.Name,
                            IsStoredInGac = false,
                            HasErrors = true,
                            ErrorType = LibraryErrorType.InvalidLibrary
                        });
                    }
                }
                catch (FileLoadException fileLoadError)
                {
                    _logger.Error("A file load exception occurred while trying to load a dependent assembly.",
                        fileLoadError);
                    if (referenceAssembly != null)
                    {
                        externalAssemblies.Add(new VsLibraryConfiguration
                        {
                            AssemblyFilePath = referenceAssembly.Name,
                            IsStoredInGac = false,
                            HasErrors = true,
                            ErrorType = LibraryErrorType.AssemblyLoadError
                        });
                    }
                }
                catch (FileNotFoundException fileNotFoundError)
                {
                    _logger.Error("An assembly was not found when trying to load a dependent assembly.",
                        fileNotFoundError);
                    if (referenceAssembly != null)
                    {
                        externalAssemblies.Add(new VsLibraryConfiguration
                        {
                            AssemblyFilePath = referenceAssembly.Name,
                            IsStoredInGac = false,
                            HasErrors = true,
                            ErrorType = LibraryErrorType.FileNotFound
                        });
                    }
                }
                catch (Exception referenceAssemblyLoadError)
                {
                    _logger.Error(
                        "The following unhandled exception occurred while trying to load a dependent assembly.",
                        referenceAssemblyLoadError);
                    if (referenceAssembly != null)
                    {
                        externalAssemblies.Add(new VsLibraryConfiguration
                        {
                            AssemblyFilePath = referenceAssembly.Name,
                            IsStoredInGac = false,
                            HasErrors = true,
                            ErrorType = LibraryErrorType.LoadException,
                            ErrorDetails = referenceAssemblyLoadError.ToString()
                        });
                    }
                }

            }

            if (!externalAssemblies.Any()) externalAssemblies = null;

            _logger.DebugExit();
            return externalAssemblies;
        }
    }
}
