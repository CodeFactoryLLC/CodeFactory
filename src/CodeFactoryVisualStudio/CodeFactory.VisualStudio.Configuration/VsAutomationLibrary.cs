//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Data model that implements the interface <see cref="IVsAutomationLibrary"/>
    /// </summary>
    public class VsAutomationLibrary:IVsAutomationLibrary
    {
        private string _libraryFilePath;
        private List<VsLibraryConfiguration> _supportLibraries;
        private List<VsActionConfiguration> _libraryActions;

        #region Implementation of IVsAutomationLibrary

        /// <summary>
        ///     Fully qualified path to the library file.
        /// </summary>
        public string LibraryFilePath
        {
            get { return _libraryFilePath; }
            set { _libraryFilePath = value; }
        }

        /// <summary>
        ///     enumeration of the supporting libraries required for automation library to function.
        /// </summary>
        public List<VsLibraryConfiguration> SupportLibraries
        {
            get { return _supportLibraries; }
            set { _supportLibraries = value; }
        }

        /// <summary>
        ///     enumeration of the commands that are supported by this library.
        /// </summary>
        public List<VsActionConfiguration> LibraryActions
        {
            get { return _libraryActions; }
            set { _libraryActions = value; }
        }

        #endregion
    }
}
