//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Linq;
using System.Text;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;
namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsType"/> model.
    /// </summary>
    public static class CsTypeExtensions
    {
        /// <summary>
        /// Formats a type name to match the C# syntax for a type deceleration in C#.
        /// </summary>
        /// <param name="source">The type model to use to generate the type signature for c#</param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The formatted type definition for C#</returns>
        public static string CSharpFormatTypeName(this CsType source, NamespaceManager manager = null)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            var namespaceManager = manager ?? new NamespaceManager(null); 

            string returnValue = null;

            string typeName = null;

            if (source.IsWellKnownType)
            {
                switch (source.WellKnownType)
                {
                    case CsKnownLanguageType.NotWellKnown:
                        typeName = null;
                        break;

                    case CsKnownLanguageType.Object:
                        typeName = WellKnownTypes.Object;
                        break;

                    case CsKnownLanguageType.Void:
                        typeName = Keywords.Void;
                        break;

                    case CsKnownLanguageType.Boolean:
                        typeName = WellKnownTypes.Boolean;
                        break;

                    case CsKnownLanguageType.Character:
                        typeName = WellKnownTypes.Character;
                        break;

                    case CsKnownLanguageType.Signed8BitInteger:
                        typeName = WellKnownTypes.SByte;
                        break;

                    case CsKnownLanguageType.UnSigned8BitInteger:
                        typeName = WellKnownTypes.Byte;
                        break;

                    case CsKnownLanguageType.Signed16BitInteger:
                        typeName = WellKnownTypes.Short;
                        break;

                    case CsKnownLanguageType.Unsigned16BitInteger:
                        typeName = WellKnownTypes.Ushort;
                        break;

                    case CsKnownLanguageType.Signed32BitInteger:
                        typeName = WellKnownTypes.Int;
                        break;

                    case CsKnownLanguageType.Unsigned32BitInteger:
                        typeName = WellKnownTypes.Uint;
                        break;

                    case CsKnownLanguageType.Signed64BitInteger:
                        typeName = WellKnownTypes.Long;
                        break;

                    case CsKnownLanguageType.Unsigned64BitInteger:
                        typeName = WellKnownTypes.Ulong;
                        break;

                    case CsKnownLanguageType.Decimal:
                        typeName = WellKnownTypes.Decimal;
                        break;

                    case CsKnownLanguageType.Single:
                        typeName = WellKnownTypes.Float;
                        break;

                    case CsKnownLanguageType.Double:
                        typeName = WellKnownTypes.Double;
                        break;

                    case CsKnownLanguageType.Pointer:
                        typeName = WellKnownTypes.Pointer;
                        break;

                    case CsKnownLanguageType.PlatformPointer:
                        typeName = WellKnownTypes.PlatformPointer;
                        break;

                    case CsKnownLanguageType.DateTime:
                        typeName = WellKnownTypes.Datetime;
                        break;

                    case CsKnownLanguageType.String:
                        typeName = WellKnownTypes.String;
                        break;

                    default:
                        typeName = null;
                        break;
                }
            }
            else
            {
                var targetNamespace = namespaceManager.AppendingNamespace(source.Namespace);

                typeName = targetNamespace == null ? source.Name : $"{targetNamespace}.{source.Name}";

            }

            returnValue = typeName;

            if (source.IsGeneric) returnValue = $"{typeName}{source.GenericParameters.CSharpFormatGenericParametersSignature(namespaceManager)}";
            if (source.IsArray) returnValue = $"{typeName}{source.CSharpFormatArraySignature()}";
            if (source.IsTuple) returnValue = source.CSharpFormatTupleSignature(namespaceManager);
            return returnValue;
        }

        /// <summary>
        /// Extension method that creates a C# signature for the tuple type.
        /// </summary>
        /// <param name="source">The target declaration syntax for a tuple.</param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The formatted tuple or null if data is missing.</returns>
        public static string CSharpFormatTupleSignature(this CsType source , NamespaceManager manager = null)
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
                    ? $"{sourceParameter.TupleType.CSharpFormatTypeName(manager)} {sourceParameter.Name} "
                    : sourceParameter.TupleType.CSharpFormatTypeName(manager));

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
        public static string CSharpFormatArraySignature(this CsType source)
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
        /// Extension method that returns a value declaration in the C# language format.
        /// </summary>
        /// <param name="source">The target type to create the value definition for.</param>
        /// <param name="value">The value to be formatted.</param>
        /// <returns>The definition of the value formatted for C#</returns>
        public static string CSharpFormatValueSyntax(this CsType source, string value)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            if (source.Name == "Type" & source.Namespace == "System") return $"typeof({value})";

            if (source.IsEnum)
            {
                try
                {
                    var enumData = source.GetEnumModel();


                    return enumData?.CSharpFormatEnumValue(value);
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

                case CsKnownLanguageType.Void:

                    result = Keywords.Void;

                    break;
                case CsKnownLanguageType.Boolean:

                    result = value.ToLower();
                    break;

                case CsKnownLanguageType.Character:
                    result = $"'{value}'";
                    break;

                case CsKnownLanguageType.String:
                    result = $"\"{value}\"";
                    break;

                default:
                    result = value;
                    break;
            }

            return result;
        }
    }
}
