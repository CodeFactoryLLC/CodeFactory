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
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsEnum"/> model.
    /// </summary>
    public static class CsEnumExtensions
    {

        /// <summary>
        /// Extension method that will lookup the value of an enumeration by the enumeration type name.
        /// </summary>
        /// <param name="source">The target <see cref="IDotNetEnum"/> model to get the enumeration value from.</param>
        /// <param name="enumName">The target numerical named item to use to lookup the enumeration value.</param>
        /// <returns>The target enumeration value or null if it could not be found.</returns>
        public static string CSharpFormatEnumValue(this CsEnum source, string enumName)
        {
            if (source == null) return null;
            if (string.IsNullOrEmpty(enumName)) return null;
            if (!source.Values.Any()) return null;

            var enumValue = source.Values.Where(v => string.Equals(v.Name, enumName)).Select(v => v.Value).FirstOrDefault();

            return enumValue;

        }
    }
}
