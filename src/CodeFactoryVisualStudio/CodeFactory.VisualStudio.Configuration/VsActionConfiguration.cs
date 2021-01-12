//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Data model class that implements the interface <see cref="IVsActionConfiguration"/>
    /// </summary>
    public class VsActionConfiguration:IVsActionConfiguration
    {
        private string _commandAssemblyFullName;
        private string _title;
        private VsCommandType _visualStudioActionType;

        #region Implementation of IVsActionConfiguration

        /// <summary>
        ///     The assembly full name for an command.
        /// </summary>
        public string ActionAssemblyFullName
        {
            get { return _commandAssemblyFullName; }
            set { _commandAssemblyFullName = value; }
        }

        /// <summary>
        ///     The title that is assigned to the command.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// The type of visual studio command being loaded.
        /// </summary>
        public VsCommandType VisualStudioActionType
        {
            get { return _visualStudioActionType; }
            set { _visualStudioActionType = value; }
        }

        #endregion
    }
}
