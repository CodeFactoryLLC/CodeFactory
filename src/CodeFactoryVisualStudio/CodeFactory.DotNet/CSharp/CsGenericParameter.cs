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
    /// Data model that represents the a generic parameter definition.
    /// </summary>
    public abstract class CsGenericParameter:CsModel,ICsGenericParameter
    {
        #region Property backing fields
        private readonly bool _hasOutKeyword;
        private readonly bool _hasNewConstraint;
        private readonly bool _hasClassConstraint;
        private readonly bool _hasStructConstraint;
        private readonly bool _hasConstraintTypes;
        private readonly IReadOnlyList<CsType> _constrainingTypes;
        private readonly CsType _type;
        #endregion


        /// <summary>
        /// Constructor for the <see cref="CsGenericParameter"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="modelType">The type of code model created.</param>
        /// <param name="hasOutKeyword">Flag that determines if parameter has out keyword assigned.</param>
        /// <param name="hasNewConstraint">Flag that determines if generic parameter supports new keyword.</param>
        /// <param name="hasClassConstraint">flag that determines if the generic parameter has a constraint requirement to classes.</param>
        /// <param name="hasStructConstraint">Flag that determines if the generic parameter has a constraint requirement to structures.</param>
        /// <param name="hasConstraintTypes">Flag that determines if the generic parameter has additional type constraints.</param>
        /// <param name="constrainingTypes">List of of additional constraints the generic parameter supports.</param>
        /// <param name="type">The type definition for the generic type</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        protected CsGenericParameter(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language, CsModelType modelType,
            bool hasOutKeyword, bool hasNewConstraint, bool hasClassConstraint, bool hasStructConstraint,
            bool hasConstraintTypes, IReadOnlyList<CsType> constrainingTypes, CsType type, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language, modelType, sourceDocument, modelStore, modelErrors)
        {
            _hasOutKeyword = hasOutKeyword;
            _hasNewConstraint = hasNewConstraint;
            _hasClassConstraint = hasClassConstraint;
            _hasStructConstraint = hasStructConstraint;
            _hasConstraintTypes = hasConstraintTypes;
            _constrainingTypes = constrainingTypes ?? ImmutableList<CsType>.Empty;
            _type = type;
        }

        /// <summary>
        /// Flag that determines if the generic parameter uses the out keyword.
        /// </summary>
        public bool HasOutKeyword => _hasOutKeyword;

        /// <summary>
        /// Flag that determines if the generic parameter has a constraint that is must support construction of a new type.
        /// </summary>
        public bool HasNewConstraint => _hasNewConstraint;

        /// <summary>
        /// Flag that determines if the generic parameter has a constraint that it must implement from a class.
        /// </summary>
        public bool HasClassConstraint => _hasClassConstraint;

        /// <summary>
        /// Flag that determines if the generic parameter has a constraint that is must implement from a structure.
        /// </summary>
        public bool HasStructConstraint => _hasStructConstraint;

        /// <summary>
        /// Flag that determines if the generic parameter has constraining types the parameter must ad hear to.
        /// </summary>
        public bool HasConstraintTypes => _hasConstraintTypes;

        /// <summary>
        /// The constraining types the generic parameter must ad hear to. If there are no constraining types an empty list will be returned.
        /// </summary>
        public IReadOnlyList<CsType> ConstrainingTypes => _constrainingTypes;

        /// <summary>
        /// The type definition of the generic parameter.
        /// </summary>
        public CsType Type => _type;

        /// <summary>
        /// The constraining types the generic parameter must ad hear to. If there are no constraining types an empty list will be returned.
        /// </summary>
        IReadOnlyList<IDotNetType> IDotNetGenericParameter.ConstrainingTypes => ConstrainingTypes;

        /// <summary>
        /// The type definition of the generic parameter.
        /// </summary>
        IDotNetType IDotNetGenericParameter.Type => Type;
    }
}
