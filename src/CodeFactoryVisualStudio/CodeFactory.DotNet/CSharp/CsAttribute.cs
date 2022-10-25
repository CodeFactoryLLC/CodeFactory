//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2022 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents an attribute.
    /// </summary>
    public abstract class CsAttribute:CsModel,ICsAttribute
    {
        #region Property backing fields
        private readonly IReadOnlyList<string> _sourceFiles;
        private readonly bool _hasParameters;
        private readonly string _parentPath;
        private readonly IReadOnlyList<CsAttributeParameter> _parameters;
        private readonly CsType _type;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsAttribute"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="type">The target type of the attribute.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="sourceFiles">The list of source files the attribute is defined in.</param>
        /// <param name="hasParameters">Flag that determines if the attribute has parameters.</param>
        /// <param name="parentPath">The fully qualified lookup path to the parent model for this attribute.</param>
        /// <param name="parameters">The list of parameters assigned to the attribute.</param>
        protected CsAttribute(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<string> sourceFiles, bool hasParameters, string parentPath, IReadOnlyList<CsAttributeParameter> parameters, 
            CsType type, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Attribute, sourceDocument, modelStore, modelErrors)
        {
            _sourceFiles = sourceFiles ?? ImmutableList<string>.Empty;
            _hasParameters = hasParameters;
            _parentPath = parentPath;
            _parameters = parameters ?? ImmutableList<CsAttributeParameter>.Empty;
            _type = type;
        }

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        IDotNetModel DotNet.IParent.Parent => Parent;

        /// <summary>
        /// The source file or files in which the model was loaded from. This will be an empty enumeration if the source models were loaded from metadata only.
        /// </summary>
        public IReadOnlyList<string> SourceFiles => _sourceFiles;

        /// <summary>
        ///     Enumeration of the parameters that are assigned to the attribute. This will be an empty list if HasParameters is false.
        /// </summary>
        public IReadOnlyList<CsAttributeParameter> Parameters => _parameters;

        /// <summary>
        ///     The type information for the attribute itself.
        /// </summary>
        public CsType Type => _type;

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsAttribute"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsAttribute"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode);


        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="CsAttribute"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="CsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="CsAttribute"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="CsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddAfterAsync(string sourceCode);

        /// <summary>
        /// Deletes the definition of the attribute from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the attribute is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="CsSource"/> model after the attribute has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> DeleteAsync(string sourceDocument);

        /// <summary>
        /// Deletes the definition of the attribute from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="CsSource"/> model after the attribute has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync();

        /// <summary>
        /// Gets the starting and ending locations within the document where the attribute is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the attribute defined in.</param>
        /// <returns>The source location for the attribute.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations within the document where the attribute is located.
        /// </summary>
        /// <returns>The source location for the attribute.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetSourceLocationAsync();

        /// <summary>
        /// Replaces the current attribute with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="CsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the current attribute with the provided source code.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="CsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> ReplaceAsync(string sourceCode);

        /// <summary>
        ///     The type information for the attribute itself.
        /// </summary>
        IDotNetType IDotNetAttribute.Type => Type;

        /// <summary>
        ///     Flag that determines if the attribute has parameters
        /// </summary>
        public bool HasParameters => _hasParameters;

        /// <summary>
        ///     Enumeration of the parameters that are assigned to the attribute. This will be an empty list if HasParameters is false.
        /// </summary>
        IReadOnlyList<IDotNetAttributeParameter> IDotNetAttribute.Parameters => Parameters;

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        public CsModel Parent => GetModel(_parentPath);

    }
}
