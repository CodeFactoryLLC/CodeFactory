//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System.Linq;
using System.Text;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsStructure"/> model.
    /// </summary>
    public static class CsStructureExtensions
    {
        /// <summary>
        /// Defines the fully qualified type name for the structure model.
        /// </summary>
        /// <param name="source">The source structure model to generate the type name from.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <returns>The full type name or null if model data was missing.</returns>
        public static string CSharpFormatTypeName(this CsStructure source, NamespaceManager manager = null)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            StringBuilder structureNameBuilder = new StringBuilder();
            var namespaceManager = manager ?? new NamespaceManager(null);

            var formattedNamespace = namespaceManager.AppendingNamespace(source.Namespace);

            structureNameBuilder.Append(
                formattedNamespace == null ? source.Name : $"{formattedNamespace}.{source.Name}");

            if (source.IsGeneric)
                structureNameBuilder.Append(
                    source.GenericParameters.CSharpFormatGenericParametersSignature(namespaceManager));

            return structureNameBuilder.ToString();
        }

        /// <summary>
        /// Extension method that generates a the full interface declaration syntax based on the provided model.
        /// </summary>
        /// <example>
        /// Format with no generics [security] struct [name] [:[inherited interfaces*]]
        /// Format with generics [security] struct [name] &lt;[generic parameters]&gt; [: [inherited interfaces*]] [Generic Where Clauses*]
        /// </example>
        /// <param name="source">The source structure model to format.</param>
        /// <param name="security">The security level the structure should be implemented as.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <param name="interfaceName">Optional parameter that allows you to specify a new name for the structure.</param>
        /// <returns>The full structure declaration or null if model data was missing.</returns>
        public static string CSharpFormatDeclaration(this CsStructure source, CsSecurity security, NamespaceManager manager = null,
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
