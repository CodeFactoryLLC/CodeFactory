//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Model definition that tracks information about where files are located and where to place them in the package definition.
    /// </summary>
    public interface IVsPackageFileConfig
    {
        /// <summary>
        /// Flag that determines if the package library has a debug database file.
        /// </summary>
        bool HasDebugDatabaseFile { get;}

        /// <summary>
        /// Physical location of the assembly to add to the package.
        /// </summary>
        string AssemblyPhysicalPath { get;}

        /// <summary>
        /// The logical location in the package the assembly will be stored.
        /// </summary>
        string AssemblyPackagePath { get;}

        /// <summary>
        /// Physical location of the PDB to add to the package.
        /// </summary>
        string PDBPhysicalPath { get;}

        /// <summary>
        /// The logical location in the package the PDB will be stored.
        /// </summary>
        string PDBPackagePath { get;}
    }
}
