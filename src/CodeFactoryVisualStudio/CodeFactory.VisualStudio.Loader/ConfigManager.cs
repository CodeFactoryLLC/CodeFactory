//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xaml;
using System.IO.Packaging;
using CodeFactory.Logging;
namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    /// Static class that manages the creation and reading of code factory configuration files.
    /// </summary>
    public static class ConfigManager
    {
        //Logger for the class.
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(ConfigManager));

        #region Package Constants

        /// <summary>
        /// Constant that holds the name of the debug version of the config file.
        /// </summary>
        public const string DEBUG_CONFIG_FILE_NAME = "debug.cfConfig";

        /// <summary>
        /// Constant that holds the name of the configuration file to be stored in the configuration package.
        /// </summary>
        public const string PACKAGE_CONFIG_FILE_NAME = "config.cfConfig";

        /// <summary>
        /// Constant that holds the file extension for code factory extension. 
        /// </summary>
        public const string PACKAGE_FILE_EXTENSION = ".cfx";

        /// <summary>
        /// Constant that holds how big the buffer should be for copying data between buffers.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private const int COPY_BUFFER_SIZE = 0x1000;

        /// <summary>
        /// Constant that holds the xml namespace for the package configuration information.
        /// </summary>
        public const string PACKAGE_CONFIG_NAMESPACE =
            "http://schema.codefactory.software/codefactory/v1.0/package/config";

        /// <summary>
        /// Constant that holds the xml namespace for the package libraries information.
        /// </summary>
        public const string PACKAGE_LIBRARIES_NAMESPACE =
            "http://schema.codefactory.software/codefactory/v1.0/package/libraries";

        /// <summary>
        /// Constant that holds the replacement string information for the logical path for configuration data.
        /// </summary>
        public const string PACKAGE_CONFIG_VIRTUAL_FILEPATH = "Config\\{0}";

        /// <summary>
        /// Constant that holds the replacement string information for the logical path for library data.
        /// </summary>
        public const string PACKAGE_LIBRARIES_VIRTUAL_FILEPATH = "Libraries\\{0}";

        #endregion

        #region Create Functionality



        /// <summary>
        /// Static method that loads a automated library's information into a debug configuration.
        /// </summary>
        /// <param name="debugLibraryInfo">The automation library information that is to be loaded for debugging purposes.</param>
        /// <param name="targetDirectory">The target directory that the debug configuration will be created or updated in.</param>
        /// <returns>Boolean flag that determines if the package configuration file was created successfully or not.</returns>
        public static bool PackageDebugConfigurationFile(VsAutomationLibrary debugLibraryInfo, string targetDirectory)
        {
            _logger.DebugEnter();

            if (debugLibraryInfo == null)
            {
                _logger.Information(
                    "No library information was provided cannot load the library into the debug configuration.");
                _logger.DebugExit();
                return false;
            }


            if (string.IsNullOrEmpty(targetDirectory))
            {
                _logger.Information("No target directory was provided. cannot load the package debug configuration");
                _logger.DebugExit();
                return false;
            }


            if (!Directory.Exists(targetDirectory))
            {
                _logger.Information(
                    $"The target directory '{targetDirectory}' does not exist. cannot create package debug configuration");
                _logger.DebugExit();
                return false;
            }
            

            var configPath = Path.Combine(targetDirectory, DEBUG_CONFIG_FILE_NAME);
            try
            {
                if (File.Exists(configPath)) File.Delete(configPath);
               
            }
            catch (Exception deleteConfigFileError)
            {
                _logger.Error(
                    "The following exception occurred while trying to delete the existing code factory configuration file.",
                    deleteConfigFileError);
                var deleteConfigErrorMessage = string.Format(ConfigurationMessages.FailedToDeleteConfigFile,
                                                             DEBUG_CONFIG_FILE_NAME, deleteConfigFileError);

                Console.WriteLine(deleteConfigErrorMessage);
                _logger.DebugExit();
                return false;
            }

            bool result = false;

            try
            {
                var debugLibrary = new List<VsLibraryConfiguration>
                {
                    new VsLibraryConfiguration
                        {
                            AssemblyFilePath = debugLibraryInfo.LibraryFilePath,
                            IsStoredInGac = false
                        }
                };

                var debugConfig = new VsFactoryConfiguration
                {
                    CodeFactoryActions = debugLibraryInfo.LibraryActions,
                    CodeFactoryLibraries = debugLibrary,
                    SupportLibraries = debugLibraryInfo.SupportLibraries,
                    Id = Guid.NewGuid(),
                    Name = "Debug"
                };

                int commandsCount = 0;
                int supportLibraryCount = 0;
                int factoryLibrariesCount = 0;

                if (debugConfig.CodeFactoryActions != null) commandsCount = debugConfig.CodeFactoryActions.Count();
                if (debugConfig.CodeFactoryLibraries != null)
                    factoryLibrariesCount = debugConfig.CodeFactoryLibraries.Count();
                if (debugConfig.SupportLibraries != null) supportLibraryCount = debugConfig.SupportLibraries.Count();

                Console.WriteLine(string.Format(ConfigurationMessages.CreatingConfigurationFile,
                                                           DEBUG_CONFIG_FILE_NAME));
                XamlServices.Save(configPath, debugConfig);

                var successMessage = string.Format(ConfigurationMessages.ConfigurationFileCreatedSuccessfully,
                                                   DEBUG_CONFIG_FILE_NAME, factoryLibrariesCount, supportLibraryCount,
                                                   commandsCount).Replace("\\r", "\r").Replace("\\n", "\n");
                Console.WriteLine(successMessage);
                result = true;
            }
            catch (Exception saveConfigurationError)
            {
                _logger.Error("The follow exception occurred while trying to save the configuration file.",
                    saveConfigurationError);
                Console.WriteLine(string.Format(ConfigurationMessages.FailedToCreateConfigurationFile,
                                                           DEBUG_CONFIG_FILE_NAME, saveConfigurationError));
                result = false;
            }

            _logger.DebugExit();
            return result;
        }



        ///// <summary>
        ///// Static method that creates a package based on a single code factory library provided. The package will automatically be created in the same directory as the library.
        ///// </summary>
        ///// <param name="libraryPath">The fully qualified path to the library that is to have a package created.</param>
        ///// <returns>Boolean flag that determines if the package was created properly.</returns>
        //public static bool CreateDefaultPackage(string libraryPath)
        //{
        //    _logger.DebugEnter();
        //    if (string.IsNullOrEmpty(libraryPath))
        //    {
        //        _logger.Information("No library path was provided, cannot create the default package.");
        //        _logger.DebugExit();
        //        return false;
        //    }

        //    if (!File.Exists(libraryPath))
        //    {
        //        _logger.Information(
        //            $"The library path '{libraryPath}' does not exist. Cannot create the default package.");
        //        _logger.DebugExit();
        //        return false;
        //    }
          
        //    bool result = false;

        //    try
        //    {
        //        var libraryData = LibraryManager.GetLibraryInformation(libraryPath);

        //        if (libraryData == null)
        //        {
        //            _logger.Information(
        //                $"No library data was found for the library '{libraryPath}', cannot create the default package.");
        //            _logger.DebugExit();
        //            return false;
        //        }
              

        //        if (libraryData.SupportLibraries != null)
        //        {
        //            if (libraryData.SupportLibraries.Any(supportLibrary => supportLibrary.HasErrors))
        //            {
        //                _logger.Information(
        //                    "At least one support library had errors cannot create the default package.");
        //                _logger.DebugExit();
        //                return false;
        //            }
        //        }

        //        var assemblyName = Path.GetFileNameWithoutExtension(libraryPath);
        //        var assemblyDirectory = Path.GetDirectoryName(libraryPath);

        //        if (string.IsNullOrEmpty(assemblyName))
        //        {
        //            _logger.Information(
        //                "Could not load the code factory assembly name, cannot create the default package.");
        //            _logger.DebugExit();
        //            return false;
        //        }

        //        if (string.IsNullOrEmpty(assemblyDirectory))
        //        {
        //            _logger.Information(
        //                "No assembly directory was provided for the code factory assembly, cannot create the default package.");
        //            _logger.DebugExit();
        //            return false;
        //        }
               

        //        var factoryConfig = new VsFactoryConfiguration
        //        {
        //            CodeFactoryActions = libraryData.LibraryActions,
        //            SupportLibraries = libraryData.SupportLibraries,
        //            CodeFactoryLibraries =
        //                    new List<VsLibraryConfiguration>
        //                        {
        //                            new VsLibraryConfiguration
        //                                {
        //                                    IsStoredInGac = false,
        //                                    HasErrors = false,
        //                                    AssemblyFilePath = libraryData.LibraryFilePath
        //                                }
        //                        },
        //            Id = Guid.NewGuid(),
        //            Name = assemblyName
        //        };

        //        result = CreateCodeFactoryPackage(factoryConfig, assemblyDirectory, assemblyName);

        //    }
        //    catch (Exception createDefaultPackageError)
        //    {
        //        _logger.Error("The following unhandled exception occurred while trying to create the default package.",
        //            createDefaultPackageError);
        //        result = false;
        //    }

        //    _logger.DebugExit();
        //    return result;
        //}

        /// <summary>
        /// Creates a code factory package that consolidates the needed libraries and configuration for a code factory into one file.
        /// </summary>
        /// <param name="sourceConfiguration">The loaded factory configuration information to be loaded into a package file.</param>
        /// <param name="targetDirectory">The directory the package will be placed in.</param>
        /// <param name="targetPackageName">The file name of the package that will be created. The package extension of cfx will be appended to the package name.</param>
        /// <returns></returns>
        public static bool CreateCodeFactoryPackage(VsFactoryConfiguration sourceConfiguration, string targetDirectory,
                                                    string targetPackageName)
        {
            _logger.DebugEnter();

            if (sourceConfiguration == null)
            {
                _logger.Information(
                    "The factory configuration was not provided cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }

            if (string.IsNullOrEmpty(targetDirectory))
            {
                _logger.Information(
                    "No target directory for the code factory package was provided, cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }
        
            if(string.IsNullOrEmpty(targetPackageName))
            {
                _logger.Information("No package name was provided, cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }

            if (!Directory.Exists(targetDirectory))
            {
                _logger.Information(
                    $"Code factory target directory '{targetDirectory}' does not exist, cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }

            if (sourceConfiguration.CodeFactoryActions == null)
            {
                _logger.Information(
                    "No commands were provided with the factory configuration, cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }
            if (!sourceConfiguration.CodeFactoryActions.Any())
            {
                _logger.Information(
                    "No commands were provided with the factory configuration, cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }

            if (sourceConfiguration.CodeFactoryLibraries == null)
            {
                _logger.Information(
                    "No code factory libraries were provided in the configuration, cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }

            if (!sourceConfiguration.CodeFactoryLibraries.Any())
            {
                _logger.Information(
                    "No code factory libraries were provided in the configuration, cannot create the code factory package.");
                _logger.DebugExit();
                return false;
            }
            bool result = false;

            try
            {
                var targetPackageFilePath = Path.Combine(targetDirectory, $"{targetPackageName}{PACKAGE_FILE_EXTENSION}");

                var targetConfig = new VsFactoryConfiguration
                {
                    Name = targetPackageName,
                    Id = Guid.NewGuid(),
                    CodeFactoryActions = sourceConfiguration.CodeFactoryActions,
                    SdkVersion = sourceConfiguration.SdkVersion
                };

                var packageFileData = new List<VsPackageFileConfig>();
                var targetFactoryLibraries = new List<VsLibraryConfiguration>();
                foreach (var library in sourceConfiguration.CodeFactoryLibraries)
                {
                    if (library == null) continue;
                    if (library.IsStoredInGac)
                    {
                        targetFactoryLibraries.Add(new VsLibraryConfiguration
                        {
                            IsStoredInGac = true,
                            AssemblyStrongName = library.AssemblyStrongName,
                            HasDebugInformation = false,
                            HasErrors = false,
                            ErrorType = LibraryErrorType.None
                        });
                    }
                    else
                    {
                        var packagePathInfo = GetPackagePathInformation(library.AssemblyFilePath);

                        if (packagePathInfo == null)
                        {
                            _logger.Information(
                                "Cannot load the package file path information, cannot create the code factory package.");
                            _logger.DebugExit();
                            return false;
                        }

                        packageFileData.Add(packagePathInfo);

                        targetFactoryLibraries.Add(new VsLibraryConfiguration
                        {
                            IsStoredInGac = false,
                            AssemblyFilePath = packagePathInfo.AssemblyPackagePath,
                            HasDebugInformation = packagePathInfo.HasDebugDatabaseFile,
                            HasErrors = false,
                            ErrorType = LibraryErrorType.None
                        });
                    }
                }

                if (!targetFactoryLibraries.Any())
                {
                    _logger.Information(
                        "No factory libraries were identified, cannot create the code factory package.");
                    return false;
                }

                var targetSupportLibraries = new List<VsLibraryConfiguration>();
                foreach (var library in sourceConfiguration.SupportLibraries)
                {
                    if (library == null) continue;
                    if (library.IsStoredInGac)
                    {
                        targetSupportLibraries.Add(new VsLibraryConfiguration
                        {
                            IsStoredInGac = true,
                            AssemblyStrongName = library.AssemblyStrongName,
                            HasDebugInformation = false,
                            HasErrors = false,
                            ErrorType = LibraryErrorType.None
                        });
                    }
                    else
                    {
                        var packagePathInfo = GetPackagePathInformation(library.AssemblyFilePath);

                        if (packagePathInfo == null)
                        {
                            _logger.Information(
                                "Cannot load the package file path information, cannot create the code factory package.");
                            _logger.DebugExit();
                            return false;
                        }

                        packageFileData.Add(packagePathInfo);

                        targetSupportLibraries.Add(new VsLibraryConfiguration
                        {
                            IsStoredInGac = false,
                            AssemblyFilePath = packagePathInfo.AssemblyPackagePath,
                            HasDebugInformation = packagePathInfo.HasDebugDatabaseFile,
                            HasErrors = false,
                            ErrorType = LibraryErrorType.None
                        });
                    }
                }

                if (!targetSupportLibraries.Any()) targetSupportLibraries = null;

                targetConfig.CodeFactoryLibraries = targetFactoryLibraries;
                targetConfig.SupportLibraries = targetSupportLibraries;

                result = CreatePackageFile(targetConfig, packageFileData, targetPackageFilePath);
            }
            catch (Exception createCodeFactoryPackageError)
            {
                _logger.Error("The following unhandled error occurred while trying to create the code factory package.",
                    createCodeFactoryPackageError);
                result = false;
            }

            _logger.DebugExit();
            return result;
        }

        

        /// <summary>
        /// Static helper method that creates a code factory extension file.  
        /// </summary>
        /// <param name="config">The factory configuration to load into the factory extension file.</param>
        /// <param name="packageFiles">List of the package files to load into the factory extension file.</param>
        /// <param name="packageFilePath">The fully qualified name of the package file to be created.</param>
        /// <returns>Flag that determines if the factory file was created or not.</returns>
        public static bool CreatePackageFile(VsFactoryConfiguration config, List<VsPackageFileConfig> packageFiles,
                                             string packageFilePath)
        {
            _logger.DebugEnter();

            if (config == null)
            {
                _logger.Information("No code factory configuration was provided, cannot create the package file.");
                _logger.DebugExit();
                return false;
            }

            if(string.IsNullOrEmpty(packageFilePath))
            {
                _logger.Information("No file path for the package file was provided, cannot create the package file.");
                _logger.DebugExit();
                return false;
            }

            bool result = false;
            try
            {
                if (File.Exists(packageFilePath)) File.Delete(packageFilePath);

                using (var codeFactoryPackage = Package.Open(packageFilePath, FileMode.Create))
                {
                    var configUri =
                        PackUriHelper.CreatePartUri(
                            new Uri(string.Format(PACKAGE_CONFIG_VIRTUAL_FILEPATH, PACKAGE_CONFIG_FILE_NAME),
                                    UriKind.Relative));

                    var configPackagePart = codeFactoryPackage.CreatePart(configUri,
                                                                          System.Net.Mime.MediaTypeNames.Text.Xml, CompressionOption.Fast);

                    if (configPackagePart == null)
                    {
                        _logger.Information(
                            "Error occurred while creating the internal configuration of the code factory package, cannot create the package file.");
                        _logger.DebugExit();
                        return false;
                    }


                    var packageConfig = XamlServices.Save(config);

                    if (string.IsNullOrEmpty(packageConfig))
                    {
                        _logger.Information(
                            "An error occurred while saving the code factory configuration to the package file, cannot create the package file.");
                        _logger.DebugExit();
                        return false;
                    }
                    var packageConfigBytes = Encoding.UTF8.GetBytes(packageConfig);
                    var configStream = new MemoryStream(packageConfigBytes);

                    var configPartStream = configPackagePart.GetStream();

                    if (!configStream.CopyStreamData(configPartStream))
                    {
                        configPartStream.Dispose();
                        configStream.Dispose();

                        _logger.Information(
                            "An error occurred while saving the configuration content to the code factory package file, cannot create the package file.");
                        _logger.DebugExit();
                        return false;
                    }

                    configPartStream.Dispose();
                    configStream.Dispose();

                    codeFactoryPackage.CreateRelationship(configUri, TargetMode.Internal, PACKAGE_CONFIG_NAMESPACE);

                    var packageFileData = new List<string>();
                    foreach (var packageFileConfig in packageFiles)
                    {
                        packageFileData.Add(packageFileConfig.AssemblyPhysicalPath);
                        if (packageFileConfig.HasDebugDatabaseFile)
                            packageFileData.Add(packageFileConfig.PDBPhysicalPath);
                    }

                    foreach (var packageFile in packageFileData)
                    {
                        var libraryUri = PackUriHelper
                            .CreatePartUri(
                                            new Uri(string.Format(PACKAGE_LIBRARIES_VIRTUAL_FILEPATH, Path.GetFileName(packageFile)),
                                            UriKind.Relative));

                        var libraryPackagePart = codeFactoryPackage.CreatePart(libraryUri,
                                                                          System.Net.Mime.MediaTypeNames.Application.Octet, CompressionOption.Fast);

                        if (libraryPackagePart == null)
                        {
                            _logger.Information(
                                "An error occurred while adding a library to the code factory package, cannot create the code factory package.");
                            _logger.DebugExit();
                            return false;
                        }

                        var libraryFileStream = File.OpenRead(packageFile);

                        var libraryPackageStream = libraryPackagePart.GetStream();

                        if (!libraryFileStream.CopyStreamData(libraryPackageStream))
                        {
                            result = false;
                            libraryFileStream.Dispose();
                            libraryPackageStream.Dispose();
                            break;
                        }

                        libraryFileStream.Dispose();
                        libraryPackageStream.Dispose();

                        codeFactoryPackage.CreateRelationship(libraryUri, TargetMode.Internal, PACKAGE_LIBRARIES_NAMESPACE);

                    }

                }

                result = true;
            }
            catch (Exception createPackageFileError)
            {
                _logger.Error(
                    "An unhandled exception occurred while trying to create the code factory package. See the exception information for details.",
                    createPackageFileError);
                result = false;
            }

            _logger.DebugExit();
            return result;
        }

      

        /// <summary>
        /// Helper method that gets the path to the PDB file if it exists.
        /// </summary>
        /// <param name="filePath">The file path to the hosting assembly. </param>
        /// <returns>Configuration on library to be loaded into a package.</returns>
        private static VsPackageFileConfig GetPackagePathInformation(string filePath)
        {
            _logger.DebugEnter();

            if (string.IsNullOrEmpty(filePath))
            {
                _logger.Information(
                    "No file path was provided to the library. Cannot find the PDB information for the library.");
                _logger.DebugExit();
                return null;
            }
            if (!File.Exists(filePath))
            {
                _logger.Information(
                    $"The library '{filePath}' could not be found. Cannot find the PDB information for the library.");
                _logger.DebugExit();
                return null;
            }

            var result = new VsPackageFileConfig
            {
                AssemblyPhysicalPath = filePath,
                AssemblyPackagePath = Path.GetFileName(filePath)
            };

            try
            {
                var directoryPath = Path.GetDirectoryName(filePath);
                var fileName = Path.GetFileNameWithoutExtension(filePath);

                if (!string.IsNullOrEmpty(directoryPath) & !string.IsNullOrEmpty(fileName))
                {
                    var pdbPath = Path.Combine(directoryPath, $"{fileName}.pdb");

                    if (!string.IsNullOrEmpty(pdbPath))
                    {
                        if (File.Exists(pdbPath))
                        {
                            result.HasDebugDatabaseFile = true;
                            result.PDBPhysicalPath = pdbPath;
                            result.PDBPackagePath = Path.GetFileName(pdbPath);
                        }
                    }
                }
            }
            catch (Exception getPackageInformationError)
            {
                _logger.Error(
                    "The following unhandled exception occurred while trying to read the PDB information about the library.",
                    getPackageInformationError);
                result = null;
            }

            _logger.DebugExit();
            return result;
        }



        /// <summary>
        /// Extension method that copies data from one stream to another.
        /// </summary>
        /// <param name="source">Source stream to read from.</param>
        /// <param name="targetStream">Target stream to write data to.</param>
        /// <returns>Flag that determines if the stream copy completed successfully.</returns>
        public static bool CopyStreamData(this Stream source, Stream targetStream)
        {
            _logger.DebugEnter();

            bool result = false;

            if (source == null)
            {
                _logger.Information("No source stream to be copied was provided, no stream copy can be completed.");
                _logger.DebugExit();
                return false;
            }

            if(targetStream == null)
            {
                _logger.Information("No target stream to be copied to was provided, no stream copy can be completed.");
                _logger.DebugExit();
                return false;
            }

            try
            {
                var copyBuffer = new byte[COPY_BUFFER_SIZE];

                int bytesRead = 0;

                while ((bytesRead = source.Read(copyBuffer, 0, COPY_BUFFER_SIZE)) > 0)
                {
                    targetStream.Write(copyBuffer, 0, bytesRead);
                }

                result = true;
            }
            catch (Exception copyStreamDataError)
            {
                _logger.Error("The following unhandled error occurred while trying to copy the stream.",
                    copyStreamDataError);
                result = false;
            }
            

            _logger.DebugExit();
            return result;
        }

        #endregion

        #region Read Functionality

        /// <summary>
        /// Loads the factory configuration from the package. 
        /// </summary>
        /// <param name="packageFilePath">The fully qualified path to the Code Factory package.</param>
        /// <returns>Package read result with either the error that occurred or the fully loaded factory configuration. </returns>
        public static PackageReadResult<VsFactoryConfiguration> LoadFactoryConfiguration(string packageFilePath)
        {
            _logger.DebugEnter();

            var result = new PackageReadResult<VsFactoryConfiguration> { HasError = false };

            if (string.IsNullOrEmpty(packageFilePath))
            {
                _logger.Information("No package file was provided, cannot load the factory configuration.");
                result.HasError = true;
                result.Error = ConfigurationMessages.ConfigurationFileNotProvided;
                _logger.DebugExit();
                return result;
            }

            try
            {
                if (!File.Exists(packageFilePath))
                {
                    _logger.Information(
                        $"The package file '{packageFilePath}' was not found, cannot load the factory configuration.");
                    result.HasError = true;
                    result.Error = string.Format(ConfigurationMessages.PackageFileNotFound,
                                                 Path.GetFileName(packageFilePath));
                    _logger.DebugExit();
                    return result;
                }

                var configUri =
                    PackUriHelper.CreatePartUri(
                        new Uri(string.Format(PACKAGE_CONFIG_VIRTUAL_FILEPATH, PACKAGE_CONFIG_FILE_NAME),
                                UriKind.Relative));

                using (var codeFactoryPackage = Package.Open(packageFilePath, FileMode.Open))
                {

                    Stream configStream = null;
                    VsFactoryConfiguration resultData = null;
                    try
                    {
                        if (!codeFactoryPackage.PartExists(configUri))
                        {
                            result.HasError = true;
                            result.Error = string.Format(ConfigurationMessages.ConfigNotInPackage,
                                                         Path.GetFileName(packageFilePath));
                        }
                        else
                        {
                            var configPart = codeFactoryPackage.GetPart(configUri);

                            configStream = configPart.GetStream();
                            resultData = XamlServices.Load(configStream) as VsFactoryConfiguration;
                        }
                    }
                    catch (InvalidOperationException partNotFoundError)
                    {
                        _logger.Error(
                            "The follow exception occurred while loading part of the code factory configuration.",
                            partNotFoundError);
                        result.HasError = true;
                        result.Error = string.Format(ConfigurationMessages.ConfigNotInPackage,
                                                     Path.GetFileName(packageFilePath));
                    }

                    finally
                    {
                        configStream?.Dispose();
                    }

                    if (result.HasError) return result;

                    if (resultData != null)
                    {
                        result.Result = resultData;
                    }
                    else
                    {
                        result.HasError = true;
                        result.Error = string.Format(ConfigurationMessages.FactoryConfigCouldNotBeloaded,
                                                     Path.GetFileName(packageFilePath));
                    }


                }

            }
            catch (Exception loadFactoryConfigurationError)
            {
                _logger.Error("The following unhandled exception occurred while loading the code factory configuration",
                    loadFactoryConfigurationError);

            }

            _logger.DebugExit();
            return result;
        }



        /// <summary>
        /// Extracts a library file from the package and writes it to the target directory and library name.
        /// </summary>
        /// <param name="packageFilePath">The fully qualified file path for the code factory package.</param>
        /// <param name="targetDirectory">The directory the library should be copied to. </param>
        /// <param name="libraries">List of the files to be extracted to the target directory.</param>
        /// <returns>The results of the extract are always returned.</returns>
        public static VsPackageExtractResult ExtractLibrariesFromPackage(string packageFilePath, string targetDirectory, List<string> libraries)
        {
            _logger.DebugEnter();
            var result = new VsPackageExtractResult();

            if (string.IsNullOrEmpty(packageFilePath))
            {
                _logger.Information(
                    "The path to the package file was not provided, cannot extract the libraries from the package.");
                result.HasErrors = true;
                result.Errors.Add(ConfigurationMessages.NoPackageFile);
                _logger.DebugExit();
                return result;
            }
            if (string.IsNullOrEmpty(targetDirectory))
            {
                _logger.Information(
                    $"The target directory for where to extract libraries to was not provided, cannot extract the libraries from the package.");
                result.HasErrors = true;
                result.Errors.Add(ConfigurationMessages.NoLibraryDirectory);
                _logger.DebugExit();
                return result;
            }

            if (libraries == null)
            {
                _logger.Information("No libraries were provided, will not extract any libraries.");
                result.HasErrors = false;
                _logger.DebugExit();
                return result;
            }

            try
            {
                if (!File.Exists(packageFilePath))
                {
                    _logger.Information(
                        $"The package file '{packageFilePath}' does not exist. cannot extract the libraries from the package.");
                    result.HasErrors = true;
                    result.Errors.Add(string.Format(ConfigurationMessages.PackageFileNotFound,
                                                    Path.GetFileName(packageFilePath)));
                    _logger.DebugExit();
                    return result;
                }

                if (!Directory.Exists(targetDirectory))
                {
                    _logger.Information(
                        $"The target directory '{targetDirectory}' does not exist, cannot extract the libraries from the package.");
                    result.HasErrors = true;
                    result.Errors.Add(string.Format(ConfigurationMessages.PackageDirectoryDoesNotExist, targetDirectory));
                    _logger.DebugExit();
                    return result;
                }

                using (var codeFactoryPackage = Package.Open(packageFilePath, FileMode.Open))
                {

                    foreach (var library in libraries)
                    {
                        try
                        {
                            var libraryPath = Path.Combine(targetDirectory, library);

                            if (File.Exists(libraryPath)) continue;


                            var libraryUri = PackUriHelper.CreatePartUri(
                            new Uri(string.Format(PACKAGE_LIBRARIES_VIRTUAL_FILEPATH, Path.GetFileName(library)),
                            UriKind.Relative));

                            if (!codeFactoryPackage.PartExists(libraryUri))
                            {
                                result.HasErrors = true;
                                result.Errors.Add(string.Format(ConfigurationMessages.LibraryNotInPackage, library));
                                continue;
                            }

                            var libraryPart = codeFactoryPackage.GetPart(libraryUri);

                            Stream libraryPartStream = null;
                            FileStream libraryFileStream = null;
                            try
                            {
                                libraryPartStream = libraryPart.GetStream();
                                libraryFileStream = new FileStream(libraryPath, FileMode.Create);

                                if (!libraryPartStream.CopyStreamData(libraryFileStream))
                                {
                                    result.HasErrors = true;
                                    result.Errors.Add(string.Format(ConfigurationMessages.LibraryLoadError, library));
                                }
                            }
                            finally
                            {
                                libraryPartStream?.Dispose();
                                libraryFileStream?.Dispose();
                            }


                        }
                        catch (Exception libraryLoadError)
                        {
                            _logger.Error(
                                "The following error occurred while trying to load a library from the code factory configuration.",
                                libraryLoadError);
                            result.HasErrors = true;
                            result.Errors.Add(string.Format(ConfigurationMessages.LibraryLoadError, library));
                        }
                    }
                }
            }
            catch (Exception extractLibrariesFromPackageError)
            {
                _logger.Error(
                    "The following unhandled exception occurred while trying to load libraries from the code factory package.",
                    extractLibrariesFromPackageError);
                result.HasErrors = true;
                result.Errors.Add(ConfigurationMessages.LibrariesNotLoaded);
            }

            _logger.DebugExit();
            return result;
        }

        #endregion
    }
}

