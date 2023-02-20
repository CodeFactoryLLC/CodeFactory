//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents a record implementation.
    /// </summary>
    public abstract class CsRecord:CsContainer,ICsRecord
    {
        #region Property backing fields
        private readonly bool _isStatic;
        private readonly bool _isAbstract;
        private readonly bool _isSealed;
        private readonly CsRecord _baseRecord;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsRecord"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="members">The members assigned to this container.</param>
        /// <param name="baseRecord">The record model that is base record of this record.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="isGeneric">Flag that determines if the container is a generic definition.</param>
        /// <param name="hasStrongTypesInGenerics">Flag that determines if the generics use strong type definitions.</param>
        /// <param name="genericParameters">Generic parameters assigned to the container.</param>
        /// <param name="genericTypes">Target types for the generic parameters assigned to the container.</param>
        /// <param name="modelSourceFile">The source code file the model was generated from.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this model is defined in.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="ns">The namespace the container belongs to.</param>
        /// <param name="parentPath">The fully qualified lookup path for the parent model to this one.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        /// <param name="inheritedInterfaces">The interfaces that are inherited by this container.</param>
        /// <param name="isStatic">Flag that determines if the model is static.</param>
        /// <param name="isAbstract">Flag that determines if the model is abstract.</param>
        /// <param name="isSealed">Flag that determines if the model is sealed.</param>
        protected CsRecord(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<CsAttribute> attributes, bool isGeneric, bool hasStrongTypesInGenerics,
            IReadOnlyList<CsGenericParameter> genericParameters, IReadOnlyList<CsType> genericTypes, string modelSourceFile, IReadOnlyList<string> sourceFiles,
            bool hasDocumentation, string documentation, string lookupPath, string name, string ns, string parentPath, 
            CsSecurity security, IReadOnlyList<CsInterface> inheritedInterfaces, IReadOnlyList<CsMember> members,
            bool isStatic, bool isAbstract, bool isSealed, CsRecord baseRecord,string sourceDocument = null, 
            ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Record, attributes, 
                isGeneric, hasStrongTypesInGenerics, genericParameters, genericTypes, modelSourceFile, sourceFiles, hasDocumentation,
                documentation, lookupPath, name, ns, parentPath, CsContainerType.Record, security, inheritedInterfaces, 
                members,sourceDocument, modelStore, modelErrors)
        {
            _isStatic = isStatic;
            _isAbstract = isAbstract;
            _isSealed = isSealed;
            _baseRecord = baseRecord;
        }

        /// <summary>
        /// List of the constructors implemented in this record.
        /// </summary>
        IReadOnlyList<IDotNetMethod> IDotNetRecord.Constructors => Constructors;

        /// <summary>
        /// The destructor implemented in this record.
        /// </summary>
        public CsMethod Destructor => Members.Where(m => m.MemberType == CsMemberType.Method).Cast<CsMethod>()
            .FirstOrDefault(m => m.MethodType == CsMethodType.Destructor);

        /// <summary>
        ///     List of the fields implemented in this record.
        /// </summary>
        public IReadOnlyList<CsField> Fields =>
            Members.Where(m => m.MemberType == CsMemberType.Field).Cast<CsField>().ToImmutableList() ??
            ImmutableList<CsField>.Empty;

        /// <summary>
        ///     The base record assigned to this record. This will be null if HasBase is false.
        /// </summary>
        public CsRecord BaseRecord => _baseRecord;

        /// <summary>
        /// List of the constructors implemented in this record.
        /// </summary>
        public IReadOnlyList<CsMethod> Constructors =>
            Members.Where(m => m.MemberType == CsMemberType.Method).Cast<CsMethod>()
                .Where(m => m.MethodType == CsMethodType.Constructor).ToImmutableList() ??
            ImmutableList<CsMethod>.Empty;

        /// <summary>
        /// The destructor implemented in this record.
        /// </summary>
        IDotNetMethod IDotNetRecord.Destructor => Destructor;

        /// <summary>
        ///     List of the fields implemented in this record.
        /// </summary>
        IReadOnlyList<IDotNetField> IDotNetRecord.Fields => Fields;

        /// <summary>
        ///     The base record assigned to this record. This will be null if HasBase is false.
        /// </summary>
        IDotNetRecord IDotNetRecord.BaseRecord => BaseRecord;

        /// <summary>
        ///     Flag that determines if this record is static.
        /// </summary>
        public bool IsStatic => _isStatic;

        /// <summary>
        ///     Flat that determines if this is an abstract record.
        /// </summary>
        public bool IsAbstract => _isAbstract;

        /// <summary>
        ///     Flag that determines if this record has been sealed.
        /// </summary>
        public bool IsSealed => _isSealed;
    }
}
