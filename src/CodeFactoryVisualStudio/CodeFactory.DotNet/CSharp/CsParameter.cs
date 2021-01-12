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
    /// Data model that represents a parameter definition.
    /// </summary>
    public abstract class CsParameter:CsModel,ICsParameter
    {
        #region Property backing fields
        private readonly IReadOnlyList<CsAttribute> _attributes;
        private readonly string _lookupPath;
        private readonly string _name;
        private readonly bool _isOut;
        private readonly bool _isRef;
        private readonly bool _isParams;
        private readonly bool _isOptional;
        private readonly bool _isGenericParameter;
        private readonly bool _hasDefaultValue;
        private readonly string _parentPath;
        private readonly CsType _parameterType;
        private readonly CsParameterDefaultValue _defaultValue;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsParameter"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="defaultValue">The default value assigned to this parameter.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="attributes">Attributes assigned to this model.</param>
        /// <param name="lookupPath">The fully qualified path of the model that is stored in the model store.</param>
        /// <param name="name">The name of the parameter.</param>
        /// <param name="isOut">Parameter is assigned the out keyword.</param>
        /// <param name="isRef">Parameter is assigned the ref keyword.</param>
        /// <param name="isParams">Parameter supports a parameter array.</param>
        /// <param name="isOptional">Parameter is optional.</param>
        /// <param name="isGenericParameter">Is a generic parameter.</param>
        /// <param name="hasDefaultValue">Parameter has an assigned default value.</param>
        /// <param name="parentPath">The fully qualified path name for the parent model to this model.</param>
        /// <param name="parameterType">The type that this parameter supports.</param>
        protected CsParameter(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<CsAttribute> attributes, string lookupPath, string name, bool isOut, bool isRef, bool isParams, 
            bool isOptional, bool isGenericParameter, bool hasDefaultValue, string parentPath, CsType parameterType,
            CsParameterDefaultValue defaultValue, string sourceDocument = null, ModelStore<ICsModel> modelStore = null,
            IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Parameter, sourceDocument, modelStore, modelErrors)
        {
            _attributes = attributes ?? ImmutableList<CsAttribute>.Empty;
            _lookupPath = lookupPath;
            _name = name;
            _isOut = isOut;
            _isRef = isRef;
            _isParams = isParams;
            _isOptional = isOptional;
            _isGenericParameter = isGenericParameter;
            _hasDefaultValue = hasDefaultValue;
            _parentPath = parentPath;
            _parameterType = parameterType;
            _defaultValue = defaultValue;
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
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        IDotNetModel DotNet.IParent.Parent => Parent;

        /// <summary>
        /// The fully qualified path for this model that can be used when searching the source for the model.
        /// </summary>
        public string LookupPath => _lookupPath;

        /// <summary>
        ///     The name of the parameter.
        /// </summary>
        public string Name => _name;

        /// <summary>
        ///     The data type assigned to the parameter.
        /// </summary>
        public CsType ParameterType => _parameterType;

        /// <summary>
        ///     The default value assigned to the parameter. This will be null if the HasDefaultValue property is set to false.
        /// </summary>
        public CsParameterDefaultValue DefaultValue => _defaultValue;

        /// <summary>
        ///     The data type assigned to the parameter.
        /// </summary>
        IDotNetType IDotNetParameter.ParameterType => ParameterType;

        /// <summary>
        ///     Flag that determines if the parameter is assigned the out keyword.
        /// </summary>
        public bool IsOut => _isOut;

        /// <summary>
        ///     Flag that determines if the parameter is assigned the ref keyword.
        /// </summary>
        public bool IsRef => _isRef;

        /// <summary>
        ///     Flag that determines if the parameter is an parameter array.
        /// </summary>
        public bool IsParams => _isParams;

        /// <summary>
        ///     Flag that determines if the parameter is optional.
        /// </summary>
        public bool IsOptional => _isOptional;

        /// <summary>
        ///     Flag that determines if the parameter is a generic place holder.
        /// </summary>
        public bool IsGenericParameter => _isGenericParameter;

        /// <summary>
        ///     Flag that determines if the parameter has a default value.
        /// </summary>
        public bool HasDefaultValue => _hasDefaultValue;

        /// <summary>
        ///     The default value assigned to the parameter. This will be null if the HasDefaultValue property is set to false.
        /// </summary>
        IDotNetParameterDefaultValue IDotNetParameter.DefaultValue => DefaultValue;

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        public CsModel Parent => LookupModel(_parentPath);
    }
}
