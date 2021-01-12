//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;

namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Data model that implements the <see cref="IVsFactoryConfiguration"/> interface.
    /// </summary>
    public class VsFactoryConfiguration:IVsFactoryConfiguration
    {
        private string _name;
        private Guid _id;
        private List<VsLibraryConfiguration> _supportLibraries;
        private List<VsLibraryConfiguration> _codeFactoryLibraries;
        private List<VsActionConfiguration> _codeFactoryActions;

        #region Implementation of IVsFactoryConfiguration

        /// <summary>
        /// The name assigned to this automation configuration. 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The unique identifier that is assigned to the factory configuration.
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Enumeration of the support libraries that need to be loaded to run the code factory libraries.
        /// </summary>
        public List<VsLibraryConfiguration> SupportLibraries
        {
            get { return _supportLibraries; }
            set { _supportLibraries = value; }
        }

        /// <summary>
        /// Enumeration of the code factory libraries that need to be loaded.
        /// </summary>
        public List<VsLibraryConfiguration> CodeFactoryLibraries
        {
            get { return _codeFactoryLibraries; }
            set { _codeFactoryLibraries = value; }
        }

        /// <summary>
        /// Enumeration of the commands to be loaded into the code factory.
        /// </summary>
        public List<VsActionConfiguration> CodeFactoryActions
        {
            get { return _codeFactoryActions; }
            set { _codeFactoryActions = value; }
        }

        #endregion
    }
}
