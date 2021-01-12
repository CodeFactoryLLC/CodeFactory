//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Extension methods that support model that implement the <see cref="CsMember"/> interface.
    /// </summary>
    public static class CsMemberExtensions
    {
        /// <summary>
        /// Gets the hash code for a formatted model signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="ICsModel"/> model.</param>
        /// <param name="comparisonType">The type of comparision format to use when generating the hashcode. Default is set to the base comparision type.</param>
        /// <returns>The has code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the model is null.</exception>
        public static int FormatCSharpMemberComparisonHashCode(this CsMember source,
            MemberComparisonType comparisonType = MemberComparisonType.Base)
        {
            var dotNetMember = source as IDotNetMember;
            return dotNetMember.FormatCSharpMemberComparisonHashCode(comparisonType);
        }


        /// <summary>
        /// Generates the syntax definition of field in c# syntax. The default definition with all options turned off will return the filed signature and constants if defined and the default values.
        /// </summary>
        /// <param name="source">The source <see cref="ICsField"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which the field was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the field from the source model.</param>
        /// <returns>Fully formatted field definition or null if the field data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this CsField source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true)
        {
            var dotNetField = source as IDotNetField;
            return dotNetField.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords);
        }

        /// <summary>
        /// Gets the hash code for a formatted field signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="CsField"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords other then constant are included in the definition. By default this is false.</param>
        /// <returns>The has code of the formatted field.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this CsField source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            var dotNetField = source as IDotNetField;
            return dotNetField.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes, includeKeywords);
        }

        /// <summary>
        /// Generates the syntax definition of a default no backing fields property definition in c# syntax.
        /// </summary>
        /// <param name="source">The source <see cref="CsProperty"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which the property was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the property from the source model.</param>
        /// <returns>Fully formatted property definition or null if the property data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this CsProperty source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true)
        {
            var dotNetProperty = source as IDotNetProperty;
            return dotNetProperty.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords);

        }

        /// <summary>
        /// Gets the hash code for a formatted property signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="CsProperty"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords are included in the definition. By default this is false.</param>
        /// <returns>The hash code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the  model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this CsProperty source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            var dotNetProperty = source as IDotNetProperty;
            return dotNetProperty.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes, includeKeywords);
        }

        /// <summary>
        /// Generates the syntax definition of an event in c# syntax. 
        /// </summary>
        /// <param name="source">The source <see cref="CsEvent"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the source model.</param>
        /// <returns>Fully formatted event definition or null if the event data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this CsEvent source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true)
        {
            var dotNetEvent = source as IDotNetEvent;
            return dotNetEvent.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords);

        }

        /// <summary>
        /// Gets the hash code for a formatted event signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="CsEvent"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords are included in the definition. By default this is false.</param>
        /// <returns>The hash code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the  model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this CsEvent source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            var dotNetEvent = source as IDotNetEvent;
            return dotNetEvent.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes, includeKeywords);
        }

        /// <summary>
        /// Generates the syntax definition of an method in c# syntax. 
        /// </summary>
        /// <param name="source">The source <see cref="CsMethod"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the source model.</param>
        /// <returns>Fully formatted event definition or null if the event data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this CsMethod source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true)
        {
            var dotNetMethod = source as IDotNetMethod;
            return dotNetMethod.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords);

        }

        /// <summary>
        /// Gets the hash code for a formatted method signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="CsMethod"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords are included in the definition. By default this is false.</param>
        /// <returns>The hash code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the  model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this CsMethod source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            var dotNetMethod = source as IDotNetMethod;
            return dotNetMethod.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes, includeKeywords);
        }

        /// <summary>
        /// Extension method that checks a <see cref="CsSource"/> model and determines if the classes and structures in the source have any missing interface members.
        /// </summary>
        /// <param name="source">The source implementation to validate.</param>
        /// <returns>The list of missing members by target container, or an empty list if nothing is missing.</returns>
        public static IReadOnlyList<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>> SourceMissingInterfaceMembers(
            this ICsSource source)
        {
            if (source == null) return ImmutableList<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>>.Empty;
            if (!source.IsLoaded) return ImmutableList<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>>.Empty;

            var results = new List<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>>();

            if (source.Classes.Any())
            {
                results.AddRange(from codeClass in source.Classes let members = codeClass.MissingInterfaceMembers() where members.Any() select new KeyValuePair<CsContainer, IReadOnlyList<CsMember>>(codeClass, members));
            }

            if (source.Structures.Any())
            {
                results.AddRange(from codeStructure in source.Structures let members = codeStructure.MissingInterfaceMembers() where members.Any() select new KeyValuePair<CsContainer, IReadOnlyList<CsMember>>(codeStructure, members));
            }

            return results.ToImmutableList();
        }
    }
}
