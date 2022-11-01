//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.VisualStudio.Loader;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeFactory.VisualStudio.Packager
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var commandLine = new CommandLineApplication(false);
            var assembly = commandLine.Option("-a|--assembly", "The fully qualified path to the CodeFactory library to be packaged.",CommandOptionType.SingleValue);
            //var outputDir = commandLine.Option("-o|--output", "The fully qualifed path to the directory that contains assemblies that support the CodeFactory command library.", CommandOptionType.SingleValue);
            commandLine.HelpOption("-?|-h|--help");

            commandLine.OnExecute(() =>
            {
                if (!assembly.HasValue()) return PackagerData.ExitCodeNoAssemby;
                var assemblyPath = assembly.Value().Replace("\"","");
                if (!File.Exists(assemblyPath)) return PackagerData.ExitCodeNoAssemby;

                var assemblyName = Path.GetFileNameWithoutExtension(assemblyPath);

                if (string.IsNullOrEmpty(assemblyName)) return PackagerData.ExitCodeNoAssemby;
               
                Console.WriteLine($"--> Packaging Assembly: {assemblyName}");
                Console.WriteLine();

                var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

                if (string.IsNullOrEmpty(assemblyDirectory)) return PackagerData.ExitCodeNoAssemblyDir;

                Assembly targetAssemby = LibraryManagement.GetAssemblyInformation(assemblyPath);

                if (targetAssemby == null)
                {
                    Console.WriteLine("--> Could not access the assembly to package due to a reflections error.");
                    return PackagerData.ExitCodeKnownError;
                }

                var commands = targetAssemby.GetLibraryActions();

                if (!commands.Any())
                {
                    Console.WriteLine("--> This assembly does not contain any commands to package. No package will be created.");
                    return PackagerData.ExitCodeSuccess;
                }

                Console.WriteLine("--> CodeFactory commands being packaged:");
                foreach (var command in commands)
                {
                    Console.WriteLine($"--> {command.Title} - {Enum.GetName(typeof(VsCommandType), command.VisualStudioActionType)}");
                }
                Console.WriteLine();

                var externalLibraries = targetAssemby.GetExternalDependentLibraries(assemblyDirectory);

                if (externalLibraries.Any(supportLibrary => supportLibrary.HasErrors))
                {
                    foreach (var library in externalLibraries)
                    {
                        if (!library.HasErrors) continue;

                        var assemblyInfo = library.IsStoredInGac ? $"--> GAC - {library.AssemblyStrongName}" : $"--> File - {library.AssemblyFilePath}";
                        Console.WriteLine(assemblyInfo);
                        Console.WriteLine($"--> The follow error occurred trying to load the external assembly. '{library.ErrorDetails}'");
                    }
                    Console.WriteLine("--> Cannot create the package since the above assembly information was not able to load correctly.");
                    return PackagerData.ExitCodeKnownError;
                }
                if (externalLibraries.Any())
                {
                    Console.WriteLine($"--> Packaging {externalLibraries.Count} external assemblies:");
                    foreach (var externalAssembly in externalLibraries)
                    {
                        var assemblyInfo = externalAssembly.IsStoredInGac ? $"--> GAC - {externalAssembly.AssemblyStrongName}" : $"--> File - {externalAssembly.AssemblyFilePath}";
                        Console.WriteLine(assemblyInfo);
                    }
                    Console.WriteLine();
                }

                var factoryConfig = new VsFactoryConfiguration
                {
                    CodeFactoryActions = commands,
                    SupportLibraries = externalLibraries,
                    CodeFactoryLibraries =
                        new List<VsLibraryConfiguration>
                        { 
                            new VsLibraryConfiguration
                            {
                                IsStoredInGac = false,
                                HasErrors = false,
                                AssemblyFilePath = assemblyPath
                            }
                        },
                    Id = Guid.NewGuid(),
                    Name = assemblyName
                };

                var result = ConfigManager.CreateCodeFactoryPackage(factoryConfig, assemblyDirectory, assemblyName);

                if (!result) return PackagerData.ExitCodePackageError;

                Console.WriteLine("--> Package Created Successfully.");
                Console.WriteLine($"--> Package file is '{assemblyDirectory}\\{assemblyName}.{PackagerData.PackageExtension}'");
                return PackagerData.ExitCodeSuccess;
            });

            int returnCode = 0;
            try
            {
                var fileVersion = LoadFileVersion();
                Console.WriteLine();
                Console.WriteLine($"{PackagerData.PackagerName} - Version {fileVersion}");
                Console.WriteLine();

                if (args == null || args.Length == 0)
                {
                    returnCode = PackagerData.ExitCodeNoParameters;
                }
                else
                {
                    returnCode = commandLine.Execute(args);
                }
            }
            catch (CommandParsingException cpe)
            {
                Console.WriteLine(cpe.Message);
                commandLine.ShowHelp();
                if (Environment.ExitCode != 0) Environment.ExitCode = PackagerData.ExitCodeUnknownError;
                return;
            }
            catch (Exception unhandledException)
            {
                Console.WriteLine($"--> The following unhandled exception occurred, '{unhandledException.Message}' ");
                if (Environment.ExitCode != 0) Environment.ExitCode = PackagerData.ExitCodeUnknownError;
                return;
            }

            Environment.ExitCode = returnCode;

            switch (returnCode)
            {

                case PackagerData.ExitCodeSuccess:

                    //Intentionally blank
                    break;

                case PackagerData.ExitCodeNoAssemblyData:
                    Console.WriteLine("--> Could not access the Packagers version information. Cannot process the package.");
                    break;

                case PackagerData.ExitCodeNoAssemblyDir:
                    Console.WriteLine("--> The output directory for assemblies was not provided, or it did not exist on the file system.");
                    commandLine.ShowHelp();
                    break;

                case PackagerData.ExitCodeNoAssemby:
                    Console.WriteLine("--> The target assembly to be package was not provided, or it could not be found on the file system.");
                    commandLine.ShowHelp();
                    break;

                case PackagerData.ExitCodeNoParameters:
                    Console.WriteLine("--> No parameters were provided, cannot package the CodeFactory automation.");
                    commandLine.ShowHelp();
                    break;

                case PackagerData.ExitCodeKnownError:
                    Console.WriteLine("--> See the above error which caused the package to not be created.");
                    break;

                case PackagerData.ExitCodePackageError:
                    Console.WriteLine("--> An internal error occurred while creating the final package. Please clean the the project and build again.");
                    break;
            default:
                    Console.WriteLine("--> An unknown internal error has occurred, cannot package the CodeFactory automation.");
                    break;

            }

            Console.WriteLine();
        }

        /// <summary>
        /// Extracts the file version information from the packager assembly.
        /// </summary>
        /// <returns>The file version number of the packager assembly.</returns>
        public static string LoadFileVersion()
        {
            string version = "1.0";
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);

                version = versionInfo.FileVersion;

            }
            catch (Exception)
            {
                Environment.ExitCode = PackagerData.ExitCodeNoAssemblyData;
                throw new Exception("Cannot load the version information for the Packager. Cannot package the CodeFactory automation.");
            }

            return version;
        }

    }
}
