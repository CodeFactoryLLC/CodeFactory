//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents the definition of a property.
    /// </summary>
    public abstract class CsProperty:CsMember,ICsProperty
    {
        #region Property backing fields
        private readonly bool _hasGet;
        private readonly bool _hasSet;
        private readonly bool _isAbstract;
        private readonly bool _isVirtual;
        private readonly bool _isSealed;
        private readonly bool _isOverride;
        private readonly bool _isStatic;
        private readonly CsType _propertyType;
        private readonly CsSecurity _getSecurity;
        private readonly CsSecurity _setSecurity;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsProperty"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="setSecurity">The security access assigned to the setter.</param>
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
        /// <param name="hasGet">Flag that determines if the property implements a getter.</param>
        /// <param name="hasSet">Flag that determines if the property implements a setter.</param>
        /// <param name="isAbstract">Flag that determines if the model is abstract.</param>
        /// <param name="isVirtual">Flag that determines if the model is virtual.</param>
        /// <param name="isSealed">Flag that determines if the model is sealed.</param>
        /// <param name="isOverride">Flag that determines if the model is overridden.</param>
        /// <param name="isStatic">Flag that determines if the model is static.</param>
        /// <param name="propertyType">The type the property supports.</param>
        /// <param name="getSecurity">The security access assigned to the getter.</param>
        protected CsProperty(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<CsAttribute> attributes, IReadOnlyList<string> sourceFiles, bool hasDocumentation, string documentation,
            string lookupPath, string name, string parentPath, CsSecurity security, 
            bool hasGet, bool hasSet, bool isAbstract, bool isVirtual, bool isSealed, bool isOverride, bool isStatic,
            CsType propertyType, CsSecurity getSecurity, CsSecurity setSecurity,
            string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, CsModelType.Property,attributes, sourceFiles,
                hasDocumentation, documentation, lookupPath, name, parentPath, security, CsMemberType.Property, sourceDocument, modelStore, modelErrors)
        {
            _hasGet = hasGet;
            _hasSet = hasSet;
            _isAbstract = isAbstract;
            _isVirtual = isVirtual;
            _isSealed = isSealed;
            _isOverride = isOverride;
            _isStatic = isStatic;
            _propertyType = propertyType;
            _getSecurity = getSecurity;
            _setSecurity = setSecurity;
        }

        /// <summary>
        ///     The source data type that is managed by this property.
        /// </summary>
        IDotNetType IDotNetProperty.PropertyType => PropertyType;

        /// <summary>
        ///     The security scope that is assigned to the get accessor. Make sure you check the HasGet to determine if the property supports get operations.
        /// </summary>
        public CsSecurity GetSecurity => _getSecurity;

        /// <summary>
        ///     The security scope that is assigned to the set accessor. Make sure you check the HasSet to determine if the property supports set operations.
        /// </summary>
        public CsSecurity SetSecurity => _setSecurity;

        /// <summary>
        ///     The source data type that is managed by this property.
        /// </summary>
        public CsType PropertyType => _propertyType;

        /// <summary>
        ///     Flag that determines if this property supports get access.
        /// </summary>
        public bool HasGet => _hasGet;

        /// <summary>
        ///     The security scope that is assigned to the get accessor. Make sure you check the HasGet to determine if the property supports get operations.
        /// </summary>
        DotNetSecurity IDotNetProperty.GetSecurity =>(DotNetSecurity)(int) _getSecurity;

        /// <summary>
        ///     Flag that determines if this property supports set access.
        /// </summary>
        public bool HasSet => _hasSet;

        /// <summary>
        ///     The security scope that is assigned to the set accessor. Make sure you check the HasSet to determine if the property supports set operations.
        /// </summary>
        DotNetSecurity IDotNetProperty.SetSecurity => (DotNetSecurity)(int) _setSecurity;

        /// <summary>
        ///     Flag that determines if the property is implemented as an abstract property.
        /// </summary>
        public bool IsAbstract => _isAbstract;

        /// <summary>
        ///     Flag that determines if the property is implemented as virtual.
        /// </summary>
        public bool IsVirtual => _isVirtual;

        /// <summary>
        ///     Flag that determines if the property has been sealed.
        /// </summary>
        public bool IsSealed => _isSealed;

        /// <summary>
        ///     Flag that determines if the property has been overridden.
        /// </summary>
        public bool IsOverride => _isOverride;

        /// <summary>
        ///     Flag that determines if the property has been implemented as static.
        /// </summary>
        public bool IsStatic => _isStatic;

        /// <summary>
        /// The source code syntax that is stored in the body of the property get. This will be null if was not loaded from source code.
        /// </summary>
        public abstract Task<string> LoadGetBodySyntaxAsync();

        /// <summary>
        /// The source code syntax that is stored in the body of the property get. This will be null if was not loaded from source code.
        /// </summary>
        public abstract Task<string> LoadSetBodySyntaxAsync();
    }
}
