//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.VisualStudio.Loader;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CodeFactory.VisualStudio.Packager
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var commandLine = new CommandLineApplication(false);
            var assembly = commandLine.Option("-a|--assembly", "The fully qualified path to the CodeFactory library to be packaged.",CommandOptionType.SingleValue);
            var project = commandLine.Option("-p|--project", "The fully qualified path to the CodeFactory project to be version .",CommandOptionType.SingleValue);
            //var outputDir = commandLine.Option("-o|--output", "The fully qualified path to the directory that contains assemblies that support the CodeFactory command library.", CommandOptionType.SingleValue);
            commandLine.HelpOption("-?|-h|--help");

            commandLine.OnExecute(() =>
            {
                if (project.HasValue()) return ProcessProject(project.Value().Replace("\"", ""));

                if (!assembly.HasValue()) return PackagerData.ExitCodeNoAssemby;

                var assemblyPath = assembly.Value().Replace("\"","");
                if (!File.Exists(assemblyPath)) return PackagerData.ExitCodeNoAssemby;

                var assemblyName = Path.GetFileNameWithoutExtension(assemblyPath);

                if (string.IsNullOrEmpty(assemblyName)) return PackagerData.ExitCodeNoAssemby;
               
                Console.WriteLine($"--> Packaging Assembly: {assemblyName}");
                Console.WriteLine();

                var assemblyDirectory = Path.GetDirectoryName(assemblyPath);

                if (string.IsNullOrEmpty(assemblyDirectory)) return PackagerData.ExitCodeNoAssemblyDir;

                Assembly targetAssembly = LibraryManagement.GetAssemblyInformation(assemblyPath);

                if (targetAssembly == null)
                {
                    Console.WriteLine("--> Could not access the assembly to package due to a reflections error.");
                    return PackagerData.ExitCodeKnownError;
                }

                //Confirming the assembly is using a supported version. 
                SdkSupport.SupportedAssembly(targetAssembly);

                var commands = targetAssembly.GetLibraryActions();

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

                var externalLibraries = targetAssembly.GetExternalDependentLibraries(assemblyDirectory);

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

                var sdkVersion = LoadFileVersion();
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
                    Name = assemblyName,
                    SdkVersion = sdkVersion
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
            catch (UnsupportedSdkLibraryException unsupportedSdkLibrary)
            {
                Console.WriteLine($"--> {unsupportedSdkLibrary.Message}");
                returnCode = PackagerData.ExitCodeUnsupportedLibrarySDKVersion;
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

                case PackagerData.ExitCodeNoProjectDir:
                    Console.WriteLine("--> No project directory was located cannot set the SDK information for the assembly, cannot package the library.");
                    break;

                case PackagerData.ExitCodeCannotUpdateAssemblyInfo:
                    Console.WriteLine("--> Could not update the AssemblyInfo.cs file for the project, cannot package the library.");
                    break;

                case PackagerData.ExitCodeUnsupportedLibrarySDKVersion:
                    Console.WriteLine("--> A required library was built on an unsupported version of the CodeFactory SDK, cannot package the library.");
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

        private static int ProcessProject(string projectPath)
        {
            var projectDir = new DirectoryInfo(projectPath);

            if (!projectDir.Exists) return PackagerData.ExitCodeNoProjectDir;

            var assemblyInfoPath = $"{projectDir.FullName}\\Properties\\AssemblyInfo.cs";

            if (File.Exists(assemblyInfoPath)) return UpdateAssemblyInfo(assemblyInfoPath);

            var propertiesDir = new DirectoryInfo($"{projectPath}\\Properties");

            if (!propertiesDir.Exists) propertiesDir.Create();

            int result = WriteNewAssemblyInfo(assemblyInfoPath);

            Console.WriteLine($"--> Updating Project: {Path.GetDirectoryName(projectPath)}");
            Console.WriteLine($"--> Setting SDK Version to : {LoadFileVersion()}");
            Console.WriteLine();

            return result;
        }

        private static int UpdateAssemblyInfo(string assemblyPath)
        {
            if (string.IsNullOrEmpty(assemblyPath)) return PackagerData.ExitCodeCannotUpdateAssemblyInfo;

            
            try
            {
                var envAttribute = "[assembly: AssemblyCFEnvironment(\"CFVSW\")]";

                var versionAttribute = $"[assembly: AssemblyCFSdkVersion(\"{LoadFileVersion()}\")]";

                var usingStatement = "using CodeFactory.VisualStudio;";

                bool envFound = false;

                bool versionFound = false;

                bool hasUsingStatement = false;

                var assemblyInfoCurrent = File.ReadAllLines(assemblyPath);

                var assemblyDataUpdated = new List<string>();

                var formattedAssemblyData = new List<string>();

                foreach (var assemblyData in assemblyInfoCurrent)
                {
                    string updatedContent = assemblyData;

                    if (!hasUsingStatement)
                    {
                        hasUsingStatement = Regex.IsMatch(assemblyData, AttributeManager.RegexFindNamespace);
                    }

                    if (!envFound)
                    {
                        envFound = Regex.IsMatch(assemblyData, AttributeManager.RegexFindCFEnvironment);

                        if (envFound)
                        {
                            updatedContent = Regex.Replace(assemblyData, AttributeManager.RegexFindCFEnvironment,envAttribute);
                            Console.WriteLine($"--> Updating CodeFactory environment attribute to '{envAttribute}'");

                        }
                    }

                    if (!versionFound)
                    {
                        versionFound = Regex.IsMatch(assemblyData, AttributeManager.RegexFindCFSdkVersion);

                        if (versionFound)
                        {
                            updatedContent = Regex.Replace(assemblyData, AttributeManager.RegexFindCFSdkVersion,versionAttribute);
                            Console.WriteLine($"--> Updating CodeFactory SDK version to '{versionAttribute}'");

                        }
                    }

                    assemblyDataUpdated.Add(updatedContent);
                }


                if (!envFound)
                {
                    assemblyDataUpdated.Add(envAttribute);
                    Console.WriteLine($"--> Adding CodeFactory Environment attribute '{envAttribute}'");

                }

                if (!versionFound)
                {
                    assemblyDataUpdated.Add(versionAttribute);
                    Console.WriteLine($"--> Adding CodeFactory SDK version '{versionAttribute}'");

                }

                if (!hasUsingStatement)
                {
                    formattedAssemblyData.Add(usingStatement);
                    formattedAssemblyData.AddRange(assemblyDataUpdated);
                    Console.WriteLine($"--> Adding using statement to the assemblyinfo file. '{usingStatement}'");

                }
                else
                {
                    formattedAssemblyData = assemblyDataUpdated;
                }

                File.WriteAllLines(assemblyPath,formattedAssemblyData);

            }
            catch (Exception unhandledError)
            {
                return PackagerData.ExitCodeCannotUpdateAssemblyInfo;
            }
            
            Console.WriteLine("--> Updates Completed'");
            Console.WriteLine("");

            return PackagerData.ExitCodeSuccess;
        }

        private static int WriteNewAssemblyInfo(string assemblyPath)
        {
            var assemblyFileContents = new List<string>();

            try
            {
                assemblyFileContents.Add("using CodeFactory.VisualStudio;");
                assemblyFileContents.Add("using System.Reflection;");
                assemblyFileContents.Add("using System.Runtime.CompilerServices;");
                assemblyFileContents.Add("using System.Runtime.InteropServices;");
                assemblyFileContents.Add("");
                assemblyFileContents.Add("[assembly: AssemblyVersion(\"1.0.0.0\")]");
                assemblyFileContents.Add("[assembly: AssemblyFileVersion(\"1.23044.0.1\")]");
                assemblyFileContents.Add("[assembly: AssemblyCFEnvironment(\"CFVSW\")]");
                assemblyFileContents.Add($"[assembly: AssemblyCFSdkVersion(\"{LoadFileVersion()}\")]");

                File.WriteAllLines(assemblyPath,assemblyFileContents);
            }
            catch (Exception unhandledError)
            {
                return PackagerData.ExitCodeCannotUpdateAssemblyInfo;
            }


            return PackagerData.ExitCodeSuccess;
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
