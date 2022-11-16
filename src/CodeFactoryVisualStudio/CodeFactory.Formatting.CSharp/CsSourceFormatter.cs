
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Helper class that adds indent levels correctly for source code formatting.
    /// </summary>
    public class CsSourceFormatter
    {
        /// <summary>
        /// Field that holds the indent statement to be used in code blocks
        /// </summary>
        private readonly string _indentStatement;

        /// <summary>
        /// The string builder used to format the source code.
        /// </summary>
        readonly StringBuilder _codeFormatter = new StringBuilder();

        /// <summary>
        /// Creates a new instance of the <see cref="CsSourceFormatter"/>
        /// </summary>
        /// <param name="indentStatement">Optional parameter that allows you to set the target type of indent that will occur with each code statement.</param>
        public CsSourceFormatter(string indentStatement = "\t")
        {
            _indentStatement = indentStatement;
        }

        /// <summary>
        /// Appends code to the end of the current line in the formatter.
        /// </summary>
        /// <param name="code">The code to append.</param>
        public void AppendCode(string code)
        {
            if(string.IsNullOrEmpty(code))return;
            _codeFormatter.Append(code);
        }

        /// <summary>
        /// Appends a new line of code to the formatter.
        /// </summary>
        /// <param name="indentLevel">The number of indent levels to add to the source code.</param>
        /// <param name="code">The code to add to the formatter.</param>
        public void AppendCodeLine(int indentLevel, string code)
        {
            AppendCodeLine(indentLevel);

            //Bug fix update for Issue #13
            if (!string.IsNullOrEmpty(code))  _codeFormatter.Append(code);
        }

        /// <summary>
        /// Appends a new line of code to the formatter.
        /// </summary>
        /// <param name="indentLevel">The number of indent levels to add to the source code.</param>
        public void AppendCodeLine(int indentLevel)
        {
            _codeFormatter.AppendLine();
            if (indentLevel > 0)
            {
                int currentLevel = 0;
                while (currentLevel < indentLevel)
                {
                    _codeFormatter.Append(_indentStatement);
                    currentLevel++;
                }
            }
        }

        /// <summary>
        /// Appends a target indent level to a already formatted block of code.
        /// </summary>
        /// <param name="indentLevel">The target indent level to be added to the existing code block.</param>
        /// <param name="codeBlock">The block of code to append to.</param>
        public void AppendCodeBlock(int indentLevel, string codeBlock)
        {
            if(string.IsNullOrEmpty(codeBlock)) return;

            //Split the existing documentation into individual lines to be processed.
            var codeLines = codeBlock.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            //iterate over each document line and confirm it can be formatted for C# xml documentation.
            foreach (string codeLine in codeLines)
            {
                AppendCodeLine(indentLevel,codeLine);
            }
        }

        /// <summary>
        /// Appends a target indent level to a already formatted block of code.
        /// </summary>
        /// <param name="indentLevel">The target indent level to be added to the existing code block.</param>
        /// <param name="codeBlock">The block of code to append to.</param>
        public void AppendCodeBlock(int indentLevel, IEnumerable<string> codeBlock)
        {
            if (codeBlock == null) return;

            //iterate over each document line and confirm it can be formatted for C# xml documentation.
            foreach (string codeLine in codeBlock)
            {
                AppendCodeLine(indentLevel, codeLine);
            }
        }

        /// <summary>
        /// Returns the formatted source code.
        /// </summary>
        /// <returns>Formatted SourceCode.</returns>
        public string ReturnSource()
        {
            return _codeFormatter.ToString();
        }

        /// <summary>
        /// Clears the formatter to be reused.
        /// </summary>
        public void ResetFormatter()
        {
            _codeFormatter.Clear();
        }
    }
}
