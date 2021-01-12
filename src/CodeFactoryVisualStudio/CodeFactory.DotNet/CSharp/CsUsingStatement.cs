//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents a namespace reference in source code.
    /// </summary>
    public abstract class CsUsingStatement:CsModel,ICsUsingStatement
    {
        #region Property backing fields
        private readonly string _lookupPath;
        private readonly string _referenceNamespace;
        private readonly bool _hasAlias;
        private readonly string _alias;
        private readonly string _parentPath;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsUsingStatement"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="parentPath">Fully qualified lookup path for the parent model to this model.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="lookupPath">Fully qualified path for the model to be stored in the model store.</param>
        /// <param name="referenceNamespace">The full namespace being referenced.</param>
        /// <param name="hasAlias">Flag that determines if the namespace is referenced by a alias name.</param>
        /// <param name="alias">The alias name for the referenced namespace. this will be null when <see cref="HasAlias"/> is false</param>
        protected CsUsingStatement(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, string lookupPath, 
            string referenceNamespace, bool hasAlias, string alias, string parentPath, string sourceDocument = null,
            ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Using, sourceDocument, modelStore, modelErrors)
        {
            _lookupPath = lookupPath;
            _referenceNamespace = referenceNamespace;
            _hasAlias = hasAlias;
            _alias = alias;
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
        /// The target namespace that is being imported into the sources scope.
        /// </summary>
        public string ReferenceNamespace => _referenceNamespace;

        /// <summary>
        /// Flag that determines if the namespace reference has an alias.
        /// </summary>
        public bool HasAlias => _hasAlias;

        /// <summary>
        /// The alias assigned to the namespace being imported. This will be null if the <see cref="IDotNetNamespaceReference.HasAlias"/> is false. 
        /// </summary>
        public string Alias => _alias;

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        public CsModel Parent => LookupModel(_parentPath);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddAfterAsync(string sourceCode);

        /// <summary>
        /// Deletes the definition of the using statement from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the using statement is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the using statement has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync(string sourceDocument);

        /// <summary>
        /// Deletes the definition of the using statement from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the using statement has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync();

        /// <summary>
        /// Gets the starting and ending locations within the document where the using statement is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the using statement defined in.</param>
        /// <returns>The source location for the using statement.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations within the document where the using statement is located.
        /// </summary>
        /// <returns>The source location for the using statement.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetSourceLocationAsync();

        /// <summary>
        /// Replaces the current using statement with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the current using statement with the provided source code.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> ReplaceAsync(string sourceCode);

        /// <summary>
        /// Gets a <see cref="ICsModel"/> from the currently loaded source code. 
        /// </summary>
        /// <param name="lookupPath">The fully qualified path to the model to be loaded.</param>
        /// <returns>The loaded model or null if the model could not be found.</returns>
        public ICsModel GetModel(string lookupPath) => LookupModel(lookupPath);

    }
}
