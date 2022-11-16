//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsSource"/> model.
    /// </summary>
    public static class CsSourceExtensions
    {
        /// <summary>
        /// Creates a new instance of a namespace manager from a target model
        /// </summary>
        /// <param name="source">The model to load from.</param>
        /// <param name="targetNamespace">The target namespace the manager supports.</param>
        /// <returns>New instance of the namespace manager.</returns>
        public static NamespaceManager LoadNamespaceManager(this CsSource source, string targetNamespace = null)
        {
            return source == null ? new NamespaceManager(null) : new NamespaceManager(source.NamespaceReferences,targetNamespace);
        }
    }
}
