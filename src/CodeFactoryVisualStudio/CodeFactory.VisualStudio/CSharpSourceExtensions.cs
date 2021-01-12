//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Extensions management class for the model <see cref="IVsCSharpSource"/>
    /// </summary>
    public static class CSharpSourceExtensions
    {

        /// <summary>
        /// Extension method that checks a <see cref="IVsCSharpSource"/> model and determines if the classes and structures in the source have any missing interface members.
        /// </summary>
        /// <param name="source">The source implementation to validate.</param>
        /// <returns>The list of missing members by target container, or an empty list if nothing is missing.</returns>
        public static IReadOnlyList<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>> SourceMissingInterfaceMembers(
            this VsCSharpSource source)
        {
            if (source == null) return ImmutableList<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>>.Empty;
            if(!source.IsLoaded) return ImmutableList<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>>.Empty;

            if(!source.SourceCode.IsLoaded) return ImmutableList<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>>.Empty;

            var results = new List<KeyValuePair<CsContainer, IReadOnlyList<CsMember>>>();

            if (source.SourceCode.Classes.Any())
            {
                results.AddRange(from codeClass in source.SourceCode.Classes let members = codeClass.MissingInterfaceMembers() where members.Any() select new KeyValuePair<CsContainer, IReadOnlyList<CsMember>>(codeClass, members));
            }

            if (source.SourceCode.Structures.Any())
            {
                results.AddRange(from codeStructure in source.SourceCode.Structures let members = codeStructure.MissingInterfaceMembers() where members.Any() select new KeyValuePair<CsContainer, IReadOnlyList<CsMember>>(codeStructure, members));
            }

            return results.ToImmutableList();
        }
    }
}
