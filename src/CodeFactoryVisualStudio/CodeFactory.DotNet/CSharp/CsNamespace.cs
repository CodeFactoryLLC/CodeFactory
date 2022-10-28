//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2022 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents the definition of a namespace.
    /// </summary>
    public abstract class CsNamespace:CsModel,ICsNamespace
    {
        #region Property backing fields
        private readonly string _lookupPath;
        private readonly IReadOnlyList<string> _sourceFiles;
        private readonly string _name;
        private readonly string _parentPath;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsNamespace"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="parentPath">The fully qualified path for the model that is a parent of this model.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="lookupPath">The fully qualified lookup path for the model to be used in the model store.</param>
        /// <param name="modelSourceFile">The source code file the model was generated from.</param>
        /// <param name="sourceFiles">The source files where the namespace is defined in.</param>
        /// <param name="name">The fully qualified name of the namespace.</param>
        protected CsNamespace(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,string lookupPath, string modelSourceFile,
            IReadOnlyList<string> sourceFiles, string name, string parentPath, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, 
            IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Namespace, sourceDocument, modelStore, modelErrors)
        {
            _lookupPath = lookupPath;
            _modelSourceFile = modelSourceFile;
            _sourceFiles = sourceFiles ?? ImmutableList<string>.Empty;
            _name = name;
            _parentPath = parentPath;
        }

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        IDotNetModel DotNet.IParent.Parent => Parent;

        /// <summary>
        /// The fully qualified path for this model that can be used when searching the source for the model.
        /// </summary>
        public string LookupPath => _lookupPath;

        /// <summary>
        /// The source file or files in which the model was loaded from. This will be an empty enumeration if the source models were loaded from metadata only.
        /// </summary>
        public IReadOnlyList<string> SourceFiles => _sourceFiles;

        /// <summary>
        /// The name of the namespace.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        public CsModel Parent => GetModel(_parentPath);

        /// <summary>
        /// Backing field for <see cref="ModelSourceFile"/>
        /// </summary>
        private readonly string _modelSourceFile;

        /// <inheritdoc/>
        public string ModelSourceFile => _modelSourceFile;
    }
}
