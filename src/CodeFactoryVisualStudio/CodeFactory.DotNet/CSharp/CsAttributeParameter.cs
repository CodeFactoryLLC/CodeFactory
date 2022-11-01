//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents a attribute parameter.
    /// </summary>
    public abstract class CsAttributeParameter:CsModel,ICsAttributeParameter
    {
        #region Property backing fields
        private readonly bool _hasNamedParameter;
        private readonly string _name;
        private readonly CsAttributeParameterValue _value;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsAttributeParameter"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="value">The value assigned to the parameter.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        /// <param name="hasNamedParameter">Flag that determines if the attribute parameter is a named parameter.</param>
        /// <param name="name">The name of the parameter, should be null if not named.</param>
        protected CsAttributeParameter(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, 
            bool hasNamedParameter, string name, CsAttributeParameterValue value, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.AttributeParameter, sourceDocument, modelStore, modelErrors)
        {
            _hasNamedParameter = hasNamedParameter;
            _name = name;
            _value = value;
        }

        /// <summary>
        /// Flag that determines if the attribute parameter is a named value, 
        /// or just part of the attributes constructor.
        /// </summary>
        public bool HasNamedParameter => _hasNamedParameter;

        /// <summary>
        ///     The name of the parameter, if this is not a named parameter then it will be set to null
        /// </summary>
        public string Name => _name;

        /// <summary>
        ///     The value that was assigned to the parameter.
        /// </summary>
        public CsAttributeParameterValue Value => _value;

        /// <summary>
        ///     The value that was assigned to the parameter.
        /// </summary>
        IDotNetAttributeParameterValue IDotNetAttributeParameter.Value => Value;
    }
}
