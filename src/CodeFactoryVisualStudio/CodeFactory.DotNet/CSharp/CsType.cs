//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents the definition of a type.
    /// </summary>
    public abstract class CsType:CsModel,ICsType
    {
        #region Property backing fields
        private readonly bool _isGeneric;
        private readonly bool _hasStrongTypesInGenerics;
        private readonly IReadOnlyList<CsGenericParameter> _genericParameters;
        private readonly IReadOnlyList<CsType> _genericTypes;
        private readonly string _name;
        private readonly string _ns;
        private readonly bool _isWellKnownType;
        private readonly string _valueTypeDefaultValue;
        private readonly bool _isValueType;
        private readonly bool _supportsDisposable;
        private readonly bool _isInterface;
        private readonly bool _isStructure;
        private readonly bool _isClass;
        private readonly bool _isArray;
        private readonly IReadOnlyList<int> _arrayDimensions;
        private readonly bool _isGenericPlaceHolder;
        private readonly bool _isEnum;
        private readonly bool _isDelegate;
        private readonly bool _isTuple;
        private readonly IReadOnlyList<CsTupleTypeParameter> _tupleTypes;
        private readonly CsKnownLanguageType _wellKnownType;
        #endregion


        /// <summary>
        /// Constructor for the <see cref="CsType"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="wellKnownType">The well known type from the language if it is well known.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        /// <param name="isGeneric">Flag that determines if the type is generic.</param>
        /// <param name="hasStrongTypesInGenerics">Flag that determines if the generics are strong types or placeholders.</param>
        /// <param name="genericParameters">Generic parameters assigned to the type.</param>
        /// <param name="genericTypes">The type definitions for the generic implementation.</param>
        /// <param name="name">The name of the type.</param>
        /// <param name="ns">The namespace the type belongs to.</param>
        /// <param name="isWellKnownType">Is the type one of the well known types for the language.</param>
        /// <param name="valueTypeDefaultValue">The default value if the type is a value type.</param>
        /// <param name="isValueType">Flag that determines if it is a value type.</param>
        /// <param name="supportsDisposable">Flag that determines if the type implements <see cref="IDisposable"/> interface.</param>
        /// <param name="isInterface">Flag that determines if the type is an interface definition.</param>
        /// <param name="isStructure">Flag that determines if the type is a structure definition.</param>
        /// <param name="isClass">Flag that determines if the type is a class definition.</param>
        /// <param name="isArray">Flag that determines if the type is also an array.</param>
        /// <param name="arrayDimensions">The dimensions assigned to the array.</param>
        /// <param name="isGenericPlaceHolder">Flag that determines if the type is a generic place holder definition.</param>
        /// <param name="isEnum">Flag that determines if the type is an enumeration.</param>
        /// <param name="isDelegate">Flag that determines if the type is a delegate definition.</param>
        /// <param name="isTuple">Flag that determines if the type is a tuple.</param>
        /// <param name="tupleTypes">The type information for each part of the tuple.</param>
        protected CsType(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, bool isGeneric,
            bool hasStrongTypesInGenerics, IReadOnlyList<CsGenericParameter> genericParameters, IReadOnlyList<CsType> genericTypes,
            string name, string ns, bool isWellKnownType, string valueTypeDefaultValue, bool isValueType, bool supportsDisposable,
            bool isInterface, bool isStructure, bool isClass, bool isArray, IReadOnlyList<int> arrayDimensions, bool isGenericPlaceHolder, 
            bool isEnum, bool isDelegate, bool isTuple, IReadOnlyList<CsTupleTypeParameter> tupleTypes, CsKnownLanguageType wellKnownType,
            string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Type, sourceDocument, modelStore, modelErrors)
        {
            _isGeneric = isGeneric;
            _hasStrongTypesInGenerics = hasStrongTypesInGenerics;
            _genericParameters = genericParameters ?? ImmutableList<CsGenericParameter>.Empty;
            _genericTypes = genericTypes ?? ImmutableList<CsType>.Empty;
            _name = name;
            _ns = ns;
            _isWellKnownType = isWellKnownType;
            _valueTypeDefaultValue = valueTypeDefaultValue;
            _isValueType = isValueType;
            _supportsDisposable = supportsDisposable;
            _isInterface = isInterface;
            _isStructure = isStructure;
            _isClass = isClass;
            _isArray = isArray;
            _arrayDimensions = arrayDimensions ?? ImmutableList<int>.Empty;
            _isGenericPlaceHolder = isGenericPlaceHolder;
            _isEnum = isEnum;
            _isDelegate = isDelegate;
            _isTuple = isTuple;
            _tupleTypes = tupleTypes ?? ImmutableList<CsTupleTypeParameter>.Empty;
            _wellKnownType = wellKnownType;
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
        ///     The name of the type.
        /// </summary>
        public string Name => _name;

        /// <summary>
        ///     The namespace the type belongs to.
        /// </summary>
        public string Namespace => _ns;

        /// <summary>
        ///     Flag that determines if the type is one of the well know data types of the language.
        /// </summary>
        public bool IsWellKnownType => _isWellKnownType;

        /// <summary>
        ///     Enumeration of the target well known type this type represents.
        /// </summary>
        public CsKnownLanguageType WellKnownType => _wellKnownType;

        /// <summary>
        /// List of the types that are implemented in the Tuple. This will an empty list if the type is not a tuple.
        /// </summary>
        public IReadOnlyList<CsTupleTypeParameter> TupleTypes => _tupleTypes;

        /// <summary>
        ///     Enumeration of the target well known type this type represents.
        /// </summary>
        WellKnownLanguageType IDotNetType.WellKnownType => (WellKnownLanguageType) (int) _wellKnownType;

        /// <summary>
        /// The default value for well known value data types. This will be null if the value is not a well known value type.
        /// </summary>
        public string ValueTypeDefaultValue => _valueTypeDefaultValue;

        /// <summary>
        ///     Flag that determines if the type is a value type.
        /// </summary>
        public bool IsValueType => _isValueType;

        /// <summary>
        ///     Flag that determines if the type supports the interface <see cref="IDisposable"/>.
        /// </summary>
        public bool SupportsDisposable => _supportsDisposable;

        /// <summary>
        ///     Flag that determines if the type is an interface.
        /// </summary>
        public bool IsInterface => _isInterface;

        /// <summary>
        /// Flag that determines if the type is a structure.
        /// </summary>
        public bool IsStructure => _isStructure;

        /// <summary>
        /// Flag that determines if the type is a class.
        /// </summary>
        public bool IsClass => _isClass;

        /// <summary>
        ///     Flag that determines if the type is an array of the target type.
        /// </summary>
        public bool IsArray => _isArray;

        /// <summary>
        /// Gets a list of the dimensions that are assigned to the array. This will contain more then one value if the array is a jagged array. This will be empty if the type is not an array.
        /// </summary>
        public IReadOnlyList<int> ArrayDimensions => _arrayDimensions;

        /// <summary>
        /// Flag that determines if the type is a generic place holder definition.
        /// </summary>
        public bool IsGenericPlaceHolder => _isGenericPlaceHolder;

        /// <summary>
        /// Flag that determines if the type is a enumeration.
        /// </summary>
        public bool IsEnum => _isEnum;

        /// <summary>
        /// Flag that determines if the type is a delegate.
        /// </summary>
        public bool IsDelegate => _isDelegate;

        /// <summary>
        /// Flag that determine if the type is a Tuple
        /// </summary>
        public bool IsTuple => _isTuple;

        /// <summary>
        /// List of the types that are implemented in the Tuple. This will an empty list if the type is not a tuple.
        /// </summary>
        IReadOnlyList<IDotNetTupleTypeParameter> IDotNetType.TupleTypes => TupleTypes;

        /// <summary>
        /// Logic to load the full model data for an enumeration.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an enumeration.</returns>
        protected abstract CsEnum GetEnumModelData();

        /// <summary>
        /// Loads the full <see cref="IDotNetEnum"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an enumeration.</returns>
        IDotNetEnum IDotNetType.GetEnumModel() => GetEnumModelData();
       

        /// <summary>
        /// Loads the full <see cref="ICsEnum"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an enumeration.</returns>
        public CsEnum GetEnumModel() => GetEnumModelData();

        /// <summary>
        /// Loads the full <see cref="ICsDelegate"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a delegate.</returns>
        protected abstract CsDelegate GetDelegateModelData();

        /// <summary>
        /// Loads the full <see cref="ICsDelegate"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a delegate.</returns>
        public CsDelegate GetDelegateModel() => GetDelegateModelData();
        
        /// <summary>
        /// Loads the full <see cref="IDotNetDelegate"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a delegate.</returns>
        IDotNetDelegate IDotNetType.GetDelegateModel() => GetDelegateModelData();

        /// <summary>
        /// Loads the full <see cref="ICsClass"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a class.</returns>
        protected abstract CsClass GetClassModelData();

        /// <summary>
        /// Loads the full <see cref="ICsClass"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a class.</returns>
        public CsClass GetClassModel() => GetClassModelData();
        
        /// <summary>
        /// Loads the full <see cref="IDotNetClass"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a class.</returns>
        IDotNetClass IDotNetType.GetClassModel() => GetClassModelData();

        /// <summary>
        /// Loads the full <see cref="ICsInterface"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an interface.</returns>
        protected abstract CsInterface GetInterfaceModelData();

        /// <summary>
        /// Loads the full <see cref="CsInterface"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an interface.</returns>
        public CsInterface GetInterfaceModel() => GetInterfaceModelData();
        
        /// <summary>
        /// Loads the full <see cref="IDotNetInterface"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an interface.</returns>
        IDotNetInterface IDotNetType.GetInterfaceModel() => GetInterfaceModelData();

        /// <summary>
        /// Loads the full <see cref="ICsStructure"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a structure.</returns>
        protected abstract CsStructure GetStructureModelData();

        /// <summary>
        /// Loads the full <see cref="ICsStructure"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a structure.</returns>
        public CsStructure GetStructureModel() => GetStructureModelData();
        
        /// <summary>
        /// Loads the full <see cref="IDotNetStructure"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a structure.</returns>
        IDotNetStructure IDotNetType.GetStructureModel() => GetStructureModelData();

    }
}
