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
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsGenericParameter"/> model.
    /// </summary>
    public static class CsGenericParameterExtensions
    {

        /// <summary>
        /// Extension method that generates the generics definition part of a signature in the C# format.
        /// </summary>
        /// <param name="source">The target types that make up the generics signature.</param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The fully formatted definition of the generics signature, or null if the source is not provided. </returns>
        public static string CSharpFormatGenericParametersSignature(this IReadOnlyList<CsGenericParameter> source, NamespaceManager manager = null)
        {
            //bounds check
            if (source == null) return null;
            if (!source.Any()) return null;

            StringBuilder genericsSignature = new StringBuilder(Symbols.GenericDefinitionStart);

            int totalParameters = source.Count;
            int currentParameter = 0;

            //Parsing each generic parameters and formatting output
            foreach (var sourceGenericParameter in source)
            {
                currentParameter++;
                genericsSignature.Append(sourceGenericParameter.Type.IsGenericPlaceHolder ? sourceGenericParameter.Type.Name :sourceGenericParameter.Type.CSharpFormatTypeName(manager));
                if (totalParameters > currentParameter) genericsSignature.Append(", ");
            }

            genericsSignature.Append(Symbols.GenericDefinitionEnd);

            return genericsSignature.ToString();
        }

        /// <summary>
        /// Extension method that generates the where clause for a generic parameter if one exists. This will not generate if the generic parameter is not a place holder type, or if no where clause conditions have been provided.
        /// </summary>
        /// <param name="source">Generic parameter to generate the where clause from.</param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>Null if the where clause was not generated, or the C# syntax for the where clause.</returns>
        public static string CSharpFormatGenericWhereClauseSignature (this CsGenericParameter source, NamespaceManager manager = null)
        {
            if (source == null) return null;
            if (!source.Type.IsGenericPlaceHolder) return null;
            if (!source.HasClassConstraint & !source.HasConstraintTypes & !source.HasNewConstraint &
                !source.HasStructConstraint) return null;

            var whereBuilder = new StringBuilder($"{CommonContextualKeywords.Where} {source.Type.Name}: ");
            bool hasValue = false;

            if (source.HasClassConstraint)
            {
                whereBuilder.Append($"{Keywords.Class}");
                hasValue = true;
            }

            if (source.HasStructConstraint)
            {
                whereBuilder.Append($"{Keywords.Structure}");
                hasValue = true;
            }

            if (source.HasConstraintTypes)
            {
                foreach (var sourceConstrainingType in source.ConstrainingTypes)
                {
                    whereBuilder.Append(hasValue
                        ? $",{sourceConstrainingType.CSharpFormatTypeName(manager)}"
                        : sourceConstrainingType.CSharpFormatTypeName(manager));
                    hasValue = true;
                }

            }

            if (source.HasNewConstraint)
            {
                whereBuilder.Append(hasValue
                    ? $", {Keywords.New}{Symbols.ParametersDefinitionStart}{Symbols.ParametersDefinitionEnd}"
                    : $"{Keywords.New}{Symbols.ParametersDefinitionStart}{Symbols.ParametersDefinitionEnd}");
            }

            whereBuilder.Append(" ");

            return whereBuilder.ToString();

        }

    }
}
