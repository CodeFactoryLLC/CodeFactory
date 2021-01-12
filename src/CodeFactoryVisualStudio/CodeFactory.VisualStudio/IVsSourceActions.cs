//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// The visual studio actions that support source models.
    /// </summary>
    public interface IVsSourceActions
    {

        /// <summary>
        /// Loads the <see cref="IVsDocument"/> model from the provided <see cref="ICsSource"/> model.
        /// </summary>
        /// <param name="source">Model to load the document from.</param>
        /// <returns>Loaded document model.</returns>
        /// <exception cref="DocumentException">Exception that occurs while loading the document.</exception>
        Task<VsDocument> LoadDocumentFromSourceAsync(ICsSource source);
    }
}
