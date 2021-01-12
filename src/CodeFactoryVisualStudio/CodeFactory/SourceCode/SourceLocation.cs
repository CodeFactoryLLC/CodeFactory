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

        public static ISourceLocation Init(int startLine, int startPosition, int endLine, int endPosition)
        {
            return new SourceLocation(startLine, startPosition, endLine, endPosition);
        }

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
