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
    /// Data model that implements the base implement for all models that support members.
    /// </summary>
    public abstract class CsContainer:CsModel,ICsContainer
    {
        #region Property backing fields
        private readonly IReadOnlyList<CsAttribute> _attributes;
        private readonly bool _isGeneric;
        private readonly bool _hasStrongTypesInGenerics;
        private readonly IReadOnlyList<CsGenericParameter> _genericParameters;
        private readonly IReadOnlyList<CsType> _genericTypes;
        private readonly IReadOnlyList<string> _sourceFiles;
        private readonly bool _hasDocumentation;
        private readonly string _documentation;
        private readonly string _lookupPath;
        private readonly string _name;
        private readonly string _ns;
        private readonly string _parentPath;
        private readonly CsContainerType _containerType;
        private readonly CsSecurity _security;
        private readonly IReadOnlyList<CsInterface> _inheritedInterfaces;
        private readonly IReadOnlyList<CsMember> _members;

        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsContainer"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="modelType">The type of code model created.</param>
        /// <param name="members">The members assigned to this container.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="isGeneric">Flag that determines if the container is a generic definition.</param>
        /// <param name="hasStrongTypesInGenerics">Flag that determines if the generics use strong type definitions.</param>
        /// <param name="genericParameters">Generic parameters assigned to the container.</param>
        /// <param name="genericTypes">Target types for the generic parameters assigned to the container.</param>
        /// <param name="modelSourceFile">The source file the model was loaded from.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this model is defined in.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="ns">The namespace the container belongs to.</param>
        /// <param name="parentPath">The fully qualified lookup path for the parent model to this one.</param>
        /// <param name="containerType">The type of container this model represents.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        /// <param name="inheritedInterfaces">The interfaces that are inherited by this container.</param>
        protected CsContainer(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, CsModelType modelType,
            IReadOnlyList<CsAttribute> attributes, bool isGeneric, bool hasStrongTypesInGenerics, 
            IReadOnlyList<CsGenericParameter> genericParameters, IReadOnlyList<CsType> genericTypes, string modelSourceFile,
            IReadOnlyList<string> sourceFiles, bool hasDocumentation, string documentation, string lookupPath,
            string name, string ns, string parentPath, CsContainerType containerType, CsSecurity security,
            IReadOnlyList<CsInterface> inheritedInterfaces, IReadOnlyList<CsMember> members,
            string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, modelType, sourceDocument, modelStore, modelErrors)
        {
            _attributes = attributes ?? ImmutableList<CsAttribute>.Empty;
            _isGeneric = isGeneric;
            _hasStrongTypesInGenerics = hasStrongTypesInGenerics;
            _genericParameters = genericParameters ?? ImmutableList<CsGenericParameter>.Empty;
            _genericTypes = genericTypes ?? ImmutableList<CsType>.Empty;
            _modelSourceFile = modelSourceFile;
            _sourceFiles = sourceFiles ?? ImmutableList<string>.Empty;
            _hasDocumentation = hasDocumentation;
            _documentation = documentation;
            _lookupPath = lookupPath;
            _name = name;
            _ns = ns;
            _parentPath = parentPath;
            _containerType = containerType;
            _security = security;
            _inheritedInterfaces = inheritedInterfaces ?? ImmutableList<CsInterface>.Empty;
            _members = members ?? ImmutableList<CsMember>.Empty;
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
        /// The type of container model that has been implemented.
        /// </summary>
        DotNetContainerType IDotNetContainer.ContainerType => (DotNetContainerType)(int) _containerType;

        /// <summary>
        ///     The security scope assigned to the container.
        /// </summary>
        public CsSecurity Security => _security;

        /// <summary>
        ///     List of the interfaces that are inherited by this container.
        /// </summary>
        public IReadOnlyList<CsInterface> InheritedInterfaces => _inheritedInterfaces;

        /// <summary>
        ///     List of the members that are implemented in this container.
        /// </summary>
        public IReadOnlyList<CsMember> Members => _members;

        /// <summary>
        ///     List of the methods that are implemented in this container.
        /// </summary>
        public IReadOnlyList<CsMethod> Methods => _members.Where(m => m.MemberType == CsMemberType.Method)
                                                      .Cast<CsMethod>().Where(m => m.MethodType == CsMethodType.Member | m.MethodType == CsMethodType.PartialImplementation | m.MethodType == CsMethodType.PartialDefinition)
                                                      .ToImmutableList() ?? ImmutableList<CsMethod>.Empty;

        /// <summary>
        ///     List of the properties that are implemented in this container.
        /// </summary>
        public IReadOnlyList<CsProperty> Properties =>
            _members.Where(m => m.MemberType == CsMemberType.Property).Cast<CsProperty>()
                .ToImmutableList() ?? ImmutableList<CsProperty>.Empty;

        /// <summary>
        ///     Enumeration of the events assigned to this container. If HasEvents is false this will be null.
        /// </summary>
        public IReadOnlyList<CsEvent> Events => _members.Where(m => m.MemberType == CsMemberType.Event).Cast<CsEvent>()
                                                    .ToImmutableList() ?? ImmutableList<CsEvent>.Empty;

        /// <summary>
        /// The source code syntax that is stored in the body of the container model. This will be null if the container was not loaded from source code.
        /// </summary>
        public abstract Task<string> GetBodySyntaxAsync();

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsContainer"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsContainer"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode);


        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsContainer"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsContainer"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddAfterAsync(string sourceCode);

        /// <summary>
        /// Adds the source code inside of the container at the beginning of where members are defined in the container.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddToBeginningAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code inside of the container at the beginning of where members are defined in the container.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        public abstract Task<CsSource> AddToBeginningAsync(string sourceCode);

        /// <summary>
        /// Adds the source code inside of the container at the end of where members are defined in the container.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddToEndAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code inside of the container at the end of where members are defined in the container.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        public abstract Task<CsSource> AddToEndAsync(string sourceCode);

        /// <summary>
        /// Deletes the definition of the container from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the container is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the container has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> DeleteAsync(string sourceDocument);

        /// <summary>
        /// Deletes the definition of the container from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the container has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync();

        /// <summary>
        /// Gets the starting and ending locations within the document where the container is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the container defined in.</param>
        /// <returns>The source location for the container.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations within the document where the container is located.
        /// </summary>
        /// <returns>The source location for the container.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetSourceLocationAsync();

        /// <summary>
        /// Gets the starting and ending locations of the body located in the container.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the container defined in.</param>
        /// <returns>The source location in the container.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<ISourceLocation> GetBodySourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations of the body located in the container.
        /// </summary>
        /// <returns>The source location in the container.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        public abstract Task<ISourceLocation> GetBodySourceLocationAsync();

        /// <summary>
        /// Replaces the current container with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the current container with the provided source code.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> ReplaceAsync(string sourceCode);

        /// <inheritdoc/>
        public abstract Task<CsSource> AddBeforeAsync(string sourceCode, bool ignoreLeadingModelsAndDocs);
        
        /// <summary>
        /// The type of container model that has been implemented.
        /// </summary>
        public CsContainerType ContainerType => _containerType;

        /// <summary>
        ///     The name of the container.
        /// </summary>
        public string Name => _name;

        /// <summary>
        ///     The namespace the container objects belongs to.
        /// </summary>
        public string Namespace => _ns;

        /// <summary>
        ///     The security scope assigned to the container.
        /// </summary>
        DotNetSecurity IDotNetContainer.Security => (DotNetSecurity)(int) _security;

        /// <summary>
        ///     List of the interfaces that are inherited by this container.
        /// </summary>
        IReadOnlyList<IDotNetInterface> IDotNetContainer.InheritedInterfaces => _inheritedInterfaces;

        /// <summary>
        ///     List of the members that are implemented in this container.
        /// </summary>
        IReadOnlyList<IDotNetMember> IDotNetContainer.Members => Members;

        /// <summary>
        ///     List of the methods that are implemented in this container.
        /// </summary>
        IReadOnlyList<IDotNetMethod> IDotNetContainer.Methods => Methods;

        /// <summary>
        ///     List of the properties that are implemented in this container.
        /// </summary>
        IReadOnlyList<IDotNetProperty> IDotNetContainer.Properties => Properties;

        /// <summary>
        ///     Enumeration of the events assigned to this container. If HasEvents is false this will be null.
        /// </summary>
        IReadOnlyList<IDotNetEvent> IDotNetContainer.Events => Events;

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
