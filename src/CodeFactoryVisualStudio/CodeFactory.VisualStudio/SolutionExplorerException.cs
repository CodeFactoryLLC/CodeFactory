//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Exception that is raised when there are problem accessing needed resources from visual studio's solution explorer.
    /// </summary>
    public class SolutionExplorerException:VisualStudioException
    {
        /// <summary>
        /// Creates a solution explorer code factory exception.
        /// </summary>
        public SolutionExplorerException() : base(VisualStudioMessages.SolutionExplorerGeneralError)
        {

        }

        /// <summary>
        /// Creates a solution explorer code factory exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        public SolutionExplorerException(string message) : base(message)
        {

        }

        /// <summary>
        /// Creates a solution explorer code factory exception.
        /// </summary>
        /// <param name="message">The error message to be captured by the exception</param>
        /// <param name="innerException">The inner exception that occurred and to be added to this exception.</param>
        public SolutionExplorerException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
