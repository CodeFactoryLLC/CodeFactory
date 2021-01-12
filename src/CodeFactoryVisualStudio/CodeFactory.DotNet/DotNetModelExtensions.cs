//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Extension methods that support models that implement <see cref="IDotNetModel"/>
    /// </summary>
    public static class DotNetModelExtensions
    {

        /// <summary>
        /// Gets the security keyword for the C# language.
        /// </summary>
        /// <param name="source">The source security object to get the keyword from.</param>
        /// <returns>The name of the security keyword or null.</returns>
        public static string FormatCSharpSyntax(this DotNetSecurity source)
        {
            string result;

            switch (source)
            {
                case DotNetSecurity.Public:
                    result = Security.Public;
                    break;

                case DotNetSecurity.Protected:
                    result = Security.Protected;
                    break;

                case DotNetSecurity.Internal:
                    result = Security.Internal;
                    break;

                case DotNetSecurity.Private:
                    result = Security.Private;
                    break;
                case DotNetSecurity.ProtectedInternal:
                    result = Security.ProtectedInternal;
                    break;

                case DotNetSecurity.ProtectedOrInternal:
                    result = Security.PrivateProtected;
                    break;

                case DotNetSecurity.Unknown:
                    result = null;
                    break;

                default:
                    result = null;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Extension method that generates the generics definition part of a signature in the C# format.
        /// </summary>
        /// <param name="source">The target types that make up the generics signature.</param>
        /// <returns>The fully formatted definition of the generics signature, or null if the source is not provided. </returns>
        public static string FormatCSharpGenericSignatureSyntax(this IReadOnlyList<IDotNetGenericParameter> source)
        {
            if (source == null) return null;
            if (!source.Any()) return null;

            StringBuilder genericsSignature = new StringBuilder(Symbols.GenericDefinitionStart);

            int totalParameters = source.Count;
            int currentParameter = 0;
            foreach (var sourceGenericParameter in source)
            {
                currentParameter++;
                genericsSignature.Append(sourceGenericParameter.Type.IsGenericPlaceHolder ? sourceGenericParameter.Type.Name : sourceGenericParameter.Type.FormatCSharpFullTypeName());
                if (totalParameters > currentParameter) genericsSignature.Append(", ");
            }

            genericsSignature.Append(Symbols.GenericDefinitionEnd);

            return genericsSignature.ToString();
        }

        /// <summary>
        /// Extension method that generates the where clause for a generic parameter if one exists. This will not generate if the generic parameter is not a place holder type, or if no where clause conditions have been provided.
        /// </summary>
        /// <param name="source">Generic parameter to generate the where clause from.</param>
        /// <returns>Null if the where clause was not generated, or the C# syntax for the where clause.</returns>
        public static string FormatCSharpGenericWhereClauseSyntax(this IDotNetGenericParameter source)
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
                        ? $", {sourceConstrainingType.FormatCSharpFullTypeName()}"
                        : sourceConstrainingType.FormatCSharpFullTypeName());
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

        /// <summary>
        /// Extension method that generates the fully qualified type name from the <see cref="IDotNetType"/> model in the C# format.
        /// </summary>
        /// <param name="source">The source type to get the full type name from.</param>
        /// <returns>The fully qualified namespace and full type definition. Null if the type is missing or not loaded. </returns>
        public static string FormatCSharpFullTypeName(this IDotNetType source)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            string typeName = null;
            string returnValue = null;

            if (source.IsWellKnownType)
            {
                switch (source.WellKnownType)
                {
                    case WellKnownLanguageType.NotWellKnown:
                        typeName = null;
                        break;

                    case WellKnownLanguageType.Object:
                        typeName = WellKnownTypes.Object;
                        break;

                    case WellKnownLanguageType.Void:
                        typeName = Keywords.Void;
                        break;

                    case WellKnownLanguageType.Boolean:
                        typeName = WellKnownTypes.Boolean;
                        break;

                    case WellKnownLanguageType.Character:
                        typeName = WellKnownTypes.Character;
                        break;

                    case WellKnownLanguageType.Signed8BitInteger:
                        typeName = WellKnownTypes.SByte;
                        break;

                    case WellKnownLanguageType.UnSigned8BitInteger:
                        typeName = WellKnownTypes.Byte;
                        break;

                    case WellKnownLanguageType.Signed16BitInteger:
                        typeName = WellKnownTypes.Short;
                        break;

                    case WellKnownLanguageType.Unsigned16BitInteger:
                        typeName = WellKnownTypes.Ushort;
                        break;

                    case WellKnownLanguageType.Signed32BitInteger:
                        typeName = WellKnownTypes.Int;
                        break;

                    case WellKnownLanguageType.Unsigned32BitInteger:
                        typeName = WellKnownTypes.Uint;
                        break;

                    case WellKnownLanguageType.Signed64BitInteger:
                        typeName = WellKnownTypes.Long;
                        break;

                    case WellKnownLanguageType.Unsigned64BitInteger:
                        typeName = WellKnownTypes.Ulong;
                        break;

                    case WellKnownLanguageType.Decimal:
                        typeName = WellKnownTypes.Decimal;
                        break;

                    case WellKnownLanguageType.Single:
                        typeName = WellKnownTypes.Float;
                        break;

                    case WellKnownLanguageType.Double:
                        typeName = WellKnownTypes.Double;
                        break;

                    case WellKnownLanguageType.Pointer:
                        typeName = WellKnownTypes.Pointer;
                        break;

                    case WellKnownLanguageType.PlatformPointer:
                        typeName = WellKnownTypes.PlatformPointer;
                        break;

                    case WellKnownLanguageType.DateTime:
                        typeName = WellKnownTypes.Datetime;
                        break;

                    case WellKnownLanguageType.String:
                        typeName = WellKnownTypes.String;
                        break;

                    default:
                        typeName = null;
                        break;
                }
            }
            else typeName = $"{source.Namespace}.{source.Name}";

            returnValue = typeName;
            if (source.IsGeneric) returnValue = $"{typeName}{source.GenericParameters.FormatCSharpGenericSignatureSyntax()}";
            if (source.IsArray) returnValue = $"{typeName}{source.FormatCSharpArraySignatureSyntax()}";
            if (source.IsTuple) returnValue = source.FormatCSharpTupleSignatureSyntax();
            return returnValue;
        }

        /// <summary>
        /// Extension method that creates a C# signature for the tuple type.
        /// </summary>
        /// <param name="source">The target declaration syntax for a tuple.</param>
        /// <returns>The formatted tuple or null if data is missing.</returns>
        public static string FormatCSharpTupleSignatureSyntax(this IDotNetType source)
        {
            if (source == null) return null;
            if (!source.IsTuple) return null;

            if (!source.TupleTypes.Any()) return null;

            StringBuilder tupleSignature = new StringBuilder(Symbols.ParametersDefinitionStart);

            int totalParameters = source.TupleTypes.Count;
            int currentParameter = 0;
            foreach (var sourceParameter in source.TupleTypes)
            {
                currentParameter++;

                tupleSignature.Append(!sourceParameter.HasDefaultName
                    ? $"{sourceParameter.TupleType.FormatCSharpFullTypeName()} {sourceParameter.Name} "
                    : sourceParameter.TupleType.FormatCSharpFullTypeName());

                if (totalParameters > currentParameter) tupleSignature.Append(", ");
            }

            tupleSignature.Append(Symbols.ParametersDefinitionEnd);

            return tupleSignature.ToString();
        }

        /// <summary>
        /// Extension method that creates the array portion definition of a type definition in C# syntax.
        /// </summary>
        /// <param name="source">The source type to get the array information to format.</param>
        /// <returns>The formatted array syntax for the target type, or null if no array data was provided in the type definition.</returns>
        public static string FormatCSharpArraySignatureSyntax(this IDotNetType source)
        {
            if (source == null) return null;
            if (!source.IsArray) return null;

            var arraySignatureBuilder = new StringBuilder();

            foreach (var sourceArrayDimension in source.ArrayDimensions)
            {
                arraySignatureBuilder.Append(sourceArrayDimension == 1
                    ? $"{Symbols.ArrayDefinitionStart}{Symbols.ArrayDefinitionEnd}"
                    : $"{Symbols.ArrayDefinitionStart}{new string(',', sourceArrayDimension - 1)}{Symbols.ArrayDefinitionEnd}");
            }

            return arraySignatureBuilder.ToString();

        }

        /// <summary>
        /// Extension method that create the fully formatted parameters section in c# syntax.
        /// </summary>
        /// <param name="source">The source list of parameters to be turned into a parameters signature.</param>
        /// <returns>The fully formatted parameters signature or null if data was missing.</returns>
        public static string FormatCSharpParametersSignatureSyntax(this IReadOnlyList<IDotNetParameter> source)
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
                        parameterSignature.Append($"{sourceParameterAttribute.FormatCSharpAttributeSignatureSyntax()} ");
                    }
                }
                if(sourceParameter.IsOut) parameterSignature.Append($"{Keywords.Out} ");
                if(sourceParameter.IsRef) parameterSignature.Append($"{Keywords.Ref} ");
                if(sourceParameter.IsParams) parameterSignature.Append($"{Keywords.Params} ");
                parameterSignature.Append(!sourceParameter.IsOptional
                    ? $"{sourceParameter.ParameterType.FormatCSharpFullTypeName()} {sourceParameter.Name}"
                    : $"{sourceParameter.ParameterType.FormatCSharpFullTypeName()} {sourceParameter.Name} = {sourceParameter.DefaultValue.FormatCSharpParameterDefaultValueSyntax(sourceParameter.ParameterType)}");

                if (totalParameters > currentParameter) parameterSignature.Append(", ");
            }

            parameterSignature.Append(Symbols.ParametersDefinitionEnd);

            return parameterSignature.ToString();
        }

        /// <summary>
        /// Extension method that generates the default value syntax for a parameter in the C# language.
        /// </summary>
        /// <param name="source">The target default value to format.</param>
        /// <param name="type">The target type of the value to be formatted.</param>
        /// <returns>The fully formatted syntax for the default value or null if data was missing.</returns>
        public static string FormatCSharpParameterDefaultValueSyntax(this IDotNetParameterDefaultValue source, IDotNetType type)
        {
            if (source == null) return null;
            if (type == null) return null;

            string result = null;

            switch (source.ValueType)
            {
                
                case ParameterDefaultValueType.Value:

                    result = type.FormatCSharpValueSyntax(source.Value);
                    break;

                case ParameterDefaultValueType.DefaultKeyWord:

                    result = Keywords.Default;
                    break;

                case ParameterDefaultValueType.NullKeyword:

                    result = Keywords.Null;
                    break;

                default:
                    result = null;
                    break;
            }

            return result;

        }
        /// <summary>
        /// Extension method that returns a full attribute declaration in the C# language format.
        /// </summary>
        /// <param name="source">The attribute toe generate the c# signature for.</param>
        /// <returns></returns>
        public static string FormatCSharpAttributeSignatureSyntax(this IDotNetAttribute source)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            return !source.HasParameters ? $"[{source.Type.FormatCSharpFullTypeName()}{Symbols.ParametersDefinitionStart}{Symbols.ParametersDefinitionEnd}]" : $"[{source.Type.FormatCSharpFullTypeName()}{source.Parameters.FormatCSharpAttributeParametersSignatureSyntax()}]";
        }

        /// <summary>
        /// Extension method that creates the attributes parameters list for a attribute definition in c# syntax format.
        /// </summary>
        /// <param name="source">THe source list of parameters to be created.</param>
        /// <returns>The fully formatted parameters section of a attribute declaration.</returns>
        public static string FormatCSharpAttributeParametersSignatureSyntax(this IReadOnlyList<IDotNetAttributeParameter> source)
        {
            if (source == null) return null;
            if (!source.Any()) return null;

            StringBuilder attributeParameterSignature = new StringBuilder(Symbols.ParametersDefinitionStart);

            int totalParameters = source.Count;
            int currentParameter = 0;
            foreach (var sourceParameter in source)
            {
                currentParameter++;
                string parameter = !sourceParameter.HasNamedParameter ? $"{sourceParameter.Value.FormatCSharpAttributeParameterValueSignatureSyntax()}" : $"{sourceParameter.Name} = {sourceParameter.Value.FormatCSharpAttributeParameterValueSignatureSyntax()}";

                attributeParameterSignature.Append(parameter);
                if (totalParameters > currentParameter) attributeParameterSignature.Append(", ");
            }

            attributeParameterSignature.Append(Symbols.ParametersDefinitionEnd);

            return attributeParameterSignature.ToString();
        }

        /// <summary>
        /// Creates the implementation of an attribute value formatted for C#.
        /// </summary>
        /// <param name="source">The source value to format.</param>
        /// <returns>The formatted value, or null if the model does not exist.</returns>
        public static string FormatCSharpAttributeParameterValueSignatureSyntax(this IDotNetAttributeParameterValue source)
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
                string value = sourceValue.ParameterKind != AttributeParameterKind.Array ? $"{sourceValue.TypeValue.FormatCSharpValueSyntax(sourceValue.Value)}" : $"{sourceValue.FormatCSharpAttributeParameterValueSignatureSyntax()}";

                attributeValueSignature.Append(value);
                if (totalParameters < currentValue) attributeValueSignature.Append(", ");
            }

            attributeValueSignature.Append($"{Symbols.MultipleStatementEnd}");

            return attributeValueSignature.ToString();
        }

        /// <summary>
        /// Extension method that returns a value declaration in the C# language format.
        /// </summary>
        /// <param name="source">The target type to create the value definition for.</param>
        /// <param name="value">The value to be formatted.</param>
        /// <returns>The definition of the value formatted for C#</returns>
        public static string FormatCSharpValueSyntax(this IDotNetType source, string value)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            if (source.Name == "Type" & source.Namespace == "System") return $"typeof({value})";

            if (source.IsEnum)
            {
                try
                {
                    var enumData = source.GetEnumModel();
                    

                    return enumData?.FormatCSharpEnumTypeSyntax(value);
                }
                catch (Exception)
                {
                    return null;
                }
            }

            if (!source.IsWellKnownType)
            {
                return value;
            }

            string result = null;

            switch (source.WellKnownType)
            {

                case WellKnownLanguageType.Void:

                    result = Keywords.Void;

                    break;
                case WellKnownLanguageType.Boolean:

                    result = value.ToLower();
                    break;

                case WellKnownLanguageType.Character:
                    result = $"'{value}'";
                    break;

                case WellKnownLanguageType.String:
                    result = $"\"{value}\"";
                    break;

                default:
                    result = value;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Extension method that will lookup the enumeration type based on the provided value.
        /// </summary>
        /// <param name="source">The target <see cref="IDotNetEnum"/> model to get the enumeration type from.</param>
        /// <param name="value">The target numerical value to use to lookup the enumeration type.</param>
        /// <returns>The fully qualified enumeration type or null if the enumeration type could not be found.</returns>
        public static string FormatCSharpEnumTypeSyntax(this IDotNetEnum source, string value)
        {
            if (source == null) return null;
            if (string.IsNullOrEmpty(value)) return null;
            if (!source.Values.Any()) return null;

            var enumValue = source.Values.Where(v => string.Equals(v.Value,value)).Select(v => v.Name).FirstOrDefault();

            return enumValue != null ? $"{source.Namespace}.{source.Name}.{enumValue}" : null;
        }

        /// <summary>
        /// Extension method that will lookup the value of an enumeration by the enumeration type name.
        /// </summary>
        /// <param name="source">The target <see cref="IDotNetEnum"/> model to get the enumeration value from.</param>
        /// <param name="enumName">The target numerical named item to use to lookup the enumeration value.</param>
        /// <returns>The target enumeration value or null if it could not be found.</returns>
        public static string FormatCSharpEnumValueSyntax(this IDotNetEnum source, string enumName)
        {
            if (source == null) return null;
            if (string.IsNullOrEmpty(enumName)) return null;
            if (!source.Values.Any()) return null;

            var enumValue = source.Values.Where(v => string.Equals(v.Name, enumName)).Select(v => v.Value).FirstOrDefault();

            return enumValue;

        }


    }
}
