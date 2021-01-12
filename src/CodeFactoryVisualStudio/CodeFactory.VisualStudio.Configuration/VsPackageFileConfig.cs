//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Model class that implements the interface <see cref="IVsPackageFileConfig"/>
    /// </summary>
    public class VsPackageFileConfig:IVsPackageFileConfig
    {
        private bool _hasDebugDatabaseFile;
        private string _assemblyPhysicalPath;
        private string _assemblyPackagePath;
        private string _pdbPhysicalPath;
        private string _pdbPackagePath;

        #region Implementation of IVsPackageFileConfig

        /// <summary>
        /// Flag that determines if the package library has a debug database file.
        /// </summary>
        public bool HasDebugDatabaseFile
        {
            get { return _hasDebugDatabaseFile; }
            set { _hasDebugDatabaseFile = value; }
        }

        /// <summary>
        /// Physical location of the assembly to add to the package.
        /// </summary>
        public string AssemblyPhysicalPath
        {
            get { return _assemblyPhysicalPath; }
            set { _assemblyPhysicalPath = value; }
        }

        /// <summary>
        /// The logical location in the package the assembly will be stored.
        /// </summary>
        public string AssemblyPackagePath
        {
            get { return _assemblyPackagePath; }
            set { _assemblyPackagePath = value; }
        }

        /// <summary>
        /// Physical location of the PDB to add to the package.
        /// </summary>
        public string PDBPhysicalPath
        {
            get { return _pdbPhysicalPath; }
            set { _pdbPhysicalPath = value; }
        }

        /// <summary>
        /// The logical location in the package the PDB will be stored.
        /// </summary>
        public string PDBPackagePath
        {
            get { return _pdbPackagePath; }
            set { _pdbPackagePath = value; }
        }

        #endregion
    }
}
