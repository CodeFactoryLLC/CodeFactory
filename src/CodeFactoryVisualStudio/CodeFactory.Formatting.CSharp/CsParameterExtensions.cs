//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsParameter"/> model.
    /// </summary>
    public static class CsParameterExtensions
    {
        /// <summary>
        /// Extension method that create the fully formatted parameters section in c# syntax.
        /// </summary>
        /// <param name="source">The source list of parameters to be turned into a parameters signature.</param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The fully formatted parameters signature or null if data was missing.</returns>
        public static string CSharpFormatParametersSignature (this IReadOnlyList<CsParameter> source, NamespaceManager manager = null)
        {
            if (source == null) return null;
            if (!source.Any()) return null;

            StringBuilder parameterSignature = new StringBuilder(Symbols.ParametersDefinitionStart);

            int totalParameters = source.Count;
            int currentParameter = 0;
            foreach (var sourceParameter in source)
            {
                currentParameter++;

                if (sourceParameter.HasAttributes)
                {
                    foreach (var sourceParameterAttribute in sourceParameter.Attributes)
                    {
                        parameterSignature.Append($"{sourceParameterAttribute.CSharpFormatAttributeSignature(manager)} ");
                    }
                }
                if (sourceParameter.IsOut) parameterSignature.Append($"{Keywords.Out} ");
                if (sourceParameter.IsRef) parameterSignature.Append($"{Keywords.Ref} ");
                if (sourceParameter.IsParams) parameterSignature.Append($"{Keywords.Params} ");
                parameterSignature.Append(!sourceParameter.IsOptional
                    ? $"{sourceParameter.ParameterType.CSharpFormatTypeName(manager)} {sourceParameter.Name}"
                    : $"{sourceParameter.ParameterType.CSharpFormatTypeName(manager)} {sourceParameter.Name} = {sourceParameter.DefaultValue.CSharpFormatParameterDefaultValue(sourceParameter.ParameterType)}");

                if (totalParameters > currentParameter) parameterSignature.Append(", ");
            }

            parameterSignature.Append(Symbols.ParametersDefinitionEnd);

            return parameterSignature.ToString();
        }


    }
}
