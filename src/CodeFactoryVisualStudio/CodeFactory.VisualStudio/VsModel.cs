//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Base class used by all visual studio models.
    /// </summary>
    public abstract class VsModel:IVsModel
    {
        #region Property backing fields
        private readonly bool _isLoaded;
        private readonly bool _hasErrors;
        private readonly IReadOnlyList<ModelException<VisualStudioModelType>> _modelErrors;
        private readonly VisualStudioModelType _modelType;
        private readonly string _name;
        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsModel"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occurred while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occurred if any.</param>
        /// <param name="modelType">The type of visual studio model that is loaded.</param>
        /// <param name="name">The name of the model.</param>
        protected VsModel(bool isLoaded, bool hasErrors, IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors, VisualStudioModelType modelType, string name)
        {
            _isLoaded = isLoaded;
            _hasErrors = hasErrors;
            _modelErrors = modelErrors ?? ImmutableList<ModelException<VisualStudioModelType>>.Empty;
            _modelType = modelType;
            _name = name;
        }

        /// <summary>
        /// Flag that determines if this model was able to load.
        /// </summary>
        public bool IsLoaded => _isLoaded;

        /// <summary>
        /// Flag that determines if this model has errors.
        /// </summary>
        public bool HasErrors => _hasErrors;

        /// <summary>
        /// List of all errors that occurred in this model.
        /// </summary>
        public IReadOnlyList<ModelException<VisualStudioModelType>> ModelErrors => _modelErrors;

        /// <summary>
        /// Determines the type of model that has been loaded.
        /// </summary>
        public VisualStudioModelType ModelType => _modelType;

        /// <summary>
        /// The name of the visual studio model.
        /// </summary>
        public string Name => _name;
    }
}
