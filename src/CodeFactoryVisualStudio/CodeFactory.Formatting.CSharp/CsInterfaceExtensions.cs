//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsInterface"/> model.
    /// </summary>
    public static class CsInterfaceExtensions
    {
        /// <summary>
        /// Defines the fully qualified inheritance type name for the interface model.
        /// </summary>
        /// <param name="source">The source interface model to generate the type name from.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <returns>The full type name or null if model data was missing.</returns>
        public static string CSharpFormatInheritanceTypeName(this CsInterface source, NamespaceManager manager = null)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            StringBuilder interfaceNameBuilder = new StringBuilder();
            var namespaceManager = manager ?? new NamespaceManager(null);

            var targetNamespace = namespaceManager.AppendingNamespace(source.Namespace);
            interfaceNameBuilder.Append(targetNamespace == null ? source.Name : $"{targetNamespace}.{source.Name}");

            if (source.IsGeneric)
                interfaceNameBuilder.Append(
                    source.GenericParameters.CSharpFormatGenericParametersSignature(namespaceManager));

            return interfaceNameBuilder.ToString();
        }

        /// <summary>
        /// Extension method that generates a the full interface declaration syntax based on the provided model.
        /// </summary>
        /// <example>
        /// Format with no generics [security] interface [name] [:[inherited interfaces*]]
        /// Format with generics [security] interface [name] &lt;[generic parameters]&gt; [: [base class*], [inherited interfaces*]] [Generic Where Clauses*]
        /// </example>
        /// <param name="source">The source interface model to format.</param>
        /// <param name="security">The security level the interface should be implemented as.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <param name="interfaceName">Optional parameter that allows you to specify a new name for the interface.</param>
        /// <returns>The full interface declaration or null if model data was missing.</returns>
        public static string CSharpFormatDeclaration(this CsInterface source, CsSecurity security, NamespaceManager manager = null,
            string interfaceName = null)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            var name = interfaceName ?? source.Name;
            StringBuilder interfaceBuilder = new StringBuilder($"{security.CSharpFormatKeyword()} {Keywords.Interface} {name}");

            if (source.IsGeneric) interfaceBuilder.Append(source.GenericParameters.CSharpFormatGenericParametersSignature(manager));
            

            if (source.InheritedInterfaces.Any())
            {
                var interfaces = source.InheritedInterfaces;

                int totalCount = interfaces.Count;
                int currentInterface = 0;

                interfaceBuilder.Append(": ");
                foreach (var csInterface in interfaces)
                {
                    currentInterface++;

                    var interfaceType = csInterface.CSharpFormatInheritanceTypeName(manager);

                    if (interfaceType == null) continue;

                    interfaceBuilder.Append(interfaceType);
                    if (totalCount > currentInterface) interfaceBuilder.Append(", ");
                }

            }

            if (source.IsGeneric)
            {
                interfaceBuilder.Append(" ");

                foreach (var sourceGenericParameter in source.GenericParameters)
                {
                    var whereClause = sourceGenericParameter.CSharpFormatGenericWhereClauseSignature(manager);
                    if (string.IsNullOrEmpty(whereClause)) continue;

                    interfaceBuilder.Append($"{whereClause} ");

                }
            }

            return interfaceBuilder.ToString();
        }
    }
}
