//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Immutable;

namespace CodeFactory.VisualStudio.Packager
{
    /// <summary>
    /// Data class that holds packager global data.
    /// </summary>
    public static class PackagerData
    {
        /// <summary>
        /// Name of the packager utility
        /// </summary>
        public const string PackagerName = "CodeFactory Packager for Visual Studio Windows";

        /// <summary>
        /// The file extension to be used with packager itself.
        /// </summary>
        public const string PackageExtension = "cfx";

        /// <summary>
        /// Application exited successfully.
        /// </summary>
        public const int ExitCodeSuccess = 0;

        /// <summary>
        /// Application exited with no assembly being provided.
        /// </summary>
        public const int ExitCodeNoAssemby = 1;

        /// <summary>
        /// Application exited with no assembly directory being provided.
        /// </summary>
        public const int ExitCodeNoAssemblyDir = 2;

        /// <summary>
        /// Could not access the assembly file data on the application itself.
        /// </summary>
        public const int ExitCodeNoAssemblyData = 3;

        /// <summary>
        /// No Parameters were passed into the packager.
        /// </summary>
        public const int ExitCodeNoParameters = 4;

        /// <summary>
        /// During the creation of the CFX Package an error occurred.
        /// </summary>
        public const int ExitCodePackageError = 5;

        /// <summary>
        /// Could not access the project directory
        /// </summary>
        public const int ExitCodeNoProjectDir = 6;

        /// <summary>
        /// Cannot update the AssemblyInfo.cs file.
        /// </summary>
        public const int ExitCodeCannotUpdateAssemblyInfo = 7;

        /// <summary>
        /// A library was built using an unsupported version of the CodeFactory SDK.
        /// </summary>
        public const int ExitCodeUnsupportedLibrarySDKVersion = 8;

        /// <summary>
        /// Application executed with a known error condition. 
        /// </summary>
        public const int ExitCodeKnownError = 9998;

        /// <summary>
        /// Application exited with an unknown internal error occurring.
        /// </summary>
        public const int ExitCodeUnknownError = 9999;

        /// <summary>
        /// Assemblies that should not be included with the packaging process.
        /// </summary>
        public static ImmutableList<string> IgnoreAssemblies = ImmutableList<string>.Empty.AddRange(new string[] { "CodeFactory", "CodeFactory.DotNet", "CodeFactory.VisualStudio", "CodeFactory.VisualStudio.Loader","CodeFactory.Logging", "NLog", "System.Collections.Immutable" });
        
    }
}
