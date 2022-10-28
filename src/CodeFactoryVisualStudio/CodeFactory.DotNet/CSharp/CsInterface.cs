//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents in definition of an interface.
    /// </summary>
    public abstract class CsInterface:CsContainer,ICsInterface
    {
        /// <summary>
        /// Constructor for the <see cref="CsInterface"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="members">The members assigned to this container.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="isGeneric">Flag that determines if the container is a generic definition.</param>
        /// <param name="hasStrongTypesInGenerics">Flag that determines if the generics use strong type definitions.</param>
        /// <param name="genericParameters">Generic parameters assigned to the container.</param>
        /// <param name="genericTypes">Target types for the generic parameters assigned to the container.</param>
        /// <param name="modelSourceFile">The source file the model was generated from.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this model is defined in.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="ns">The namespace the container belongs to.</param>
        /// <param name="parentPath">The fully qualified lookup path for the parent model to this one.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        /// <param name="inheritedInterfaces">The interfaces that are inherited by this container.</param>
        protected CsInterface(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<CsAttribute> attributes, bool isGeneric, 
            bool hasStrongTypesInGenerics, IReadOnlyList<CsGenericParameter> genericParameters,
            IReadOnlyList<CsType> genericTypes, string modelSourceFile, IReadOnlyList<string> sourceFiles, bool hasDocumentation, 
            string documentation, string lookupPath, string name, string ns, string parentPath, 
             CsSecurity security, IReadOnlyList<CsInterface> inheritedInterfaces,
            IReadOnlyList<CsMember> members, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Interface,attributes, 
                isGeneric, hasStrongTypesInGenerics, genericParameters, genericTypes,modelSourceFile, sourceFiles, hasDocumentation, 
                documentation, lookupPath, name, ns, parentPath, CsContainerType.Interface, security, inheritedInterfaces, 
                members, sourceDocument, modelStore, modelErrors)
        {
            //Intentionally blank
        }
    }
}
