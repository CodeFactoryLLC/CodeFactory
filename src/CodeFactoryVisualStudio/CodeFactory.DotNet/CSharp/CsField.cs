//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents a field definition.
    /// </summary>
    public abstract class CsField:CsMember,ICsField
    {
        #region Property backing fields
        private readonly bool _isReadOnly;
        private readonly bool _isStatic;
        private readonly bool _isConstant;
        private readonly string _constantValue;
        private readonly CsType _dataType;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsField"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="dataType">The type definition for the field.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this member is defined in.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="parentPath">THe fully qualified lookup path for the parent model to this one.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        /// <param name="isReadOnly">Flag that determines if the model is read only.</param>
        /// <param name="isStatic">Flag that determines if the model is a static definition.</param>
        /// <param name="isConstant">Flag that determines if the field is a constant definition.</param>
        /// <param name="constantValue">The value assigned to the field if it is a constant definition.</param>
        protected CsField(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<CsAttribute> attributes, IReadOnlyList<string> sourceFiles, bool hasDocumentation, string documentation,
            string lookupPath, string name, string parentPath, CsSecurity security, bool isReadOnly, 
            bool isStatic, bool isConstant, string constantValue, CsType dataType, string sourceDocument, ModelStore<ICsModel> modelStore = null,
            IReadOnlyList<ModelLoadException> modelErrors=null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Field,attributes, 
                sourceFiles, hasDocumentation, documentation, lookupPath,
                name, parentPath, security, CsMemberType.Field, sourceDocument, modelStore, modelErrors)
        {
            _isReadOnly = isReadOnly;
            _isStatic = isStatic;
            _isConstant = isConstant;
            _constantValue = constantValue;
            _dataType = dataType;
        }

        /// <summary>
        ///     The data type assigned to the field.
        /// </summary>
        IDotNetType IDotNetField.DataType => DataType;

        /// <summary>
        ///     The data type assigned to the field.
        /// </summary>
        public CsType DataType => _dataType;

        /// <summary>
        ///     Flag that determines if this field is set to readonly.
        /// </summary>
        public bool IsReadOnly => _isReadOnly;

        /// <summary>
        ///     Flag that determines if the field is set to be static.
        /// </summary>
        public bool IsStatic => _isStatic;

        /// <summary>
        /// Flag that determines if the field is a constant.
        /// </summary>
        public bool IsConstant => _isConstant;

        /// <summary>
        /// The value that was assigned to the constant. Will return as the string representation of the value.
        /// </summary>
        public string ConstantValue => _constantValue;
    }
}
