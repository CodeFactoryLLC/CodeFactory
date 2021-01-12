//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Base class that all C# compiler based data models derive from.
    /// </summary>
    public abstract class CsModel:ICsModel
    {
        #region Property backing fields
        private readonly bool _isLoaded;
        private readonly bool _hasErrors;
        private readonly bool _loadedFromSource;
        private readonly SourceCodeType _language;
        private readonly CsModelType _modelType;
        private readonly string _sourceDocument;
        #endregion

        /// <summary>
        /// Model field that stores the models load exceptions. 
        /// </summary>
        protected readonly IReadOnlyList<ModelLoadException> LocalModelErrors;

        
        /// <summary>
        /// Model field used to lookup models that were created during the compile or reference lookup using the C# compiler.
        /// </summary>
        protected readonly ModelStore<ICsModel> ModelStore;


        /// <summary>
        /// Constructor for the <see cref="CsModel"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="modelType">The type of code model created.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        protected CsModel(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, CsModelType modelType, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
        {
            _isLoaded = isLoaded;
            _hasErrors = hasErrors;
            _loadedFromSource = loadedFromSource;
            _language = language;
            _sourceDocument = sourceDocument;
            _modelType = modelType;
            ModelStore = modelStore;
            LocalModelErrors = modelErrors ?? ImmutableList<ModelLoadException>.Empty;
        }

        /// <summary>
        /// Flag that determines if this model was able to load.
        /// </summary>
        public bool IsLoaded => _isLoaded;

        /// <summary>
        /// Flag that determines if this model or one of the children of this model has an error.
        /// </summary>
        public bool HasErrors => _hasErrors;

        /// <summary>
        /// Gets the <see cref="ModelLoadException"/> from the current model and all child models of this model.
        /// </summary>
        /// <returns>Returns a <see cref="IReadOnlyList{T}"/> of the <see cref="ModelLoadException"/> exceptions or an empty list if no exceptions exist.</returns>
        public abstract IReadOnlyList<ModelLoadException> GetErrors();
        

        /// <summary>
        /// Flag that determines if this model was loaded from source code or was loaded through reflects or symbol libraries.
        /// </summary>
        public bool LoadedFromSource => _loadedFromSource;

        /// <summary>
        /// The target language this model was loaded from.
        /// </summary>
        public SourceCodeType Language => _language;

        /// <summary>
        /// The type of c# model that is implemented.
        /// </summary>
        public CsModelType ModelType => _modelType;

        /// <summary>
        /// The fully qualified path to the document that was used to load the model from source. This will be populated if the model was loaded from source.
        /// </summary>
        public string SourceDocument => _sourceDocument;

        /// <summary>
        /// The type of dot net model that was loaded.
        /// </summary>
        DotNetModelType IDotNetModel.ModelType => (DotNetModelType) (int) _modelType;

        /// <summary>
        /// Helper method that looks up a code factory model from the model store.
        /// </summary>
        /// <param name="path">The fully qualified path of the model to be loaded from the model store.</param>
        /// <returns>The loaded model or null if the model could not be loaded, or found. </returns>
        protected CsModel LookupModel(string path) => string.IsNullOrEmpty(path) ? null : ModelStore?.GetModel(path) as CsModel;
    }
}
