//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsAttributeParameter"/> model.
    /// </summary>
    public static class CsAttributeParameterExtensions
    {
        /// <summary>
        /// Extension method that creates the attributes parameters list for a attribute definition in c# syntax format.
        /// </summary>
        /// <param name="source">THe source list of parameters to be created.</param>
        /// <returns>The fully formatted parameters section of a attribute declaration.</returns>
        public static string CSharpFormatAttributeParametersSignature(this IReadOnlyList<CsAttributeParameter> source)
        {
            if (source == null) return null;
            if (!source.Any()) return null;

            StringBuilder attributeParameterSignature = new StringBuilder(Symbols.ParametersDefinitionStart);

            int totalParameters = source.Count;
            int currentParameter = 0;
            foreach (var sourceParameter in source)
            {
                currentParameter++;
                string parameter = !sourceParameter.HasNamedParameter ? $"{sourceParameter.Value.CSharpFormatAttributeParameterValueSignature()}" : $"{sourceParameter.Name} = {sourceParameter.Value.CSharpFormatAttributeParameterValueSignature()}";

                attributeParameterSignature.Append(parameter);
                if (totalParameters > currentParameter) attributeParameterSignature.Append(", ");
            }

            attributeParameterSignature.Append(Symbols.ParametersDefinitionEnd);

            return attributeParameterSignature.ToString();
        }
    }
}
