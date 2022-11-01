//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory.Document
{
    /// <summary>
    /// Exception management class that host information about exceptions that occurred while managing documents in code factory.
    /// </summary>
    public class DocumentException:CodeFactoryException
    {

        /// <summary>
        /// Creates a document exception.
        /// </summary>

        public DocumentException() : base(CodeFactoryMessages.BaseDocumentException)
        {
            //Intentionally blank.
        }

        /// <summary>
        /// Creates a document exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        public DocumentException(string message) : base(message)
        {
            //Intentionally blank.
        }

        /// <summary>
        /// Creates a document exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        public DocumentException(string message, Exception innerException) : base(message, innerException)
        {
            //Intentionally blank
        }
    }
}
