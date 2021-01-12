//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Static class that stores extension methods that support all models that derive from <see cref="ICsModel"/>
    /// </summary>
    public static class CsModelExtensions
    {
        /// <summary>
        /// Gets the security keyword for the C# language.
        /// </summary>
        /// <param name="source">The source security object to get the keyword from.</param>
        /// <returns>The name of the security keyword or null.</returns>
        public static string FormatCSharpSyntax(this CsSecurity source)
        {
            var targetSecurity = (DotNetSecurity)(int)source;

            return targetSecurity.FormatCSharpSyntax();
        }

        

        /// <summary>
        /// Extension method that generates the generics definition part of a signature in the c# format.
        /// </summary>
        /// <param name="source">The target types that make up the generics signature.</param>
        /// <returns>The fully formatted definition of the generics signature, or null if the source is not provided. </returns>
        public static string FormatCSharpGenericSignatureSyntax(this IReadOnlyList<CsGenericParameter> source)
        {
            var targetGenericSignature = source as IReadOnlyList<IDotNetGenericParameter>;

            return targetGenericSignature.FormatCSharpGenericSignatureSyntax();

        }

        /// <summary>
        /// Extension method that generates the where clause for a generic parameter if one exists. This will not generate if the generic parameter is not a place holder type, or if no where clause conditions have been provided.
        /// </summary>
        /// <param name="source">Generic parameter to generate the where clause from.</param>
        /// <returns>Null if the where clause was not generated, or the C# syntax for the where clause.</returns>
        public static string FormatCSharpGenericWhereClauseSyntax(this CsGenericParameter source)
        {
            var dotNetGenericParameter = source as IDotNetGenericParameter;
            return dotNetGenericParameter.FormatCSharpGenericWhereClauseSyntax();
        }

        /// <summary>
        /// Extension method that generates the fully qualified type name from the <see cref="ICsType"/> model in the C# format.
        /// </summary>
        /// <param name="source">The source type to get the full type name from.</param>
        /// <returns>The fully qualified namespace and full type definition. Null if the type is missing or not loaded. </returns>
        public static string FormatCSharpFullTypeName(this CsType source)
        {
            var dotNetType = source as IDotNetType;
            return dotNetType.FormatCSharpFullTypeName();
        }

        /// <summary>
        /// Extension method that creates a C# signature for the tuple type.
        /// </summary>
        /// <param name="source">The target declaration syntax for a tuple.</param>
        /// <returns>The formatted tuple or null if data is missing.</returns>
        public static string FormatCSharpTupleSignatureSyntax(this CsType source)
        {
            var dotNetType = source as IDotNetType;
            return dotNetType.FormatCSharpTupleSignatureSyntax();
        }

        /// <summary>
        /// Extension method that creates the array portion definition of a type definition in C# syntax.
        /// </summary>
        /// <param name="source">The source type to get the array information to format.</param>
        /// <returns>The formatted array syntax for the target type, or null if no array data was provided in the type definition.</returns>
        public static string FormatCSharpArraySignatureSyntax(this CsType source)
        {
            var dotNetType = source as IDotNetType;
            return dotNetType.FormatCSharpArraySignatureSyntax();
        }

        /// <summary>
        /// Extension method that create the fully formatted parameters section in c# syntax.
        /// </summary>
        /// <param name="source">The source list of parameters to be turned into a parameters signature.</param>
        /// <returns>The fully formatted parameters signature or null if data was missing.</returns>
        public static string FormatCSharpParametersSignatureSyntax(this IReadOnlyList<CsParameter> source)
        {
            var dotNetParameters = source as IReadOnlyList<IDotNetParameter>;
            return dotNetParameters.FormatCSharpParametersSignatureSyntax();
        }

        /// <summary>
        /// Extension method that generates the default value syntax for a parameter in the C# language.
        /// </summary>
        /// <param name="source">The target default value to format.</param>
        /// <param name="type">The target type of the value to be formatted.</param>
        /// <returns>The fully formatted syntax for the default value or null if data was missing.</returns>
        public static string FormatCSharpParameterDefaultValueSyntax(this CsParameterDefaultValue source, CsType type)
        {
            var dotNetParameterDefaultValue = source as IDotNetParameterDefaultValue;
            var dotNetType = type as IDotNetType;
            return dotNetParameterDefaultValue.FormatCSharpParameterDefaultValueSyntax(dotNetType);
        }
        /// <summary>
        /// Extension method that returns a full attribute declaration in the C# language format.
        /// </summary>
        /// <param name="source">The attribute toe generate the c# signature for.</param>
        /// <returns></returns>
        public static string FormatCSharpAttributeSignatureSyntax(this CsAttribute source)
        {
            var dotNetAttribute = source as IDotNetAttribute;
            return dotNetAttribute.FormatCSharpAttributeSignatureSyntax();
        }

        /// <summary>
        /// Extension method that creates the attributes parameters list for a attribute definition in c# syntax format.
        /// </summary>
        /// <param name="source">THe source list of parameters to be created.</param>
        /// <returns>The fully formatted parameters section of a attribute declaration.</returns>
        public static string FormatCSharpAttributeParametersSignatureSyntax(this IReadOnlyList<CsAttributeParameter> source)
        {
            var dotNetAttributeParameters = source as IReadOnlyList<IDotNetAttributeParameter>;
            return dotNetAttributeParameters.FormatCSharpAttributeParametersSignatureSyntax();
        }

        /// <summary>
        /// Creates the implementation of an attribute value formatted for c#.
        /// </summary>
        /// <param name="source">The source value to format.</param>
        /// <returns>The formatted value, or null if the model does not exist.</returns>
        public static string FormatCSharpAttributeParameterValueSignatureSyntax(this CsAttributeParameterValue source)
        {
            var dotNetAttributeParameterValue = source as IDotNetAttributeParameterValue;
            return dotNetAttributeParameterValue.FormatCSharpAttributeParameterValueSignatureSyntax();
        }

        /// <summary>
        /// Extension method that returns a value declaration in the c# language format.
        /// </summary>
        /// <param name="source">The target type to create the value definition for.</param>
        /// <param name="value">The value to be formatted.</param>
        /// <returns>The definition of the value formatted for C#</returns>
        public static string FormatCSharpValueSyntax(this CsType source, string value)
        {
            var dotNetType = source as IDotNetType;
            return dotNetType.FormatCSharpValueSyntax(value);
        }

        /// <summary>
        /// Extension method that will lookup the enumeration type based on the provided value.
        /// </summary>
        /// <param name="source">The target <see cref="CsEnum"/> model to get the enumeration type from.</param>
        /// <param name="value">The target numerical value to use to lookup the enumeration type.</param>
        /// <returns>The fully qualified enumeration type or null if the enumeration type could not be found.</returns>
        public static string FormatCSharpEnumTypeSyntax(this CsEnum source, string value)
        {
            var dotNetEnum = source as IDotNetEnum;
            return dotNetEnum.FormatCSharpEnumTypeSyntax(value);
        }

        /// <summary>
        /// Extension method that will lookup the value of an enumeration by the enumeration type name.
        /// </summary>
        /// <param name="source">The target <see cref="IDotNetEnum"/> model to get the enumeration value from.</param>
        /// <param name="enumName">The target numerical named item to use to lookup the enumeration value.</param>
        /// <returns>The target enumeration value or null if it could not be found.</returns>
        public static string FormatCSharpEnumValueSyntax(this CsEnum source, string enumName)
        {
            var dotNetEnum = source as IDotNetEnum;

            return dotNetEnum.FormatCSharpEnumValueSyntax(enumName);

        }
    }
}
