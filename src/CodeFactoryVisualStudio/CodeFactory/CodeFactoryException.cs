//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory
{
    /// <summary>
    /// Base exception class all code factory generated exceptions are based on.
    /// </summary>
    public class CodeFactoryException:Exception
    {


        /// <summary>
        /// Creates a general code factory exception.
        /// </summary>
        public CodeFactoryException() : base(CodeFactoryMessages.CodeFactoryError)
        {
            
        }

        /// <summary>
        /// Creates a general code factory exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception.</param>
        public CodeFactoryException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates a model exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception.</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        public CodeFactoryException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
