//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Linq;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsAttribute"/> model.
    /// </summary>
    public static class CsAttributeExtensions
    {
        /// <summary>
        /// Extension method that returns a full attribute declaration in the C# language format.
        /// </summary>
        /// <param name="source">The attribute toe generate the c# signature for.</param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The formatted attribute signature or null if data was missing to create the attribute.</returns>
        public static string CSharpFormatAttributeSignature(this CsAttribute source,NamespaceManager manager = null)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;
            
            return !source.HasParameters ? $"[{source.Type.CSharpFormatTypeName(manager)}{Symbols.ParametersDefinitionStart}{Symbols.ParametersDefinitionEnd}]" : $"[{source.Type.CSharpFormatTypeName(manager)}{source.Parameters.CSharpFormatAttributeParametersSignature()}]";
        }


        /// <summary>
        /// An iterator that returns fully formatted declaration syntax for a attribute in the C# language
        /// </summary>
        /// <param name="source">List of attributes to be processed.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <returns>Fully formatted syntax for the attribute.</returns>
        public static IEnumerable<string> CSharpFormatAttributeDeclarationEnumerator(this IReadOnlyList<CsAttribute> source,
            NamespaceManager manager = null)
        {
            //No documentation was found for the model, stop the enumeration.
            if (source == null) yield break;

            if(!source.Any()) yield break;


            //iterate over each attribute and confirm it can be formatted as c# attribute syntax.
            foreach (CsAttribute attributeData in source)
            {
                if(attributeData == null) continue;
                if(!attributeData.IsLoaded) continue;

                var declaration = attributeData.CSharpFormatAttributeSignature(manager);

                if(string.IsNullOrEmpty(declaration)) continue;

                yield return declaration;
            }
        }
    }
}
