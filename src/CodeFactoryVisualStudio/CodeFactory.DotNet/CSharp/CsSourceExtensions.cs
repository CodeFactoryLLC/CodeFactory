//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsSource"/> model.
    /// </summary>
    public static class CsSourceExtensions
    {
        /// <summary>
        /// Extension method that determines if the source code has a target namespace as a using statement.
        /// </summary>
        /// <param name="source">The source code to search through.</param>
        /// <param name="nameSpace">The namespace to search for in the using statements.</param>
        /// <param name="alias">Optional parameter that captures the alias of the namespace used in the using statement.</param>
        /// <returns>Flag that determines if it has the using statement.</returns>
        public static bool HasUsingStatement(this CsSource source, string nameSpace, string alias = null)
        {
            if (source == null) return false;
            if (string.IsNullOrEmpty(nameSpace)) return false;

            var result = alias == null ? source.NamespaceReferences.Any(ns => ns.ReferenceNamespace == nameSpace)
            : source.NamespaceReferences.Any(ns => (ns.ReferenceNamespace == nameSpace) & (ns.Alias == alias));

            return result;
        }



        /// <summary>
        /// Extension method that will add a using statement to target source code. If the using statement already exists it will simply return the existing source.
        /// </summary>
        /// <param name="source">The source code to update.</param>
        /// <param name="nameSpace">The namespace to be added to the using statement.</param>
        /// <param name="alias">Optional parameter to set if you want an alias assigned to the namespace.</param>
        /// <returns>The updated source code or the original source code if no changes were necessary.</returns>
        public static async Task<CsSource> AddUsingStatementAsync(this CsSource source, string nameSpace, string alias = null)
        {
            // ReSharper disable once ExpressionIsAlwaysNull
            if (source == null) return source;

            if (string.IsNullOrEmpty(nameSpace)) return source;

            if (source.HasUsingStatement(nameSpace, alias)) return source;

            SourceFormatter usingFormatter = new SourceFormatter();
            usingFormatter.AppendCodeLine(0, alias == null ? $"using {nameSpace};" : $"using {alias} = {nameSpace};");

            string usingStatement = usingFormatter.ReturnSource();

            CsSource result = null;

            if (source.NamespaceReferences.Any())
            {
                var lastUsingStatement = source.NamespaceReferences.Last();

                result = await lastUsingStatement.AddAfterAsync(usingStatement);
            }
            else
            {
                result = await source.AddToBeginningAsync(usingStatement);
            }

            return result;
        }

        /// <summary>
        /// Scans members for types that are accessible at the member definition level.
        /// If the namespace is missing will add it to the source code file.
        /// </summary>
        /// <param name="source">The source model to be updated.</param>
        /// <param name="members">The members to be checked for type definitions.</param>
        /// <param name="excludeNamespace">A target namespace that should be excluded from adding to the using statement list. This is generally the target namespace of the code file. This is optional</param>
        /// <returns>Updated Source Model with all the missing namespaces added as using statements.</returns>
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static async Task<CsSource> AddMissingNamespaces(this CsSource source, IEnumerable<CsMember> members, string excludeNamespace = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (!source.IsLoaded) return source;
            if (members == null) return source;
            if (!members.Any()) return source;

            List<string> namespaces = new List<string>();
            CsSource result = source;

            foreach (var member in members)
            {

                switch (member.MemberType)
                {
                    case CsMemberType.Event:

                        if (!(member is CsEvent eventModel)) continue;
                        if (!eventModel.IsLoaded) continue;
                        namespaces.AddUniqueNamespace(eventModel.EventType, excludeNamespace);
                        if (eventModel.HasAttributes) namespaces.AddAttributeNamespaces(eventModel.Attributes, excludeNamespace);

                        break;

                    case CsMemberType.Field:
                        if (!(member is CsField fieldModel)) continue;
                        if (!fieldModel.IsLoaded) continue;

                        namespaces.AddUniqueNamespace(fieldModel.DataType, excludeNamespace);
                        if (fieldModel.HasAttributes) namespaces.AddAttributeNamespaces(fieldModel.Attributes, excludeNamespace);

                        break;

                    case CsMemberType.Method:

                        if (!(member is CsMethod methodModel)) continue;
                        if (!methodModel.IsLoaded) continue;
                        if (!methodModel.IsVoid) namespaces.AddUniqueNamespace(methodModel.ReturnType, excludeNamespace);
                        if (methodModel.HasAttributes) namespaces.AddAttributeNamespaces(methodModel.Attributes, excludeNamespace);
                        if (methodModel.HasParameters)
                        {
                            foreach (var methodModelParameter in methodModel.Parameters)
                            {
                                namespaces.AddUniqueNamespace(methodModelParameter.ParameterType, excludeNamespace);
                                if (methodModelParameter.HasAttributes) namespaces.AddAttributeNamespaces(methodModelParameter.Attributes, excludeNamespace);
                            }
                        }

                        break;
                    case CsMemberType.Property:
                        if (!(member is CsProperty propertyModel)) continue;
                        if (!propertyModel.IsLoaded) continue;
                        namespaces.AddUniqueNamespace(propertyModel.PropertyType, excludeNamespace);
                        if (propertyModel.HasAttributes) namespaces.AddAttributeNamespaces(propertyModel.Attributes, excludeNamespace);
                        break;
                }
            }

            if (!namespaces.Any()) return result;

            foreach (var nameSpace in namespaces)
            {
                result = await result.AddUsingStatementAsync(nameSpace);
            }

            return result;
        }

        /// <summary>
        /// Extension method that is a help to register unique namespaces
        /// </summary>
        /// <param name="source">the source list to add namespaces to.</param>
        /// <param name="targetType">The c# exposed type to be added to the namespace list.</param>
        /// <param name="excludeNamespace">Optional parameter, that provides a target namespace that should not be added to the list.</param>
        private static void AddUniqueNamespace(this List<string> source, CsType targetType, string excludeNamespace = null)
        {
            if (source == null) return;
            if (targetType == null) return;
            if (targetType.IsGenericPlaceHolder) return;
            if (targetType.IsWellKnownType) return;
            var nameSpace = targetType.Namespace;
            if (string.IsNullOrEmpty(nameSpace)) return;

            //Making sure the namespace is not on the exclude list
            if (excludeNamespace != null) if (string.Compare(excludeNamespace, nameSpace, StringComparison.InvariantCulture) == 0) return;

            if (source.All(n => string.Compare(n, nameSpace, StringComparison.InvariantCulture) != 0)) source.Add(nameSpace);
            if (!targetType.IsGeneric) return;

            var parameters = targetType.GenericParameters;
            if (!parameters.Any()) return;

            foreach (var genericParameter in parameters)
            {
                if (genericParameter.Type.IsGenericPlaceHolder) continue;
                source.AddUniqueNamespace(genericParameter.Type, excludeNamespace);
            }
        }

        /// <summary>
        /// Helper method used to cycle through attributes to register their namespaces.
        /// </summary>
        /// <param name="source">List to hold unique namespaces.</param>
        /// <param name="attributes">attributes to have their namespaces registered.</param>
        /// <param name="excludeNamespace">Optional parameter, that provides a target namespace that should not be added to the list.</param>
        private static void AddAttributeNamespaces(this List<string> source, IReadOnlyList<CsAttribute> attributes, string excludeNamespace = null)
        {
            if (source == null) return;
            if (attributes == null) return;
            if (!attributes.Any()) return;

            foreach (var attribute in attributes)
            {
                source.AddUniqueNamespace(attribute.Type, excludeNamespace);
            }
        }
    }
}
