//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that implements the base implement for all models that support members.
    /// </summary>
    public abstract class CsContainerWithNestedContainers:CsContainer,ICsNestedContainers,ICsNestedModel
    {
        #region Property backing fields
        private readonly bool _isNested;
        private readonly CsNestedType _nestedType;
        private readonly IReadOnlyList<ICsNestedModel> _nestedModels;

        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsContainerWithNestedContainers"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="modelType">The type of code model created.</param>
        /// <param name="members">The members assigned to this container.</param>
        /// <param name="isNested">Flag that determines if the container type is nested in another type definition.</param>
        /// <param name="nestedType">Enumeration of the type of nesting the container is.</param>
        /// <param name="nestedModels">List of nested models assigned to this container. This is an optional parameter and can be null</param>
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
        protected CsContainerWithNestedContainers(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, CsModelType modelType,
            IReadOnlyList<CsAttribute> attributes, bool isGeneric, bool hasStrongTypesInGenerics, 
            IReadOnlyList<CsGenericParameter> genericParameters, IReadOnlyList<CsType> genericTypes, string modelSourceFile,
            IReadOnlyList<string> sourceFiles, bool hasDocumentation, string documentation, string lookupPath,
            string name, string ns, string parentPath, CsContainerType containerType, CsSecurity security,
            IReadOnlyList<CsInterface> inheritedInterfaces, IReadOnlyList<CsMember> members, bool isNested, CsNestedType nestedType, IReadOnlyList<ICsNestedModel> nestedModels = null,
            string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            :base(isLoaded, hasErrors, loadedFromSource, language, modelType, attributes, isGeneric, hasStrongTypesInGenerics, genericParameters, 
                genericTypes, modelSourceFile, sourceFiles, hasDocumentation, documentation, lookupPath, name, ns, parentPath, containerType, security, 
                inheritedInterfaces, members, sourceDocument, modelStore, modelErrors)
        {
            _isNested = isNested;
            _nestedType = nestedType;
            _nestedModels = nestedModels ?? ImmutableList<ICsNestedModel>.Empty;
        }

        /// <summary>
        /// Models that are nested in the implementation of this container.
        /// </summary>
        public IReadOnlyList<ICsNestedModel> NestedModels => _nestedModels;

        /// <summary>
        /// Classes that are nested in this container.
        /// </summary>
        public IReadOnlyList<CsClass> NestedClasses =>
            _nestedModels.Where(n => n.NestedType == CsNestedType.Class).Cast<CsClass>().ToImmutableList();

        /// <summary>
        /// Interfaces that are nested in this container.
        /// </summary>
        public IReadOnlyList<CsInterface> NestedInterfaces =>
            _nestedModels.Where(n => n.NestedType == CsNestedType.Interface).Cast<CsInterface>().ToImmutableList();

        /// <summary>
        /// Structures that are nested in this container.
        /// </summary>
        public IReadOnlyList<CsStructure> NestedStructures =>
            _nestedModels.Where(n => n.NestedType == CsNestedType.Structure).Cast<CsStructure>().ToImmutableList();

        /// <summary>
        /// Enums that are nested in this container.
        /// </summary>
        public IReadOnlyList<CsEnum> NestedEnums =>
            _nestedModels.Where(n => n.NestedType == CsNestedType.Enum).Cast<CsEnum>().ToImmutableList();

        /// <summary>
        /// Models that are nested in the implementation of this container.
        /// </summary>
        IReadOnlyList<IDotNetNestedModel> IDotNetNestedContainers.NestedModels => NestedModels;

        /// <summary>
        /// Classes that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetClass> IDotNetNestedContainers.NestedClasses => NestedClasses;

        /// <summary>
        /// Interfaces that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetInterface> IDotNetNestedContainers.NestedInterfaces => NestedInterfaces;

        /// <summary>
        /// Structures that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetStructure> IDotNetNestedContainers.NestedStructures => NestedStructures;

        /// <summary>
        /// Enums that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetEnum> IDotNetNestedContainers.NestedEnums => NestedEnums;

        /// <summary>
        /// Identifies the type of model that has been nested.
        /// </summary>
        DotNetNestedType IDotNetNestedModel.NestedType => (DotNetNestedType)_nestedType;

        /// <summary>
        /// Identifies the type of model that has been nested.
        /// </summary>
        public CsNestedType NestedType => _nestedType;

        /// <summary>
        /// Flag that determines if this model is nested in a parent model.
        /// </summary>
        public bool IsNested => _isNested;

    }
}
