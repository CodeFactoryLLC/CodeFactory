//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Linq;
using System.Reflection;

namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    /// Data class that holds the supported versions of the SDK that can be loaded.
    /// </summary>
    public static class SdkSupport
    {
        /// <summary>
        /// The minimum version of the SDK that can be loaded and used.
        /// </summary>
        public const string MinVersion = "1.22318.0.1";

        /// <summary>
        /// The maximum version of the SDK that can be loaded and used.
        /// </summary>
        public const string MaxVersion = "1.22320.0.1";

        /// <summary>
        /// The target version of the NuGet package this SDK is deployed from.
        /// </summary>
        public const string NuGetSdkVersion = "1.22320.1";

        /// <summary>
        /// Checks the assembly to see if it was created by a CodeFactory SDK. If so it checks the version to confirms it can be used by the runtime.
        /// </summary>
        /// <param name="sourceAssembly"></param>
        public static void  SupportedAssembly(Assembly sourceAssembly)
        {
            if (sourceAssembly == null) return ;

            bool cfAssembly = false;
            try
            {
                cfAssembly = sourceAssembly.GetReferencedAssemblies().Any( a=> a.Name == "CodeFactory");

                var sdkVersionObject = sourceAssembly.GetCustomAttributes(typeof(AssemblyCFSdkVersion), false);

                if (sdkVersionObject == null)
                {
                    if(cfAssembly) throw new UnsupportedSdkLibraryException(sourceAssembly.FullName, "0.0.0.0", MinVersion,
                        MaxVersion);

                    return;
                }

                
                var sdkVersion = sdkVersionObject[0] as AssemblyCFSdkVersion;

                if (sdkVersion == null) return;

                var rawVersion = sdkVersion.Value;

                if (string.IsNullOrEmpty(rawVersion)) return;

                int libraryVersion = Convert.ToInt32(rawVersion.Replace(".", ""));

                int minVersion = Convert.ToInt32(MinVersion.Replace(".", ""));
                int maxVersion = Convert.ToInt32(MaxVersion.Replace(".", ""));

                if (libraryVersion < minVersion || libraryVersion > maxVersion)
                    throw new UnsupportedSdkLibraryException(sourceAssembly.FullName, rawVersion, MinVersion,
                        MaxVersion);

            }
            catch (UnsupportedSdkLibraryException)
            {
                throw;
            }
            catch (Exception)
            {
                if(cfAssembly) throw new UnsupportedSdkLibraryException(sourceAssembly.FullName, "0.0.0.0", MinVersion,
                    MaxVersion);
            }

        }
    }
}
