//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
namespace CodeFactory.Document
{
    /// <summary>
    /// Data class that holds the document line information.
    /// </summary>
    public class DocumentLine:IDocumentLine
    {
        #region Backing Fields
        private readonly long _number;
        private readonly int _length;
        private readonly string _content;
        #endregion


        /// <summary>
        /// Creates an immutable instance of the <see cref="DocumentLine"/>
        /// </summary>
        /// <param name="number">The line number within the document.</param>
        /// <param name="length">The number of characters that are in the line.</param>
        /// <param name="content">The content of the line.</param>
        public static DocumentLine Init(long number, int length, string content)
        {
            return new DocumentLine	(number,length,content);
        }

        /// <summary>
        /// Constructor that creates an instance of the <see cref="DocumentLine"/>
        /// </summary>
        /// <param name="number">The line number within the document.</param>
        /// <param name="length">The number of characters that are in the line.</param>
        /// <param name="content">The content of the line.</param>
        protected DocumentLine(long number, int length, string content)
        {
            _number = number;
            _length = length;
            _content = content;
        }

        /// <summary>
        /// The line number within the document.
        /// </summary>
        public long Number => _number;

        /// <summary>
        /// The number of characters that are in the line.
        /// </summary>
        public int Length => _length;

        /// <summary>
        /// The content of the line.
        /// </summary>
        public string Content => _content;
    }
}
