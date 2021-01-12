//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using CodeFactory.VisualStudio.Configuration;

namespace CfxPackager
{
    /// <summary>
    /// Console application that builds the package used by the code factory runtime.
    /// </summary>
    class Program
    {
        private static readonly int SUCCESS = 0;

        private static readonly int FAILED = 1;

        static void Main(string[] args)
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
                Console.WriteLine("Failed to load the system version information. Cannot create the cfx file.");
                Environment.ExitCode = FAILED;
                return;
            }

            Console.WriteLine($"Code Factory Packager Version - {version}");

            if (args == null)
            {
                Console.WriteLine("The assembly path was not provided, cannot create the CFX file.");
                Environment.ExitCode = FAILED;
                return;
            }
            
            var filePath = args.FirstOrDefault();

            if (string.IsNullOrEmpty(filePath))
            {
                Console.WriteLine($"The assembly '{filePath}' could not be found, cannot create the CFX file.");
                Environment.ExitCode = FAILED;
                return;
            }

            if (!File.Exists(filePath))
            {
                Environment.ExitCode = FAILED;
            }

            bool result = false;
            try
            {
                Console.WriteLine($"Creating a package file for the assembly '{filePath}'.");
                result = ConfigManager.CreateDefaultPackage(filePath);

                if (result)
                    Console.WriteLine(
                        $"Successfully create the code factory package {Path.GetFileNameWithoutExtension(filePath)}.cfx");
                else
                    Console.Write("An error occured and the code factory package could not be completed.");
            }
            catch (Exception unhandledError)
            {
                Console.WriteLine(unhandledError);
                throw;
            }

            Environment.ExitCode = result ? SUCCESS : FAILED;
        }
    }
}
