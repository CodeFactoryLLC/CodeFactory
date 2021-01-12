//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Code factory exception that occurs when accessing visual studios project system. 
    /// </summary>
    public class ProjectSystemException:VisualStudioException
    {
        /// <summary>
        /// Creates a visual studio project system code factory exception.
        /// </summary>
        public ProjectSystemException() : base(VisualStudioMessages.VisualStudioGeneralError)
        {
            //Intentionally blank
        }

        /// <summary>
        /// Creates a visual studio project system code factory exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        public ProjectSystemException(string message) : base(message)
        {
            //Intentionally blank
        }

        /// <summary>
        /// Creates a visual studio project system code factory exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        public ProjectSystemException(string message, Exception innerException) : base(message, innerException)
        {
            //Intentionally blank
        }
    }
}
