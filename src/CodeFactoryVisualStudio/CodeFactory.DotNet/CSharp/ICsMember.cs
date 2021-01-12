//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Base definition for all c# member models.
    /// </summary>
    public interface ICsMember:ICsModel,ICsAttributes,IDotNetMember,IParent
    {
        /// <summary>
        ///     The security scope that has been assigned to the member.
        /// </summary>
        new CsSecurity Security { get; }

        /// <summary>
        /// The type of member the model is.
        /// </summary>
        new CsMemberType MemberType { get; }

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddBeforeAsync(string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsMember"/>in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> AddAfterAsync(string sourceCode);

        /// <summary>
        /// Deletes the definition of the member from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the member is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the member has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> DeleteAsync(string sourceDocument);

        /// <summary>
        /// Deletes the definition of the member from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the member has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> DeleteAsync();

        /// <summary>
        /// Gets the starting and ending locations within the document where the member is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the member defined in.</param>
        /// <returns>The source location for the member.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument);

        /// <summary>
        /// Gets the starting and ending locations within the document where the member is located.
        /// </summary>
        /// <returns>The source location for the member.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        Task<ISourceLocation> GetSourceLocationAsync();

        /// <summary>
        /// Replaces the current member with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the current member with the provided source code.
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
        CsModel GetModel(string lookupPath);
    }
}
