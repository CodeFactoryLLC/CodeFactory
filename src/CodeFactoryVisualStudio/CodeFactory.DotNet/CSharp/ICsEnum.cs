//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that provides information on an enumeration.
    /// </summary>
    public interface ICsEnum : ICsModel, ICsAttributes,IParent, IDotNetEnum
    {
        /// <summary>
        ///     The security scope assigned to the enumeration.
        /// </summary>
        new CsSecurity Security { get; }

        /// <summary>
        ///     List of the enumeration values implemented in this enumeration.
        /// </summary>
        new IReadOnlyList<CsEnumValue> Values { get; }

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsEnum"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsEnum"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddBeforeAsync(string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsEnum"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsEnum"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddAfterAsync(string sourceCode);

        /// <summary>
        /// Deletes the definition of the delegate from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the delegate is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the delegate has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> DeleteAsync(string sourceDocument);

        /// <summary>
        /// Deletes the definition of the delegate from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the delegate has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> DeleteAsync();

        /// <summary>
        /// Gets the starting and ending locations within the document where the delegate is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the delegate defined in.</param>
        /// <returns>The source location for the delegate.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations within the document where the delegate is located.
        /// </summary>
        /// <returns>The source location for the delegate.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        Task<ISourceLocation> GetSourceLocationAsync();

        /// <summary>
        /// Replaces the current delegate with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the current delegate with the provided source code.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> ReplaceAsync(string sourceCode);

        /// <summary>
        /// Gets a <see cref="ICsModel"/> from the currently loaded source code. 
        /// </summary>
        /// <param name="lookupPath">The fully qualified path to the model to be loaded.</param>
        /// <returns>The loaded model or null if the model could not be found.</returns>
        ICsModel GetModel(string lookupPath);
    }
}
