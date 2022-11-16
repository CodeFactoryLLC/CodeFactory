//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFactory.DotNet;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsAttributeParameterValue"/> model.
    /// </summary>
    public static class CsAttributeParameterValueExtensions
    {
        /// <summary>
        /// Creates the implementation of an attribute value formatted for C#.
        /// </summary>
        /// <param name="source">The source value to format.</param>
        /// <returns>The formatted value, or null if the model does not exist.</returns>
        public static string CSharpFormatAttributeParameterValueSignature(this CsAttributeParameterValue source)
        {
            if (source == null) return null;

            if (source.ParameterKind != AttributeParameterKind.Array)
                return source.TypeValue.FormatCSharpValueSyntax(source.Value);

            StringBuilder attributeValueSignature = new StringBuilder($"{Symbols.MultipleStatementStart}");

            int totalParameters = source.Values.Count;
            int currentValue = 0;
            foreach (var sourceValue in source.Values)
            {
                currentValue++;
                string value = sourceValue.ParameterKind != AttributeParameterKind.Array ? $"{sourceValue.TypeValue.FormatCSharpValueSyntax(sourceValue.Value)}" : $"{sourceValue.CSharpFormatAttributeParameterValueSignature()}";

                attributeValueSignature.Append(value);
                if (totalParameters < currentValue) attributeValueSignature.Append(", ");
            }

            attributeValueSignature.Append($"{Symbols.MultipleStatementEnd}");

            return attributeValueSignature.ToString();
        }
    }
}
