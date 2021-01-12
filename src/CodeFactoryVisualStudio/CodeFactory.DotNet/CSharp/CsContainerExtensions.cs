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
    /// Extension management class that manages dot net models that implement the <see cref="ICsContainer"/> interface.
    /// </summary>
    public static class CsContainerExtensions
    {
        /// <summary>
        /// Loads all members from a target model that implements <see cref="CsContainer"/> and returns all members and the comparison hash code for each member.
        /// </summary>
        /// <param name="source">The target container to load members from.</param>
        /// <param name="comparisonType">The type of hash code to build for comparision. Default comparison type is set to the base comparison. </param>
        /// <returns>List of all the hash codes and the members for each hashcode.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the source container is null.</exception>
        public static IReadOnlyList<KeyValuePair<int, CsMember>> FormatCSharpComparisonMembers(
            this CsContainer source, MemberComparisonType comparisonType = MemberComparisonType.Base)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (!source.Members.Any()) return ImmutableList<KeyValuePair<int, CsMember>>.Empty;

            List<KeyValuePair<int, CsMember>> result = new List<KeyValuePair<int, CsMember>>();

            var members = source.Members.Select(m =>
                new KeyValuePair<int, CsMember>(m.FormatCSharpMemberComparisonHashCode(comparisonType), m));

            result.AddRange(members);

            switch (source.ContainerType)
            {
                case CsContainerType.Interface:

                    var interfaceContainer = source as ICsInterface;

                    if (interfaceContainer?.InheritedInterfaces != null)
                    {
                        foreach (var inheritedInterface in interfaceContainer.InheritedInterfaces)
                        {
                            var interfaceMembers = inheritedInterface.FormatCSharpComparisonMembers(comparisonType);
                            if (interfaceMembers.Any()) result.AddRange(interfaceMembers);
                        }
                    }

                    break;
                case CsContainerType.Class:

                    var classContainer = source as ICsClass;

                    if (classContainer?.BaseClass != null)
                    {
                        var baseMembers = classContainer.BaseClass.FormatCSharpComparisonMembers(comparisonType);

                        if (baseMembers.Any()) result.AddRange(baseMembers);
                    }

                    break;

            }

            return result.ToImmutableArray();
        }

        /// <summary>
        /// Creates a list of the interface members that are not implemented in the <see cref="ICsClass"/> model.
        /// </summary>
        /// <param name="source">The source model to check.</param>
        /// <returns>List of models that are missing or an empty list if there are no missing members.</returns>
        /// <exception cref="ArgumentNullException">Throws an argument null exception if the model does not exist.</exception>
        public static IReadOnlyList<CsMember> MissingInterfaceMembers(this CsClass source)
        {
            return MissingContainerInterfaceMembers(source);
        }

        /// <summary>
        /// Creates a list of the interface members that are not implemented in the <see cref="ICsStructure"/> model.
        /// </summary>
        /// <param name="source">The source model to check.</param>
        /// <returns>List of models that are missing or an empty list if there are no missing members.</returns>
        /// <exception cref="ArgumentNullException">Throws an argument null exception if the model does not exist.</exception>
        public static IReadOnlyList<CsMember> MissingInterfaceMembers(this CsStructure source)
        {
            return MissingContainerInterfaceMembers(source);
        }

        /// <summary>
        /// Creates a list of the interface members that are not implemented in the <see cref="ICsContainer"/> model.
        /// </summary>
        /// <param name="source">The source model to check.</param>
        /// <returns>List of models that are missing or an empty list if there are no missing members.</returns>
        /// <exception cref="ArgumentNullException">Throws an argument null exception if the model does not exist.</exception>
        private static IReadOnlyList<CsMember> MissingContainerInterfaceMembers(CsContainer source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (source.ContainerType == CsContainerType.Interface) return ImmutableList<CsMember>.Empty;
            if (source.InheritedInterfaces == null) return ImmutableList<CsMember>.Empty;

            var sourceMembers = source.FormatCSharpComparisonMembers(MemberComparisonType.Security);

            var interfaceMembers = new Dictionary<int, CsMember>();

            foreach (var inheritedInterface in source.InheritedInterfaces)
            {
                var compareMembers = inheritedInterface.FormatCSharpComparisonMembers(MemberComparisonType.Security);
                if (!compareMembers.Any()) continue;

                foreach (var compareMember in compareMembers)
                {
                    if (!interfaceMembers.ContainsKey(compareMember.Key))
                        interfaceMembers.Add(compareMember.Key, compareMember.Value);
                }
            }

            if (!interfaceMembers.Any()) return ImmutableList<CsMember>.Empty;

            return (from interfaceMember in interfaceMembers
                // ReSharper disable once SimplifyLinqExpression
                where !sourceMembers.Any(m => m.Key == interfaceMember.Key)
                select interfaceMember.Value).ToImmutableList();
        }
    }
}