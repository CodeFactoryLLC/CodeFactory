//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.DotNet;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsParameterDefaultValue"/> model.
    /// </summary>
    public static class CsParameterDefaultValueExtensions
    {
        /// <summary>
        /// Extension method that generates the default value syntax for a parameter in the C# language.
        /// </summary>
        /// <param name="source">The target default value to format.</param>
        /// <param name="type">The target type of the value to be formatted.</param>
        /// <returns>The fully formatted syntax for the default value or null if data was missing.</returns>
        public static string CSharpFormatParameterDefaultValue(this CsParameterDefaultValue source, CsType type)
        {
            if (source == null) return null;
            if (type == null) return null;

            string result = null;

            switch (source.ValueType)
            {

                case ParameterDefaultValueType.Value:

                    result = type.CSharpFormatValueSyntax(source.Value);
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
    }
}
