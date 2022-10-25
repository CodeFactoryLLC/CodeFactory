//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{    
     /// <summary>
     /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsSecurity"/> model.
     /// </summary>
    public static class CsSecurityExtensions
    {
        /// <summary>
        /// Gets the security keyword for the C# language.
        /// </summary>
        /// <param name="source">The source security object to get the keyword from.</param>
        /// <returns>The name of the security keyword or null.</returns>
        public static string CSharpFormatKeyword(this CsSecurity source)
        {
            string result;

            switch (source)
            {
                case CsSecurity.Public:
                    result = Security.Public;
                    break;

                case CsSecurity.Protected:
                    result = Security.Protected;
                    break;

                case CsSecurity.Internal:
                    result = Security.Internal;
                    break;

                case CsSecurity.Private:
                    result = Security.Private;
                    break;
                case CsSecurity.ProtectedInternal:
                    result = Security.ProtectedInternal;
                    break;

                case CsSecurity.ProtectedOrInternal:
                    result = Security.PrivateProtected;
                    break;

                case CsSecurity.Unknown:
                    result = null;
                    break;

                default:
                    result = null;
                    break;
            }

            return result;
        }
    }
}
