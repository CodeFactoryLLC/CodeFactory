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
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsClass"/> model.
    /// </summary>
    public static class CsClassExtensions
    {
        /// <summary>
        /// Defines the fully qualified base type name for the class model.
        /// </summary>
        /// <param name="source">The source interface model to generate the type name from.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <returns>The full type name or null if model data was missing.</returns>
        public static string CSharpFormatBaseTypeName(this CsClass source, NamespaceManager manager = null)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            StringBuilder baseNameBuilder = new StringBuilder();
            var namespaceManager = manager ?? new NamespaceManager(null);

            var targetNamespace = namespaceManager.AppendingNamespace(source.Namespace);

            baseNameBuilder.Append(targetNamespace == null ? source.Name : $"{targetNamespace}.{source.Name}");
            
            
            if (source.IsGeneric)
                baseNameBuilder.Append(
                    source.GenericParameters.CSharpFormatGenericParametersSignature(namespaceManager));

            return baseNameBuilder.ToString();
        }

        /// <summary>
        /// Extension method that generates a the full class declaration syntax based on the provided model.
        /// </summary>
        /// <example>
        /// Format with no generics [security] class [name] [:[base class*], [inherited interfaces*]]
        /// Format with generics [security] class [name] &lt;[generic parameters]&gt; [: [base class*], [inherited interfaces*]] [Generic Where Clauses*]
        /// </example>
        /// <param name="source">The source class model to format.</param>
        /// <param name="security">The security level the class should be implemented as.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <param name="className">Optional parameter that allows you to specify a new name for the class.</param>
        /// <returns>The full class declaration or null if model data was missing.</returns>
        public static string CSharpFormatDeclaration(this CsClass source, CsSecurity security, NamespaceManager manager = null,
            string className = null)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;
            bool hasBaseClass = false;
            var name = className ?? source.Name;
            StringBuilder classBuilder = new StringBuilder($"{security.CSharpFormatKeyword()} {Keywords.Class} {name}");

            if (source.IsGeneric) classBuilder.Append(source.GenericParameters.CSharpFormatGenericParametersSignature(manager));

            if(source.BaseClass != null)
                if (source.BaseClass.Namespace.ToLowerInvariant() == "system" &
                    source.BaseClass.Name.ToLowerInvariant() == "object") hasBaseClass = false;
                else hasBaseClass = true;

            if (hasBaseClass)
            {
                var baseName = source.BaseClass.CSharpFormatBaseTypeName(manager);
                if (string.IsNullOrEmpty(baseName)) return null;
                classBuilder.Append($":{baseName}");
            }

            if (source.InheritedInterfaces.Any())
            {
                var interfaces = source.InheritedInterfaces;

                int totalCount = interfaces.Count;
                int currentInterface = 0;

                classBuilder.Append(hasBaseClass ? ", " :":");

                foreach (var csInterface in interfaces)
                {
                    currentInterface++;

                    var interfaceType = csInterface.CSharpFormatInheritanceTypeName(manager);

                    if (interfaceType == null) continue;

                    classBuilder.Append(interfaceType);
                    if (totalCount > currentInterface) classBuilder.Append(", ");
                }

            }

            if (source.IsGeneric)
            {
                classBuilder.Append(" ");

                foreach (var sourceGenericParameter in source.GenericParameters)
                {
                    var whereClause = sourceGenericParameter.CSharpFormatGenericWhereClauseSignature(manager);
                    if (string.IsNullOrEmpty(whereClause)) continue;

                    classBuilder.Append($"{whereClause} ");

                }
            }

            return classBuilder.ToString();
        }
    }
}
