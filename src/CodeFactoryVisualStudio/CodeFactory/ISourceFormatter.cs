//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory
{
    /// <summary>
    /// Base implementation all source formatters that support CodeFactory must implement.
    /// </summary>
    public interface ISourceFormatter
    {
        /// <summary>
        /// Appends code to the end of the current line in the formatter.
        /// </summary>
        /// <param name="code">The code to append.</param>
        void AppendCode(string code);

        /// <summary>
        /// Appends a new line of code to the formatter.
        /// </summary>
        /// <param name="indentLevel">The number of indent levels to add to the source code.</param>
        /// <param name="code">The code to add to the formatter.</param>
        void AppendCodeLine(int indentLevel, string code);

        /// <summary>
        /// Appends a new line of code to the formatter.
        /// </summary>
        /// <param name="indentLevel">The number of indent levels to add to the source code.</param>
        void AppendCodeLine(int indentLevel);

        /// <summary>
        /// Appends a target indent level to a already formatted block of code.
        /// </summary>
        /// <param name="indentLevel">The target indent level to be added to the existing code block.</param>
        /// <param name="codeBlock">The block of code to append to.</param>
        void AppendCodeBlock(int indentLevel, string codeBlock);

        /// <summary>
        /// Appends a target indent level to a already formatted block of code.
        /// </summary>
        /// <param name="indentLevel">The target indent level to be added to the existing code block.</param>
        /// <param name="codeBlock">The block of code to append to.</param>
        void AppendCodeBlock(int indentLevel, IEnumerable<string> codeBlock);

        /// <summary>
        /// Returns the formatted source code.
        /// </summary>
        /// <returns>Formatted SourceCode.</returns>
        string ReturnSource();

        /// <summary>
        /// Clears the formatter to be reused.
        /// </summary>
        void ResetFormatter();
    }
}