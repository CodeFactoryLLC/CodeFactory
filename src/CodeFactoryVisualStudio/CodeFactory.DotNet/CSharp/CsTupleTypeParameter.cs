//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents a tuple type parameter.
    /// </summary>
    public abstract class CsTupleTypeParameter:CsModel,ICsTupleTypeParameter
    {
        #region Property backing fields
        private readonly bool _hasDefaultName;
        private readonly string _name;
        private readonly CsType _tupleType;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsModel"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="hasDefaultName">Does the type parameter use a distinct name.</param>
        /// <param name="name">The distinct name assigned to the type.</param>
        /// <param name="tupleType">The type definition of the tuple type.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occurred while creating the model.</param>
        protected CsTupleTypeParameter(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            bool hasDefaultName, string name, CsType tupleType, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, 
            IReadOnlyList<ModelLoadException> modelErrors = null)
            : base(isLoaded, hasErrors, loadedFromSource, language,CsModelType.TupleTypeParameter, sourceDocument, modelStore, modelErrors)
        {
            _hasDefaultName = hasDefaultName;
            _name = name;
            _tupleType = tupleType;
        }

        /// <summary>
        /// Flag that determines if the named assigned to the tuple was system generated or defined in source.
        /// </summary>
        public bool HasDefaultName => _hasDefaultName;

        /// <summary>
        /// The name assigned to the tuple parameter.
        /// </summary>
        public string Name => _name;

        /// <summary>
        /// The model with the type definition assigned to the tuple.
        /// </summary>
        public CsType TupleType => _tupleType;

        /// <summary>
        /// The model with the type definition assigned to the tuple.
        /// </summary>
        IDotNetType IDotNetTupleTypeParameter.TupleType => _tupleType;
    }
}
