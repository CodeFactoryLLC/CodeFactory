//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2022 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents source code.
    /// </summary>
    public abstract class CsSource:CsModel,ICsSource
    {
        #region Property backing fields
        private readonly string _lookupPath;
        private readonly string _parentPath;
        private readonly IReadOnlyList<CsUsingStatement> _namespaceReferences;
        private readonly IReadOnlyList<CsInterface> _interfaces;
        private readonly IReadOnlyList<CsClass> _classes;
        private readonly IReadOnlyList<CsStructure> _structures;
        private readonly IReadOnlyList<CsRecord> _records;
        private readonly IReadOnlyList<CsRecordStructure> _recordsStructure;
        private readonly IReadOnlyList<CsDelegate> _delegates;
        private readonly IReadOnlyList<CsEnum> _enums;
        private readonly IReadOnlyList<CsNamespace> _namespaces;
        private readonly bool _hostedInProject;
        private readonly string _projectName;

        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsSource"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="namespaces">The namespaces that are defined in this source.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        /// <param name="lookupPath">The fully qualified name of the model to be used with the model store.</param>
        /// <param name="sourceDocument">The fully qualified path to the source document that loaded this model.</param>
        /// <param name="parentPath">The fully qualified path to the parent model of this model.</param>
        /// <param name="namespaceReferences">The namespace reference in the source.</param>
        /// <param name="interfaces">The interfaces that are define in this source.</param>
        /// <param name="classes">The classes that are defined in this source.</param>
        /// <param name="structures">The structures that are defined in this source.</param>
        /// <param name="records">The records that are defined in this source.</param>
        /// <param name="recordStructures">The record structures that are defined in this source.</param>
        /// <param name="delegates">The delegates that are defined in this source.</param>
        /// <param name="enums">The enumerations defined in this source.</param>

        protected CsSource(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, string lookupPath, 
            string sourceDocument, string parentPath, IReadOnlyList<CsUsingStatement> namespaceReferences,
            IReadOnlyList<CsInterface> interfaces, IReadOnlyList<CsClass> classes, IReadOnlyList<CsStructure> structures, 
            IReadOnlyList<CsRecord> records, IReadOnlyList<CsRecordStructure> recordStructures,
            IReadOnlyList<CsDelegate> delegates, IReadOnlyList<CsEnum> enums, IReadOnlyList<CsNamespace> namespaces, bool hostedInProject,string projectName,
            ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Source, sourceDocument, modelStore, modelErrors)
        {
            _lookupPath = lookupPath;
            _parentPath = parentPath;
            _namespaceReferences = namespaceReferences ?? ImmutableList<CsUsingStatement>.Empty;
            _interfaces = interfaces ?? ImmutableList<CsInterface>.Empty;
            _classes = classes ?? ImmutableList<CsClass>.Empty;
            _structures = structures ?? ImmutableList<CsStructure>.Empty;
            _records = records ?? ImmutableList<CsRecord>.Empty;
            _recordsStructure = recordStructures ?? ImmutableList<CsRecordStructure>.Empty;
            _delegates = delegates ?? ImmutableList<CsDelegate>.Empty;
            _enums = enums ?? ImmutableList<CsEnum>.Empty;
            _namespaces = namespaces ?? ImmutableList<CsNamespace>.Empty;
            _hostedInProject = hostedInProject;
            _projectName = projectName; 
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
        /// The namespaces that are used as references to access other libraries not hosted in the source document.
        /// </summary>
        public IReadOnlyList<CsUsingStatement> NamespaceReferences => _namespaceReferences;

        /// <summary>
        /// The interfaces that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsInterface> Interfaces => _interfaces;

        /// <summary>
        /// The classes that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsClass> Classes => _classes;

        /// <summary>
        /// The structures that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsStructure> Structures => _structures;

        /// <summary>
        /// The records that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsRecord> Records => _records;

        /// <summary>
        /// The record structures that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsRecordStructure> RecordStructures => _recordsStructure;

        /// <summary>
        /// The records that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetRecord> IDotNetSource.Records => Records;

        /// <summary>
        /// The record structures that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetRecordStructure> IDotNetSource.RecordStructures => RecordStructures;

        /// <summary>
        /// The delegates that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsDelegate> Delegates => _delegates;

        /// <summary>
        /// The enumerations that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsEnum> Enums => _enums;

        /// <summary>
        /// The namespaces that were defined in the source.
        /// </summary>
        public IReadOnlyList<CsNamespace> Namespaces => _namespaces;

        /// <summary>
        /// Flag that determines if the source code was hosted in a project.
        /// </summary>
        public bool HostedInProject => _hostedInProject;

        /// <summary>
        /// The name of the project the source is hosted in. This will be null if this source is not hosted in a project.
        /// </summary>
        public string ProjectName => _projectName;

        /// <summary>
        /// Adds the source code to the beginning of the <see cref="ICsSource"/> model.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddToBeginningAsync(string sourceCode);

        /// <summary>
        /// Adds the source code the end of the <see cref="ICsSource"/> model.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> AddToEndAsync(string sourceCode);

        /// <summary>
        /// Deletes the content from the <see cref="ICsSource"/> model.
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the delegate has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> DeleteAsync();

        /// <summary>
        /// Replaces the content of the <see cref="ICsSource"/> model.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        public abstract Task<CsSource> ReplaceAsync(string sourceCode);

        /// <summary>
        /// The namespaces that are used as references to access other libraries not hosted in the source document.
        /// </summary>
        IReadOnlyList<IDotNetNamespaceReference> IDotNetSource.NamespaceReferences => NamespaceReferences;

        /// <summary>
        /// The interfaces that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetInterface> IDotNetSource.Interfaces => Interfaces;

        /// <summary>
        /// The classes that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetClass> IDotNetSource.Classes => Classes;

        /// <summary>
        /// The structures that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetStructure> IDotNetSource.Structures => Structures;

        /// <summary>
        /// The delegates that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetDelegate> IDotNetSource.Delegates => Delegates;

        /// <summary>
        /// The enumerations that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetEnum> IDotNetSource.Enums => Enums;

        /// <summary>
        /// The namespaces that were defined in the source.
        /// </summary>
        IReadOnlyList<IDotNetNamespace> IDotNetSource.Namespaces => Namespaces;

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        public CsModel Parent => GetModel(_parentPath);
    }
}
