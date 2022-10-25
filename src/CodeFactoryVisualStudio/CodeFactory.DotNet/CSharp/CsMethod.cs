//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2022 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents a method definition.
    /// </summary>
    public abstract class CsMethod:CsMember,ICsMethod
    {
        #region Property backing fields
        private readonly bool _isGeneric;
        private readonly bool _hasStrongTypesInGenerics;
        private readonly IReadOnlyList<CsGenericParameter> _genericParameters;
        private readonly IReadOnlyList<CsType> _genericTypes;
        private readonly bool _hasParameters;
        private readonly bool _isAbstract;
        private readonly bool _isVirtual;
        private readonly bool _isSealed;
        private readonly bool _isOverride;
        private readonly bool _isStatic;
        private readonly bool _isVoid;
        private readonly bool _isAsync;
        private readonly bool _isExtension;
        private readonly CsMethodType _methodType;
        private readonly CsType _returnType;
        private readonly IReadOnlyList<CsParameter> _parameters;
        private readonly SyntaxType _contentSyntax;

        #endregion


        /// <summary>
        /// Constructor for the <see cref="CsMethod"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="parameters">The parameters assigned to the method.</param>
        /// <param name="contentSyntax">How syntax is stored in the method.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this member is defined in.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="parentPath">THe fully qualified lookup path for the parent model to this one.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        /// <param name="isGeneric">Flag that determines if the method is a generic definition.</param>
        /// <param name="hasStrongTypesInGenerics">Flag that determines if the generics use strong type definitions.</param>
        /// <param name="genericParameters">Generic parameters assigned to the method.</param>
        /// <param name="genericTypes">Target types for the generic parameters assigned to the method.</param>
        /// <param name="hasParameters">Flag that determines if the method had parameters.</param>
        /// <param name="isAbstract">Flag that determines if the model is abstract.</param>
        /// <param name="isVirtual">Flag that determines if the model is virtual.</param>
        /// <param name="isSealed">Flag that determines if the model is sealed.</param>
        /// <param name="isOverride">Flag that determines if the model is overridden.</param>
        /// <param name="isStatic">Flag that determines if the model is static.</param>
        /// <param name="isVoid">Flag that determines if the return type is void. </param>
        /// <param name="isAsync">Flag that determines if the method has the async keyword assigned.</param>
        /// <param name="isExtension">Flag that determines if the method is an extension method.</param>
        /// <param name="methodType">The type of method that was implemented.</param>
        /// <param name="returnType">The type definition for the return type.</param>
        protected CsMethod(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, 
            IReadOnlyList<CsAttribute> attributes, IReadOnlyList<string> sourceFiles, 
            bool hasDocumentation, string documentation, string lookupPath, string name, string parentPath, 
            CsSecurity security, bool isGeneric, bool hasStrongTypesInGenerics, 
            IReadOnlyList<CsGenericParameter> genericParameters, IReadOnlyList<CsType> genericTypes,
            bool hasParameters, bool isAbstract, bool isVirtual, bool isSealed, bool isOverride, bool isStatic, 
            bool isVoid, bool isAsync, bool isExtension, CsMethodType methodType, CsType returnType,
            IReadOnlyList<CsParameter> parameters, SyntaxType contentSyntax = SyntaxType.Unknown, string sourceDocument = null,
            ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Method,
                attributes, sourceFiles, hasDocumentation, documentation, lookupPath, name, parentPath,
                security, CsMemberType.Method, sourceDocument, modelStore, modelErrors)
        {
            _isGeneric = isGeneric;
            _hasStrongTypesInGenerics = hasStrongTypesInGenerics;
            _genericParameters = genericParameters ?? ImmutableList<CsGenericParameter>.Empty;
            _genericTypes = genericTypes ?? ImmutableList<CsType>.Empty;
            _hasParameters = hasParameters;
            _isAbstract = isAbstract;
            _isVirtual = isVirtual;
            _isSealed = isSealed;
            _isOverride = isOverride;
            _isStatic = isStatic;
            _isVoid = isVoid;
            _isAsync = isAsync;
            _isExtension = isExtension;
            _methodType = methodType;
            _returnType = returnType;
            _parameters = parameters ?? ImmutableList<CsParameter>.Empty;
            _contentSyntax = contentSyntax;
        }

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
        /// Determines the type of method that was loaded into this model.
        /// </summary>
        DotNetMethodType IDotNetMethod.MethodType =>(DotNetMethodType)(int) _methodType;

        /// <summary>
        ///     The type information about the return type assigned to the method. if flag <see cref="IsVoid"/> is true then the return type will be set to null.
        /// </summary>
        public CsType ReturnType => _returnType;

        /// <summary>
        ///     Enumeration of the parameters that have been assigned to the method. If HasParameters property is set to false this will be null.
        /// </summary>
        public IReadOnlyList<CsParameter> Parameters => _parameters;

        /// <summary>
        /// Determines the type of method that was loaded into this model.
        /// </summary>
        public CsMethodType MethodType => _methodType;

        /// <summary>
        ///     The type information about the return type assigned to the method. if flag <see cref="IDotNetMethod.IsVoid"/> is true then the return type will be set to null.
        /// </summary>
        IDotNetType IDotNetMethod.ReturnType => ReturnType;

        /// <summary>
        ///     Flag that determines if the method has parameters assigned to it.
        /// </summary>
        public bool HasParameters => _hasParameters;

        /// <summary>
        ///     Enumeration of the parameters that have been assigned to the method. If HasParameters property is set to false this will be null.
        /// </summary>
        IReadOnlyList<IDotNetParameter> IDotNetMethod.Parameters => Parameters;

        /// <summary>
        ///     Flag that determines if the method has been implemented as abstract.
        /// </summary>
        public bool IsAbstract => _isAbstract;

        /// <summary>
        ///     Flag that determines if the method has been implemented as virtual.
        /// </summary>
        public bool IsVirtual => _isVirtual;

        /// <summary>
        ///     Flag that determines if the method has been sealed.
        /// </summary>
        public bool IsSealed => _isSealed;

        /// <summary>
        ///     Flag that determines if the method has been overridden.
        /// </summary>
        public bool IsOverride => _isOverride;

        /// <summary>
        ///     Flag that determines if this is a static method.
        /// </summary>
        public bool IsStatic => _isStatic;

        /// <summary>
        ///     Flag that determines if the methods return type is void.
        /// </summary>
        public bool IsVoid => _isVoid;

        /// <summary>
        ///     Flag that determines if the method implements the Async keyword.
        /// </summary>
        public bool IsAsync => _isAsync;

        /// <summary>
        ///     Flag that determines if the method is an extension method.
        /// </summary>
        public bool IsExtension => _isExtension;

        /// <inheritdoc />
        public SyntaxType SyntaxContent => _contentSyntax;

        /// <inheritdoc />
        public abstract Task<string> GetBodySyntaxAsync();

        /// <inheritdoc />
        public abstract Task<List<string>> GetBodySyntaxListAsync();

        /// <inheritdoc />
        public abstract Task<string> GetExpressionSyntaxAsync();

        /// <inheritdoc />
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddToBeginningBodySyntaxAsync(string sourceDocument, string sourceCode);

        /// <inheritdoc />
        public abstract Task<CsSource> AddToBeginningBodySyntaxAsync(string sourceCode);

        /// <inheritdoc />
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> AddToEndBodySyntaxAsync(string sourceDocument, string sourceCode);

        /// <inheritdoc />
        public abstract Task<CsSource> AddToEndBodySyntaxAsync(string sourceCode);

        /// <inheritdoc />
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> DeleteBodySyntaxAsync(string sourceDocument);

        /// <inheritdoc />
        public abstract Task<CsSource> DeleteBodySyntaxAsync();

        /// <inheritdoc />
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> ReplaceBodySyntaxAsync(string sourceDocument, string sourceCode);

        /// <inheritdoc />
        public abstract Task<CsSource> ReplaceBodySyntaxAsync(string sourceCode);

        /// <inheritdoc />
        public abstract Task<CsSource> ReplaceExpressionAsync(string sourceCode);

        /// <inheritdoc />
        [Obsolete("No longer support will be removed in later edition, you no longer need to pass the source document.",false)]
        public abstract Task<CsSource> ReplaceExpressionAsync(string sourceDocument, string sourceCode);

    }
}
