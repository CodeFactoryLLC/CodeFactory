//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using CodeFactory.DotNet;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="IDocumentation"/> interface.
    /// </summary>
    public static class DocumentationExtensions
    {
        /// <summary>
        /// An Iterator that returns fully formatted XML documentation for the C# programming language.
        /// </summary>
        /// <param name="documentation">The source code model that has documentation.</param>
        /// <returns>The enumerator that loads the formatted XML documentation for the CSharp Language.</returns>
        public static IEnumerable<string> CSharpFormatXmlDocumentationEnumerator(this IDocumentation documentation)
        {
            //No documentation was found for the model, stop the enumeration.
            if (documentation == null) yield break;

            //No documentation for this model has been set, stop the enumeration.
            if (!documentation.HasDocumentation) yield break;

            //Split the existing documentation into individual lines to be processed.
            var documentLines = documentation.Documentation.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            //iterate over each document line and confirm it can be formatted for C# xml documentation.
            foreach (string docData in documentLines)
            {
                //Looping through each line of XML documentation and formatting it for visual studio output.
                var formattedDocLine = docData.CSharpFormatDocumentationLine();

                if (formattedDocLine == null) continue;
                yield return formattedDocLine;
            }
        }

        /// <summary>
        /// Extension method that takes documentation and returns a XML comment based documentation for C# code.
        /// </summary>
        /// <param name="source">documentation string to be evaluated.</param>
        /// <returns>the comment formatted c# documentation or null if the string is not for documentation.</returns>
        public static string CSharpFormatDocumentationLine(this string source)
        {
            if (string.IsNullOrEmpty(source)) return null;
            var trimmed = source.Trim();
            if (trimmed.Contains("<member")) return null;
            return trimmed.Contains("</member") ? null : $"///{trimmed}";
        }
    }
}
