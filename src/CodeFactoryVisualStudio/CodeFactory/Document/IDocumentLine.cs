//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
namespace CodeFactory.Document
{
    /// <summary>
    /// Metadata about a line from a document that has been returned from code factory.
    /// </summary>
    public interface IDocumentLine
    {
        /// <summary>
        /// The line number within the document.
        /// </summary>
        long Number { get; }

        /// <summary>
        /// The number of characters that are in the line.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// The content of the line.
        /// </summary>
        string Content { get; }
    }

}
