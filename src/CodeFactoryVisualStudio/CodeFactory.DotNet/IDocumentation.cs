//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using CodeFactory.DotNet.CSharp;
using System.Threading.Tasks;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Interface that determines if a model has code level documentation.
    /// </summary>
    public interface IDocumentation
    {
        /// <summary>
        ///     Flag that determines if the model has code level documentation assigned to it.
        /// </summary>
        bool HasDocumentation { get; }

        /// <summary>
        ///     Documentation that has been assigned to this model.
        /// </summary>
        string Documentation { get; }

        /// <summary>
        /// Adds the supplied source code directly before the documentation.
        /// </summary>
        /// <param name="sourceCode">The target syntax to be added to the document.</param>
        /// <returns>Updated <see cref="CsSource"/> model with the injected source code.</returns>
        Task<CsSource> AddBeforeDocsAsync(string sourceCode);

        /// <summary>
        /// Adds the supplied source code directly after the documentation.
        /// </summary>
        /// <param name="sourceCode">The target syntax to be added to the document.</param>
        /// <returns>Updated <see cref="CsSource"/> model with the injected source code.</returns>
        Task<CsSource> AddAfterDocsAsync(string sourceCode);

        /// <summary>
        /// Replaces the supplied source code directly this the documentation.
        /// </summary>
        /// <param name="sourceCode">The target syntax to be added to the document.</param>
        /// <returns>Updated <see cref="CsSource"/> model with the injected source code.</returns>
        Task<CsSource> ReplaceDocsAsync(string sourceCode);

        /// <summary>
        /// Deletes the documentation from the target supporting code artifact.
        /// </summary>
        /// <returns>Updated <see cref="CsSource"/> model with the documentation removed.</returns>
        Task<CsSource> DeleteDocsAsync();
    }
}
