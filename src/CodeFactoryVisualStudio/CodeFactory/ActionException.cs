//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory
{
    /// <summary>
    /// Exception that is raised when an error occured that kept a code factory command from finishing execution. 
    /// </summary>
    public class ActionException:CodeFactoryException
    {

        /// <summary>
        /// Creates a command exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        public ActionException(string message) : base(message)
        {
            //Intentionally blank
        }

        /// <summary>
        /// Creates a command exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        public ActionException(string message, Exception innerException) : base(message, innerException)
        {
            //Intentionally blank
        }
    }
}
