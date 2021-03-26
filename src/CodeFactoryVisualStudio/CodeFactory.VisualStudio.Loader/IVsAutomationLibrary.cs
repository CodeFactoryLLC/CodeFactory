//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.VisualStudio.Loader
{
    public interface IVsAutomationLibrary
    {
        /// <summary>
        ///     Fully qualified path to the library file.
        /// </summary>
        string LibraryFilePath { get;}

        /// <summary>
        ///     enumeration of the supporting libraries required for automation library to function.
        /// </summary>
        List<VsLibraryConfiguration> SupportLibraries { get;}

        /// <summary>
        ///     enumeration of the commands that are supported by this library.
        /// </summary>
        List<VsActionConfiguration> LibraryActions { get;}
    }
}
