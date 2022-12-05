//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************

using System;
using System.IO;
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
        public const string MaxVersion = "1.22339.0.1";

        /// <summary>
        /// The target version of the NuGet package this SDK is deployed from.
        /// </summary>
        public const string NuGetSdkVersion = "1.22335.1";

        /// <summary>
        /// The name of the assembly type for the CodeFactory SDK version attribute.
        /// </summary>
        public const string CodeFactorySdkVersionAttributeName = "AssemblyCFSdkVersion";

        public const string CodeFactoryAssemblyName = "CodeFactory";

        /// <summary>
        /// Checks the assembly to see if it was created by a CodeFactory SDK. If so it checks the version to confirms it can be used by the runtime.
        /// </summary>
        /// <param name="sourceAssembly"></param>
        public static void  SupportedAssembly(Assembly sourceAssembly)
        {
            if (sourceAssembly == null) return ;

            //Adding a assembly resolver if the child assembly needs to be loaded
            AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;

            Assembly workAssembly = sourceAssembly;
            
            bool cfAssembly = false;
            try
            {
                cfAssembly = workAssembly.GetReferencedAssemblies().Any(a => a.Name == CodeFactoryAssemblyName);

                var customAttributes = CustomAttributeData.GetCustomAttributes(workAssembly);

                var versionSdk = customAttributes.FirstOrDefault(c => c.AttributeType.Name == CodeFactorySdkVersionAttributeName);

                var rawVersion = versionSdk?.ConstructorArguments.FirstOrDefault().Value as string;

                if (string.IsNullOrEmpty(rawVersion)) return;

                int libraryVersion = Convert.ToInt32(rawVersion.Replace(".", ""));

                int minVersion = Convert.ToInt32(MinVersion.Replace(".", ""));
                int maxVersion = Convert.ToInt32(MaxVersion.Replace(".", ""));

                if (libraryVersion < minVersion || libraryVersion > maxVersion)
                    throw new UnsupportedSdkLibraryException(workAssembly.FullName, rawVersion, MinVersion,
                        MaxVersion);

            }
            catch (UnsupportedSdkLibraryException)
            {
                throw;
            }
            catch (Exception)
            {
                if (cfAssembly)
                    throw new UnsupportedSdkLibraryException(workAssembly.FullName, "0.0.0.0", MinVersion,
                        MaxVersion);
            }
            finally
            {
                //Removing our delegate from the assembly resolver.
                AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve -= CurrentDomain_ReflectionOnlyAssemblyResolve;
            }

        }

        /// <summary>
        /// Event handler that resolves assemblies that are not in the reflection only context.
        /// </summary>
        /// <param name="sender">Application domain that needs to resolve.</param>
        /// <param name="args">Resolve arguments that contains the information needed for resolution.</param>
        /// <returns>The reflection only assembly or null if it cannot be loaded.</returns>
        private static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var loadedAssembly = assemblies.FirstOrDefault(a => a.FullName == args.Name);

            if (loadedAssembly != null)
            {
                return Assembly.ReflectionOnlyLoadFrom(loadedAssembly.Location);
            }

            var filenamePosition = args.Name.IndexOf(',');
            var fileName =$"{args.Name.Substring(0,filenamePosition)}.dll";

            var directoryPath = Path.GetDirectoryName(args.RequestingAssembly.Location);

            if (string.IsNullOrEmpty(directoryPath)) return null;

            var filePath = Path.Combine(directoryPath, fileName);

            return !File.Exists(filePath) ? null : Assembly.ReflectionOnlyLoadFrom(filePath);
        }
    }
}
