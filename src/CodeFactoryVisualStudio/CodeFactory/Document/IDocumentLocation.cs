//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.Document
{
    /// <summary>
    /// Definition of the information to identify a location within a document. 
    /// </summary>
    public interface IDocumentLocation
    {
        /// <summary>
        /// The line number within the file.
        /// </summary>
        int LineNumber { get;}

        /// <summary>
        /// The character position within the line.
        /// </summary>
        int CharacterPosition { get;}
    }
}
