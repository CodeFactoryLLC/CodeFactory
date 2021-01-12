//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory
{
    /// <summary>
    /// Exception class that is designed to capture exception information during the creation of a model.
    /// </summary>
    /// <typeparam name="TModelTypes">Target enumeration of model types that this exception will support.</typeparam>
    public class ModelException<TModelTypes> : CodeFactoryException where TModelTypes : struct, IComparable, IFormattable, IConvertible
    {
        /// <summary>
        /// The source type of the model that had an error when loading.
        /// </summary>
        public TModelTypes ModelType { get; private set; }

        /// <summary>
        /// Creates a model exception.
        /// </summary>
        /// <param name="modelType">The type of model that had issues </param>
        public ModelException(TModelTypes modelType) : base()
        {
            ModelType = modelType;
        }

        /// <summary>
        /// Creates a model exception.
        /// </summary>
        /// <param name="modelType">The type of model that had issues </param>
        /// <param name="message">The error message to be captured by the exception</param>
        public ModelException(TModelTypes modelType, string message) : base(message)
        {
            ModelType = modelType;
        }

        /// <summary>
        /// Creates a model exception.
        /// </summary>
        /// <param name="modelType">The type of model that had issues </param>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        public ModelException(TModelTypes modelType, string message, Exception innerException) : base(message, innerException)
        {
            ModelType = modelType;
        }

    }
}
