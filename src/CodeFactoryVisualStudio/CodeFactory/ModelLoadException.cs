//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory
{
    /// <summary>
    /// Exception class that captures information about errors during the creation of a code factory model.
    /// </summary>
    public class ModelLoadException:CodeFactoryException
    {
        private readonly string _modelType;
        /// <summary>
        /// Creates a model load exception.
        /// </summary>
        /// <param name="modelType">Optional parameter that stores the name of the target model type.</param>
        public ModelLoadException( string modelType = null) : base()
        {
            _modelType = modelType;
        }

        /// <summary>
        /// Creates a model load exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="modelType">Optional parameter that stores the name of the target model type.</param>
        public ModelLoadException(string message, string modelType = null) : base(message)
        {
            _modelType = modelType;
        }

        /// <summary>
        /// Creates a model load exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        /// <param name="modelType">Optional parameter that stores the name of the target model type.</param>
        public ModelLoadException(string message, Exception innerException, string modelType = null) : base(message, innerException)
        {
            _modelType = modelType;
        }
    }
}
