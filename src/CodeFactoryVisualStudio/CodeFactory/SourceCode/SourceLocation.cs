//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.Document;

namespace CodeFactory.SourceCode
{
    /// <summary>
    /// Data model that implements the contract <see cref="ISourceLocation"/>
    /// </summary>
    public class SourceLocation:ISourceLocation
    {
        #region Backing fields for the properties of the data model.
        private readonly DocumentLocation _startLocation;
        private readonly DocumentLocation _endLocation;
        #endregion

        /// <summary>
        /// Create a instance of the <see cref="SourceLocation"/> data class.
        /// </summary>
        /// <param name="startLine">The starting line number for the source.</param>
        /// <param name="startPosition">The starting character position for the source.</param>
        /// <param name="endLine">The end line number for the source.</param>
        /// <param name="endPosition">The end character position for the source.</param>
        /// <returns>New instance of the <see cref="SourceLocation"/> returned as <see cref="ISourceLocation"/>.</returns>
        public static ISourceLocation Init(int startLine, int startPosition, int endLine, int endPosition)
        {
            return new SourceLocation(startLine, startPosition, endLine, endPosition);
        }

        /// <summary>
        /// Create a instance of the <see cref="SourceLocation"/> data class.
        /// </summary>
        /// <param name="startLine">The starting line number for the source.</param>
        /// <param name="startPosition">The starting character position for the source.</param>
        /// <param name="endLine">The end line number for the source.</param>
        /// <param name="endPosition">The end character position for the source.</param>
        private SourceLocation(int startLine, int startPosition, int endLine, int endPosition)
        {
            _startLocation = DocumentLocation.Init(startLine, startPosition);
            _endLocation = DocumentLocation.Init(endLine, endPosition);
        }

        #region Implementation of ISourceLocation

        /// <inheritdoc />
        public DocumentLocation StartLocation => _startLocation;

        /// <inheritdoc />
        public DocumentLocation EndLocation => _endLocation;

        #endregion
    }
}
