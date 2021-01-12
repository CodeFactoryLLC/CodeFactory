//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data class that represents an attributes parameter value.
    /// </summary>
    public abstract class CsAttributeParameterValue:CsModel,ICsAttributeParameterValue
    {
        #region Property backing fields
        private readonly AttributeParameterKind _parameterKind;
        private readonly string _value;
        private readonly string _enumValue;
        private readonly CsType _typeValue;
        private readonly IReadOnlyList<CsAttributeParameterValue> _values;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsAttributeParameterValue"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="values">The list of values if the parameter has more then one value.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="parameterKind">The kind of attribute parameter.</param>
        /// <param name="value">The value of the attribute parameter.</param>
        /// <param name="enumValue">The value of the enumeration if the parameter is an enumeration.</param>
        /// <param name="typeValue">The type if the parameter is a single value.</param>
        protected CsAttributeParameterValue(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, 
            AttributeParameterKind parameterKind, string value, string enumValue, CsType typeValue, 
            IReadOnlyList<CsAttributeParameterValue> values, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.AttributeParameterValue, sourceDocument, modelStore, modelErrors)
        {
            _parameterKind = parameterKind;
            _value = value;
            _enumValue = enumValue;
            _typeValue = typeValue;
            _values = values ?? ImmutableList<CsAttributeParameterValue>.Empty;
        }

        /// <summary>
        /// Determines the kind of parameter that has been returned.
        /// </summary>
        public AttributeParameterKind ParameterKind => _parameterKind;

        /// <summary>
        /// Gets the raw value assigned to the parameter. This will be populated if the property <see cref="IDotNetAttributeParameterValue.ParameterKind"/> is not set to 'Array'
        /// </summary>
        public string Value => _value;

        /// <summary>
        /// The type definition of the parameter that was passed. This will be populated if the property ParameterKind is set to 'Type'
        /// </summary>
        public CsType TypeValue => _typeValue;

        /// <summary>
        /// Gets an enumeration of all the parameter values that were assigned to the attribute parameter. This will be populated if the property ParameterKind is set to 'Array'
        /// </summary>
        public IReadOnlyList<CsAttributeParameterValue> Values => _values;

        /// <summary>
        /// The type definition of the parameter that was passed. This will be populated if the property <see cref="IDotNetAttributeParameterValue.ParameterKind"/> is set to 'Type'
        /// </summary>
        IDotNetType IDotNetAttributeParameterValue.TypeValue => TypeValue;

        /// <summary>
        /// The enum value provides the name of the enumeration value that was provided. This will be populated if the property <see cref="IDotNetAttributeParameterValue.ParameterKind"/> is set to 'Enum'
        /// </summary>
        public string EnumValue => _enumValue;

        /// <summary>
        /// Gets an enumeration of all the parameter values that were assigned to the attribute parameter. This will be populated if the property <see cref="IDotNetAttributeParameterValue.ParameterKind"/> is set to 'Array'
        /// </summary>
        IReadOnlyList<IDotNetAttributeParameterValue> IDotNetAttributeParameterValue.Values => Values;
    }
}
