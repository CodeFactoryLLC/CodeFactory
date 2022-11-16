//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System.Text;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsMethod"/> model.
    /// </summary>
    public static class CsMethodExtensions
    {
        /// <summary>
        /// Returns a standard C# method signature
        /// </summary>
        /// <param name="source">The source method to extract the signature from. </param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The c# formatted signature of a standard method signature</returns>
        public static string CSharpFormatStandardMethodSignature(this CsMethod source, NamespaceManager manager = null)
        {
            return source.CSharpFormatMethodSignature(manager,false, true, CsSecurity.Unknown, true,  false);
        }

        /// <summary>
        /// Returns a standard C# method signature the the async keyword when supported.
        /// </summary>
        /// <param name="source">The source method to extract the signature from. </param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The c# formatted signature of a standard method signature with the async keyword when supported</returns>
        public static string CSharpFormatStandardMethodSignatureWithAsync(this CsMethod source, NamespaceManager manager = null)
        {
            return source.CSharpFormatMethodSignature(manager, true, true,CsSecurity.Unknown, true,  false);
        }

        /// <summary>
        /// Returns a standard C# method signature for use in interface definitions
        /// </summary>
        /// <param name="source">The source method to extract the signature from. </param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>The c# formatted signature of a standard method signature with the async keyword when supported</returns>
        public static string CSharpFormatInterfaceMethodSignature(this CsMethod source, NamespaceManager manager = null)
        {
            return source.CSharpFormatMethodSignature(manager, false, false,CsSecurity.Unknown, false, false);
        }

        /// <summary>
        /// Generates a C# method signature from model data. This provides a fully customizable method for generating the signature.
        /// </summary>
        /// <param name="source">The source method data to generate the signature from.</param>
        /// <param name="includeAsyncKeyword">Include the async keyword if the return type is Task</param>
        /// <param name="includeSecurity">Includes the security scope which was defined in the model.</param>
        /// <param name="methodSecurity">Optional parameter that allows you to set the security scope for the method.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the source model.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <param name="manager">Optional parameter that contains all the using statements from the source code, when used will replace namespaces on type definition in code.</param>
        /// <returns>Fully formatted method deceleration or null if the method data was missing.</returns>
        public static string CSharpFormatMethodSignature(this CsMethod source, NamespaceManager manager = null, bool includeAsyncKeyword = true, 
            bool includeSecurity = true, CsSecurity methodSecurity = CsSecurity.Unknown, bool includeKeywords = true, bool includeAbstractKeyword = false)
        {
            if (source == null) return null;
            

            StringBuilder methodFormatting = new StringBuilder();

            if (includeSecurity)
            {
                var formattedSecurity = methodSecurity == CsSecurity.Unknown
                    ? source.Security.CSharpFormatKeyword()
                    : methodSecurity.CSharpFormatKeyword();
                methodFormatting.Append($"{formattedSecurity} ");
            }

            if (includeKeywords)
            {
                if (source.IsStatic) methodFormatting.Append($"{Keywords.Static} ");
                if (source.IsSealed) methodFormatting.Append($"{Keywords.Sealed} ");
                if (includeAbstractKeyword & source.IsAbstract) methodFormatting.Append($"{Keywords.Abstract} ");
                if (source.IsOverride) methodFormatting.Append($"{Keywords.Override} ");
                if (source.IsVirtual) methodFormatting.Append($"{Keywords.Virtual} ");
            }

            if (includeAsyncKeyword)
            {
                //Bug fix for issue #14
                if (source.ReturnType != null) if (source.ReturnType.Name == "Task" & source.ReturnType.Namespace == "System.Threading.Tasks") methodFormatting.Append("async ");
            }

            methodFormatting.Append(source.IsVoid ? $"{Keywords.Void} {source.Name}" : $"{source.ReturnType.CSharpFormatTypeName(manager)} {source.Name}");
            if (source.IsGeneric)
                methodFormatting.Append($"{source.GenericParameters.CSharpFormatGenericParametersSignature(manager)}");

            methodFormatting.Append(source.HasParameters
                ? source.Parameters.CSharpFormatParametersSignature(manager)
                : $"{Symbols.ParametersDefinitionStart}{Symbols.ParametersDefinitionEnd}");

            if (!source.IsGeneric) return methodFormatting.ToString();

            foreach (var sourceGenericParameter in source.GenericParameters)
            {
                var whereClause = sourceGenericParameter.CSharpFormatGenericWhereClauseSignature(manager);

                if (!string.IsNullOrEmpty(whereClause)) methodFormatting.Append($" {whereClause}");
            }

            return methodFormatting.ToString();
        }
    }
}
