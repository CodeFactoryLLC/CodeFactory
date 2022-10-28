//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2022 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that builds the base class definition for all member types.
    /// </summary>
    public abstract class CsMember:CsModel,ICsMember
    {
        #region Property backing fields
        private readonly IReadOnlyList<CsAttribute> _attributes;
        private readonly IReadOnlyList<string> _sourceFiles;
        private readonly bool _hasDocumentation;
        private readonly string _documentation;
        private readonly string _lookupPath;
        private readonly string _name;
        private readonly string _parentPath;
        private readonly CsSecurity _security;
        private readonly CsMemberType _memberType;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsMember"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="memberType">The type of member this model represents.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="modelType">The type of model that represents this member.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="modelSourceFile">The source code file the model was generated from.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this member is defined in.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="parentPath">THe fully qualified lookup path for the parent model to this one.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        protected CsMember(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, CsModelType modelType,
            IReadOnlyList<CsAttribute> attributes, string modelSourceFile, IReadOnlyList<string> sourceFiles, bool hasDocumentation,
            string documentation, string lookupPath, string name, string parentPath, CsSecurity security,
            CsMemberType memberType, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, modelType, sourceDocument, modelStore, modelErrors)
        {
            _attributes = attributes ?? ImmutableList<CsAttribute>.Empty;
            _modelSourceFile = modelSourceFile;
            _sourceFiles = sourceFiles ?? ImmutableList<string>.Empty;
            _hasDocumentation = hasDocumentation;
            _documentation = documentation;
            _lookupPath = lookupPath;
            _name = name;
            _parentPath = parentPath;
            _security = security;
            _memberType = memberType;
        }

        /// <summary>
        ///     Flag that determines if attributes are assigned.
        /// </summary>
        public bool HasAttributes => _attributes.Any();

        /// <summary>
        ///     The attributes assigned to this item. If the HasAttributes is false this will be an empty list.
        /// </summary>
        public IReadOnlyList<CsAttribute> Attributes => _attributes;

        /// <summary>
        ///     The attributes assigned to this item. If the HasAttributes is false this will be an empty list.
        /// </summary>
        IReadOnlyList<IDotNetAttribute> IDotNetAttributes.Attributes => Attributes;

        /// <summary>
        /// The source file or files in which the model was loaded from. This will be an empty enumeration if the source models were loaded from metadata only.
        /// </summary>
        public IReadOnlyList<string> SourceFiles => _sourceFiles;

        /// <summary>
        ///     Flag that determines if the model has code level documentation assigned to it.
        /// </summary>
        public bool HasDocumentation => _hasDocumentation;

        /// <summary>
        ///     Documentation that has been assigned to this model.
        /// </summary>
        public string Documentation => _documentation;

        /// <summary>
        /// Adds the supplied source code directly before the documentation.
        /// </summary>
        /// <param name="sourceCode">The target syntax to be added to the document.</param>
        /// <returns>Updated <see cref="CsSource"/> model with the injected source code.</returns>
        public abstract Task<CsSource> AddBeforeDocsAsync(string sourceCode);

        /// <summary>
        /// Adds the supplied source code directly after the documentation.
        /// </summary>
        /// <param name="sourceCode">The target syntax to be added to the document.</param>
        /// <returns>Updated <see cref="CsSource"/> model with the injected source code.</returns>
        public abstract Task<CsSource> AddAfterDocsAsync(string sourceCode);

        /// <summary>
        /// Replaces the supplied source code directly this the documentation.
        /// </summary>
        /// <param name="sourceCode">The target syntax to be added to the document.</param>
        /// <returns>Updated <see cref="CsSource"/> model with the injected source code.</returns>
        public abstract Task<CsSource> ReplaceDocsAsync(string sourceCode);

        /// <summary>
        /// Deletes the documentation from the target supporting code artifact.
        /// </summary>
        /// <returns>Updated <see cref="CsSource"/> model with the documentation removed.</returns>
        public abstract Task<CsSource> DeleteDocsAsync();

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        IDotNetModel DotNet.IParent.Parent => Parent;

        /// <summary>
        /// The fully qualified path for this model that can be used when searching the source for the model.
        /// </summary>
        public string LookupPath => _lookupPath;

        /// <summary>
        ///     The name assigned to the member.
        /// </summary>
        public string Name => _name;

        /// <summary>
        ///     The security scope that has been assigned to the member.
        /// </summary>
        public CsSecurity Security => _security;

        /// <summary>
        /// The type of member the model is.
        /// </summary>
        public CsMemberType MemberType => _memberType;


        /// <summary>
        /// Backing field for <see cref="ModelSourceFile"/>
        /// </summary>
        private readonly string _modelSourceFile;

        /// <inheritdoc/>
        public string ModelSourceFile => _modelSourceFile;

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode);

        /// <inheritdoc/>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode, bool ignoreLeadingModelsAndDocs);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddAfterAsync(string sourceCode);


        /// <summary>
        /// Deletes the definition of the member from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the member is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the member has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> DeleteAsync(string sourceDocument);

        /// <summary>
        /// Deletes the definition of the member from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the member has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync();


        /// <summary>
        /// Gets the starting and ending locations within the document where the member is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the member defined in.</param>
        /// <returns>The source location for the member.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations within the document where the member is located.
        /// </summary>
        /// <returns>The source location for the member.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetSourceLocationAsync();


        /// <summary>
        /// Replaces the current member with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the current member with the provided source code.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> ReplaceAsync(string sourceCode);


       
        /// <summary>
        ///     The security scope that has been assigned to the member.
        /// </summary>
        DotNetSecurity IDotNetMember.Security => (DotNetSecurity) (int) _security;

        /// <summary>
        /// The type of member the model is.
        /// </summary>
        DotNetMemberType IDotNetMember.MemberType => (DotNetMemberType) (int) _memberType;

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        public CsModel Parent => GetModel(_parentPath);
    }
}
