//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.Logging;
using CodeFactory.VisualStudio.Loader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeFactory.VisualStudio.Packager
{
    /// <summary>
    /// Logic to handle discovery and information for libraries needed to package a CodeFactory automation library

    /// </summary>
    public static class LibraryManagement
    {
        /// <summary>
        /// Logger for the class.
        /// </summary>
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(LibraryManager));


        /// <summary>
        /// Loads the assembly data from the target CodeFactory library to be packaged.
        /// </summary>
        /// <param name="filePath">Fully qualified path to the assembly to be packaged.</param>
        /// <returns>The target assembly data or null if the assembly could not be accessed.</returns>
        public static Assembly GetAssemblyInformation(string filePath)
        {
            _logger.DebugEnter();

            Assembly result = null;


            if (string.IsNullOrEmpty(filePath))
            {
                _logger.Information(
                    "No file path was provided for the library, no library information will be loaded.");
                _logger.DebugExit();
                return null;
            }
            try
            {
                if (!File.Exists(filePath))
                {
                    _logger.Information(
                        $"The library file '{filePath}' was not found, no library information will be loaded.");
                    _logger.DebugExit();
                    return null;
                }

                result = Assembly.LoadFrom(filePath);

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
        /// <returns>List of the library command information or an empty list is not commands are loaded.</returns>
        public static List<VsActionConfiguration> GetLibraryActions(this Assembly source)
        {
            _logger.DebugEnter();

            var result = new List<VsActionConfiguration>();

            if (source == null)
            {
                _logger.Information(
                    "No target assembly was provided to load the library commands from. No commands will be returned.");
                _logger.DebugExit();
                return null;
            }

            try
            {
                var publicTypes = source.GetExportedTypes();

                var vsActionType = typeof(IVsCommandInformation);
                IVsActions commands = null;
                ILogger logger = null;
                object[] commandArgs = { logger, commands };
                Type[] constructorArgTypes = { typeof(ILogger), typeof(IVsActions) };
                foreach (var publicType in publicTypes.Where(publicType => publicType.IsClass).Where(publicType => publicType.InheritsInterface(vsActionType)))
                {
                    if (!(Activator.CreateInstance(publicType, commandArgs) is IVsCommandInformation vsAction)) continue;
                    result.Add(new VsActionConfiguration { ActionAssemblyFullName = publicType.AssemblyQualifiedName, Title = vsAction.CommandTitle, VisualStudioActionType = vsAction.CommandType });
                }
            }
            catch (Exception getLibraryActionsError)
            {
                _logger.Error(
                    $"An unhandled exception occurred while loading library commands for assembly '{source.FullName}'",
                    getLibraryActionsError);
                result = new List<VsActionConfiguration>();
            }

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

            if (referenceAssemblies == null) 
            {
                _logger.DebugExit();
                return externalAssemblies;
            }

            foreach (var referenceAssembly in referenceAssemblies)
            {
                try
                {
                    if (referenceAssembly == null) continue;

                    //Validating that the SDK components are being pulled in.
                    var assemblyName = referenceAssembly.Name.Trim();

                    if (PackagerData.IgnoreAssemblies.Any(a => string.Compare(assemblyName, a, StringComparison.InvariantCulture) == 0)) continue;

                    var referenceAssemblyPath = $"{assemblyDirectory}\\{referenceAssembly.Name}.dll";

                    Assembly referenceAssemblyInfo = null;
                    referenceAssemblyInfo = File.Exists(referenceAssemblyPath) ? Assembly.ReflectionOnlyLoadFrom(referenceAssemblyPath) : Assembly.ReflectionOnlyLoad(referenceAssembly.FullName);

                    if (referenceAssemblyInfo == null) continue;

                    var assemblyFilePath = referenceAssemblyInfo.Location;
                    var assemblyStrongName = referenceAssemblyInfo.FullName;
                    var isStoredInGac = referenceAssemblyInfo.GlobalAssemblyCache;


                    if (isStoredInGac)
                    {
                        if (externalAssemblies.Where(e => e.IsStoredInGac).Any(e => string.Compare(e.AssemblyStrongName, assemblyStrongName, StringComparison.InvariantCulture) == 0)) continue;
                    }
                    else 
                    { 
                        if (externalAssemblies.Where(e => !e.IsStoredInGac).Any(e => string.Compare(e.AssemblyFilePath, assemblyFilePath, StringComparison.InvariantCulture) == 0)) continue; 
                    }

                    externalAssemblies.Add(new VsLibraryConfiguration
                    {
                        AssemblyFilePath = !isStoredInGac ?assemblyFilePath :null,
                        AssemblyStrongName = isStoredInGac ?assemblyStrongName :null,
                        IsStoredInGac = isStoredInGac,
                        HasErrors = false,
                        ErrorType = LibraryErrorType.None,
                        ErrorDetails = null
                    });
                    
                    if (!referenceAssemblyInfo.GlobalAssemblyCache)
                    {
                        var childAssemblies = referenceAssemblyInfo.GetExternalDependentLibraries(assemblyDirectory);

                        if (childAssemblies.Any())
                        {
                            foreach (var child in childAssemblies)
                            {
                                if (child.IsStoredInGac)
                                {
                                    if (externalAssemblies.Where(e => e.IsStoredInGac).Any(e => string.Compare(e.AssemblyStrongName, child.AssemblyStrongName, StringComparison.InvariantCulture) == 0)) continue;
                                }
                                else 
                                { 
                                    if (externalAssemblies.Where(e => !e.IsStoredInGac).Any(e => string.Compare(e.AssemblyFilePath, child.AssemblyFilePath, StringComparison.InvariantCulture) == 0)) continue; 
                                }
                            
                                externalAssemblies.Add(child);
                            }
                        }
                    }
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
