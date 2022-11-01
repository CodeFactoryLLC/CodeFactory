//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    ///     Enumeration that stores the type error that has occurred while loading a library.
    /// </summary>
    public enum LibraryErrorType
    {
        /// <summary>
        ///     No error has occurred while loading the library.
        /// </summary>
        None = 0,

        /// <summary>
        ///     The library is incorrectly formatted and cannot be loaded by the code factory framework.
        /// </summary>
        InvalidLibrary = 1,

        /// <summary>
        ///     The library file could not be found.
        /// </summary>
        FileNotFound = 2,

        /// <summary>
        ///     An error occurred while trying to load the assembly.
        /// </summary>
        AssemblyLoadError = 3,

        /// <summary>
        ///     A general exception occurred while loading the library.
        /// </summary>
        LoadException = 4
    }
}
