//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents the definition of a delegate.
    /// </summary>
    public abstract class CsDelegate:CsModel,ICsDelegate
    {
        #region Property backing fields
        private readonly IReadOnlyList<CsAttribute> _attributes;
        private readonly bool _isGeneric;
        private readonly bool _hasStrongTypesInGenerics;
        private readonly IReadOnlyList<CsGenericParameter> _genericParameters;
        private readonly IReadOnlyList<CsType> _genericTypes;
        private readonly bool _hasDocumentation;
        private readonly string _documentation;
        private readonly string _lookupPath;
        private readonly IReadOnlyList<string> _sourceFiles;
        private readonly string _name;
        private readonly string _ns;
        private readonly bool _hasParameters;
        private readonly bool _isVoid;
        private readonly string _parentPath;
        private readonly CsSecurity _security;
        private readonly CsType _returnType;
        private readonly IReadOnlyList<CsParameter> _parameters;
        private readonly CsMethod _invokeMethod;
        private readonly CsMethod _beginInvokeMethod;
        private readonly CsMethod _endInvokeMethod;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsDelegate"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="isGeneric">Flag that determines if the delegate is a generic definition.</param>
        /// <param name="hasStrongTypesInGenerics">Flag that determines if the generics use strong type definitions.</param>
        /// <param name="genericParameters">Generic parameters assigned to the delegate.</param>
        /// <param name="genericTypes">Target types for the generic parameters assigned to the delegate.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="modelSourceFile">The source code file the model was created from.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this member is defined in.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="ns">The namespace this delegate is assigned to.</param>
        /// <param name="isVoid">Flag that determines if the return type is void. </param>
        /// <param name="parentPath">THe fully qualified lookup path for the parent model to this one.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        /// <param name="returnType">The type definition for the return type.</param>
        /// <param name="hasParameters">Flag that determines if the delegate had parameters.</param>
        /// <param name="parameters">The parameters assigned to the delegate.</param>
        /// <param name="invokeMethod">The invoke method definition assigned to this delegate.</param>
        /// <param name="beginInvokeMethod">The begin invoke method definition assigned to this delegate.</param>
        /// <param name="endInvokeMethod">The end invoke method definition assigned to this delegate.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        protected CsDelegate(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<CsAttribute> attributes, bool isGeneric, bool hasStrongTypesInGenerics, IReadOnlyList<CsGenericParameter> genericParameters, 
            IReadOnlyList<CsType> genericTypes, bool hasDocumentation, string documentation, string lookupPath, string modelSourceFile,
            IReadOnlyList<string> sourceFiles, string name, string ns, bool hasParameters, bool isVoid, string parentPath,
            CsSecurity security, CsType returnType, IReadOnlyList<CsParameter> parameters, CsMethod invokeMethod,
            CsMethod beginInvokeMethod, CsMethod endInvokeMethod, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Delegate, sourceDocument, modelStore, modelErrors)
        {
            _attributes = attributes ?? ImmutableList<CsAttribute>.Empty;
            _isGeneric = isGeneric;
            _hasStrongTypesInGenerics = hasStrongTypesInGenerics;
            _genericParameters = genericParameters ?? ImmutableList<CsGenericParameter>.Empty;
            _genericTypes = genericTypes ?? ImmutableList<CsType>.Empty;
            _hasDocumentation = hasDocumentation;
            _documentation = documentation;
            _lookupPath = lookupPath;
            _modelSourceFile = modelSourceFile;
            _sourceFiles = sourceFiles ?? ImmutableList<string>.Empty;
            _name = name;
            _ns = ns;
            _hasParameters = hasParameters;
            _isVoid = isVoid;
            _parentPath = parentPath;
            _security = security;
            _returnType = returnType;
            _parameters = parameters ?? ImmutableList<CsParameter>.Empty;
            _invokeMethod = invokeMethod;
            _beginInvokeMethod = beginInvokeMethod;
            _endInvokeMethod = endInvokeMethod;
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
        ///     Flag the determines if this item supports generics
        /// </summary>
        public bool IsGeneric => _isGeneric;

        /// <summary>
        ///     List of the generic parameters assigned.
        /// </summary>
        public IReadOnlyList<CsGenericParameter> GenericParameters => _genericParameters;

        /// <summary>
        ///     List of the strong types that are implemented for each generic parameter. This will be an empty List when there is no generic types implemented.
        /// </summary>
        public IReadOnlyList<CsType> GenericTypes => _genericTypes;

        /// <summary>
        ///     List of the generic parameters assigned.
        /// </summary>
        IReadOnlyList<IDotNetGenericParameter> IDotNetGeneric.GenericParameters => GenericParameters;

        /// <summary>
        ///     Flag that determines if the generics implementation has strong types passed in to the generics implementation.
        /// </summary>
        public bool HasStrongTypesInGenerics => _hasStrongTypesInGenerics;

        /// <summary>
        ///     Enumeration of the strong types that are implemented for each generic parameter. This will be an empty list when there is no generic types implemented.
        /// </summary>
        IReadOnlyList<IDotNetType> IDotNetGeneric.GenericTypes => GenericTypes;

        /// <summary>
        ///     Flag that determines if the model has code level documentation assigned to it.
        /// </summary>
        public bool HasDocumentation => _hasDocumentation;

        /// <summary>
        ///     Documentation that has been assigned to this model.
        /// </summary>
        public string Documentation => _documentation;

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
        ///     The name assigned to the this item.
        /// </summary>
        public string Name => _name;

        /// <summary>
        ///     The namespace the delegate is assigned to.
        /// </summary>
        public string Namespace => _ns;

        /// <summary>
        ///     The security scope that has been assigned to this item.
        /// </summary>
        public CsSecurity Security => _security;

        /// <summary>
        ///     The type information about the return type assigned to the delegate.
        /// </summary>
        public CsType ReturnType => _returnType;

        /// <summary>
        ///     List of the parameters that have been assigned to the delegate. If HasParameters property is set to false this will be an empty list.
        /// </summary>
        public IReadOnlyList<CsParameter> Parameters => _parameters;

        /// <summary>
        /// The invoke delegate definition for this delegate.
        /// </summary>
        public CsMethod InvokeMethod => _invokeMethod;

        /// <summary>
        /// The begin invoke delegate definition for this delegate.
        /// </summary>
        public CsMethod BeginInvokeMethod => _beginInvokeMethod;

        /// <summary>
        /// The end invoke delegate definition for this delegate.
        /// </summary>
        public CsMethod EndInvokeMethod => _endInvokeMethod;

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsDelegate"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsDelegate"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode);


        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsDelegate"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsDelegate"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddAfterAsync(string sourceCode);


        /// <summary>
        /// Deletes the definition of the delegate from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the delegate is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the delegate has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync(string sourceDocument);

        /// <summary>
        /// Deletes the definition of the delegate from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the delegate has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync();


        /// <summary>
        /// Gets the starting and ending locations within the document where the delegate is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the delegate defined in.</param>
        /// <returns>The source location for the delegate.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations within the document where the delegate is located.
        /// </summary>
        /// <returns>The source location for the delegate.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetSourceLocationAsync();

        /// <summary>
        /// Replaces the current delegate with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the current delegate with the provided source code.
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
        public CsModel GetModel(string lookupPath) => LookupModel(lookupPath);

        /// <inheritdoc/>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode, bool ignoreLeadingModelsAndDocs);

        /// <summary>
        ///     The security scope that has been assigned to this item.
        /// </summary>
        DotNetSecurity IDotNetDelegate.Security =>(DotNetSecurity)(int) _security;

        /// <summary>
        ///     The type information about the return type assigned to the delegate.
        /// </summary>
        IDotNetType IDotNetDelegate.ReturnType => ReturnType;

        /// <summary>
        ///     Flag that determines if the delegate has parameters assigned to it.
        /// </summary>
        public bool HasParameters => _hasParameters;

        /// <summary>
        ///     List of the parameters that have been assigned to the delegate. If HasParameters property is set to false this will be an empty list.
        /// </summary>
        IReadOnlyList<IDotNetParameter> IDotNetDelegate.Parameters => Parameters;

        /// <summary>
        /// The invoke delegate definition for this delegate.
        /// </summary>
        IDotNetMethod IDotNetDelegate.InvokeMethod => InvokeMethod;

        /// <summary>
        /// The begin invoke delegate definition for this delegate.
        /// </summary>
        IDotNetMethod IDotNetDelegate.BeginInvokeMethod => BeginInvokeMethod;

        /// <summary>
        /// The end invoke delegate definition for this delegate.
        /// </summary>
        IDotNetMethod IDotNetDelegate.EndInvokeMethod => EndInvokeMethod;

        /// <summary>
        /// Flag that determines if the delegate return is a void.
        /// </summary>
        public bool IsVoid => _isVoid;

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
