//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.Document
{
    /// <summary>
    /// Document location data class, used to determine a point within a document. This is used for gathering and setting model information.
    /// </summary>
    public class DocumentLocation:IDocumentLocation
    {
        #region Backing field for the property.
        private readonly int _lineNumber;
        private readonly int _characterPosition;
        #endregion

        /// <summary>
        /// Returns an Immutable instance of data class that implements <see cref="IDocumentLocation"/> contract definition.
        /// </summary>
        /// <param name="lineNumber">The line number within the file.</param>
        /// <param name="characterPosition">The character position within the line.</param>
        /// <returns>Immutable instance of the document location.</returns>
        public static DocumentLocation Init(int lineNumber, int characterPosition)
        {
            return new DocumentLocation(lineNumber, characterPosition);
        }

        /// <summary>
        /// Initializes a new instance of a <see cref="DocumentLocation"/> data class.
        /// </summary>
        /// <param name="lineNumber">The line number within the file.</param>
        /// <param name="characterPosition">The character position within the line.</param>
        protected DocumentLocation(int lineNumber, int characterPosition)
        {
            _lineNumber = lineNumber;
            _characterPosition = characterPosition;
        }

        /// <inheritdoc />
        public int LineNumber => _lineNumber;

        /// <inheritdoc />
        public int CharacterPosition => _characterPosition;
    }
}
