//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Base exception class for all visual studio specific exceptions that occur in code factory.
    /// </summary>
    public class VisualStudioException:CodeFactoryException
    {

        /// <summary>
        /// Creates a visual studio code factory exception.
        /// </summary>
        public VisualStudioException() : base(VisualStudioMessages.VisualStudioGeneralError)
        {

        }

        /// <summary>
        /// Creates a visual studio code factory exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        public VisualStudioException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates a visual studio code factory exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        public VisualStudioException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
