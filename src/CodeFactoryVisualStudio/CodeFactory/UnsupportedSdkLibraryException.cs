//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory
{
    /// <summary>
    /// Exception class that tracks when a CodeFactory library is using an unsupported version of the SDK.
    /// </summary>
    public class UnsupportedSdkLibraryException:Exception
    {
        //Backing fields for the properties
        private readonly string _assemblyName;

        private readonly string _assemblyVersion;

        private readonly string _sdkMinVersion;

        private readonly string _sdkMaxVersion;

        /// <summary>
        /// Creates an instance of the exception <see cref="UnsupportedSdkLibraryException"/>
        /// </summary>
        /// <param name="assemblyName">Name of the assembly that is not supported.</param>
        /// <param name="assemblyVersion">The SDK version that was used to create the assembly.</param>
        /// <param name="sdkMinVersion">The minimum supported SDK version.</param>
        /// <param name="sdkMaxVersion">The maximum supported SDK version.</param>
        public UnsupportedSdkLibraryException(string assemblyName, string assemblyVersion, string sdkMinVersion, string sdkMaxVersion)
            :base($"The library '{assemblyName}' was built with SDK version '{assemblyVersion}' which is not in the supported range of '{sdkMinVersion} - {sdkMaxVersion}'.")
        {
            _assemblyName = assemblyName;
            _assemblyVersion = assemblyVersion;
            _sdkMinVersion = sdkMinVersion;
            _sdkMaxVersion = sdkMaxVersion;
        }
        
        /// <summary>
        /// The name of the assembly that is was compiled on an unsupported SDK version.
        /// </summary>
        public string AssemblyName => _assemblyName;

        /// <summary>
        /// The assembly SDK version that was used when building the assembly.
        /// </summary>
        public string AssemblyVersion => _assemblyVersion;

        /// <summary>
        /// The minimum supported SDK version.
        /// </summary>
        public string SdkMinVersion => _sdkMinVersion;

        /// <summary>
        /// The maximum supported SDK version.
        /// </summary>
        public string SdkMaxVersion => _sdkMaxVersion;
    }
}
