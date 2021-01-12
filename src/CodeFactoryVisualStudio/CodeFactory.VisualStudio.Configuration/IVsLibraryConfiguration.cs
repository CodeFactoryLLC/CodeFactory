//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Data model that stores all the information needed to load a DLL into visual studio.
    /// </summary>
    public interface IVsLibraryConfiguration
    {
        /// <summary>
        ///     Flag that determines if the assembly is stored in the Global Assembly Cache on the computer.
        /// </summary>
        bool IsStoredInGac { get;}

        /// <summary>
        ///     Flag that determines if their were errors loading the library configuration.
        /// </summary>
        bool HasErrors { get;}

        /// <summary>
        ///     Enumeration that stores the type of error that has occurred while loading the library configuration.
        /// </summary>
        LibraryErrorType ErrorType { get;}

        /// <summary>
        ///     Stores the exception message for the error.
        /// </summary>
        string ErrorDetails { get;}

        /// <summary>
        ///     File path to where the assembly is found. This will be null if the assembly is stored in the GAC.
        /// </summary>
        string AssemblyFilePath { get; }

        /// <summary>
        ///     The fully qualified name of the assembly to be loaded. This will be null if not stored in the GAC.
        /// </summary>
        string AssemblyStrongName { get;}

        /// <summary>
        /// Flag that determines if the PDB file is found wit the assembly in the file path. This will be false if it is stored in the GAC.
        /// </summary>
        bool HasDebugInformation { get;}
    }
}
