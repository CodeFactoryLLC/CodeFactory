//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents the default value for a parameter.
    /// </summary>
    public abstract class CsParameterDefaultValue:CsModel,ICsParameterDefaultValue
    {
        #region Property backing fields
        private readonly string _lookupPath;
        private readonly ParameterDefaultValueType _valueType;
        private readonly string _value;
        private readonly string _parentPath;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsParameterDefaultValue"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="parentPath">The fully qualified path name for the parent model to this model. </param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="lookupPath">The fully qualified path for the model in the model store.</param>
        /// <param name="valueType">The type of default value assigned to the parameter.</param>
        /// <param name="value">The value assigned as the default value.</param>
        protected CsParameterDefaultValue(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,  string lookupPath, 
            ParameterDefaultValueType valueType, string value, string parentPath, string sourceDocument = null, ModelStore<ICsModel> modelStore = null,
            IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.ParameterDefaultValue, sourceDocument, modelStore, modelErrors)
        {
            _lookupPath = lookupPath;
            _valueType = valueType;
            _value = value;
            _parentPath = parentPath;
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
        /// The type of default value assigned to the parameter.
        /// </summary>
        public ParameterDefaultValueType ValueType => _valueType;

        /// <summary>
        /// If the default value is a literal value the value will be set, otherwise it will be set to null.
        /// </summary>
        public string Value => _value;

        /// <summary>
        /// The parent to the current model. This will return null if there is no parent for this model, or the parent could not be located. 
        /// </summary>
        public CsModel Parent => LookupModel(_parentPath);
    }
}
