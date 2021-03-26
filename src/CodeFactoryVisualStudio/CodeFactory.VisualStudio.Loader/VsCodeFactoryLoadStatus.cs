//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    /// Data model that implements the interface <see cref="IVsCodeFactoryLoadStatus"/>
    /// </summary>
    public class VsCodeFactoryLoadStatus:IVsCodeFactoryLoadStatus
    {
        private bool _isLoaded;
        private bool _hasError;
        private List<string> _errorMessages;
        IEnumerable <IVsCommandInformation> _visualStudioFactoryActions;

        #region Implementation of IVsCodeFactoryLoadStatus

        /// <summary>
        /// Flag that determines if visual studio commands were able to be loaded for the code factory package.
        /// </summary>
        public bool IsLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; }
        }

        /// <summary>
        /// Flag that determines if errors occured while loading the code factory commands.
        /// </summary>
        public bool HasErrors
        {
            get { return _hasError; }
            set { _hasError = value; }
        }

        /// <summary>
        /// The error messages that was captured while trying to load the code factory commands. This will be null if <see cref="IVsCodeFactoryLoadStatus.HasError"/> is false.
        /// </summary>
        public List<string> ErrorMessages
        {
            get { return _errorMessages; }
            set { _errorMessages = value; }
        }

        /// <summary>
        /// Enumeration of the factory commands that were loaded. This will be an empty enumeration if <see cref="IVsCodeFactoryLoadStatus.IsLoaded"/> is false.
        /// </summary>
        public IEnumerable<IVsCommandInformation> VisualStudioFactoryActions
        {
            get { return _visualStudioFactoryActions; }
            set { _visualStudioFactoryActions = value; }
        }

        #endregion
    }
}
