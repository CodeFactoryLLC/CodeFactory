//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.Document;

namespace CodeFactory.VisualStudio
{    
    /// <summary>
    /// Visual studio actions that support the <see cref="IVsDocument"/> model.
    /// </summary>
    public interface IVsDocumentActions
    {

        /// <summary>
        /// Get the parent visual studio model of the document. 
        /// </summary>
        /// <param name="source">document to get the parent of.</param>
        /// <returns>Model of the parent of this document. The model will be returned unless there is no parent, otherwise null will be returned.</returns>
        Task<VsModel> GetParentAsync(VsDocument source);

        /// <summary>
        /// Gets the direct children of the document.
        /// </summary>
        /// <param name="source">The document to get children from.</param>
        /// <param name="allChildren">Flag that determines if all children from the document should be returned.</param>
        /// <returns>Readonly list of all the project documents, if no children are found then an empty readonly list will be returned.</returns>
        Task<IReadOnlyList<VsDocument>> GetChildrenAsync(VsDocument source, bool allChildren);

        /// <summary>
        /// Deletes the document.
        /// </summary>
        /// <param name="source">document to be deleted.</param>
        /// <remarks>Currently does not support deleting solution documents.</remarks>
        /// <returns>Flag that notifies if the delete operation completed successfully.</returns>
        Task<bool> DeleteAsync(VsDocument source);

        /// <summary>
        /// Removes a document from visual studio but does not remove it from the file system. 
        /// </summary>
        /// <param name="source">document to be removed.</param>
        /// <remarks>Currently does not support removing solution documents.</remarks>
        /// <returns>Flag that notifies if the remove operation completed successfully.</returns>
        Task<bool> RemoveAsync(VsDocument source);

        /// <summary>
        /// Gets the content of the document.
        /// </summary>
        /// <param name="source">The document to get content from.</param>
        /// <returns>The content of the document or null if there is no content in the document.</returns>
        Task<string> GetDocumentContentAsStringAsync(VsDocument source);

        /// <summary>
        /// Gets the content of the document.
        /// </summary>
        /// <param name="source">The document to get content from.</param>
        /// <param name="startLocation">The starting position within the document to get content from.</param>
        /// <param name="endLocation">The ending position within the document to get content form.</param>
        /// <returns>The content of the document or null if there is no content in the document.</returns>
        Task<string> GetDocumentContentAsStringAsync(VsDocument source, IDocumentLocation startLocation, IDocumentLocation endLocation);

        /// <summary>
        /// Gets the content of the document.
        /// </summary>
        /// <param name="source">The document to get content from.</param>
        /// <returns>Document content as </returns>
        Task<IDocumentContent> GetDocumentContentAsContentAsync(VsDocument source);

        /// <summary>
        /// Adds content to the beginning of a document.
        /// </summary>
        /// <param name="source">Document to add content to.</param>
        /// <param name="content">The content to be added.</param>
        Task AddContentToBeginningAsync(VsDocument source, string content);

        /// <summary>
        /// Adds content to the end of a document.
        /// </summary>
        /// <param name="source">Document to add content to.</param>
        /// <param name="content">The content to be added.</param>
        Task AddContentToEndAsync(VsDocument source, string content);

        /// <summary>
        /// Adds content to a target starting at an assigned
        /// </summary>
        /// <param name="source">Document to have content added to.</param>
        /// <param name="location">Location within the document to add content to.</param>
        /// <param name="content">The content to be added to the document.</param>
        Task AddContentAsync(VsDocument source, IDocumentLocation location, string content);

        /// <summary>
        /// Removes all the content from a document.
        /// </summary>
        /// <param name="source">Document to remove content from.</param>
        Task RemoveContentAsync(VsDocument source);

        /// <summary>
        /// Removes a target set of content from the document.
        /// </summary>
        /// <param name="source">Document to remove content from.</param>
        /// <param name="startLocation">The starting position within the document to remove content from.</param>
        /// <param name="endLocation">The ending position within the document to remove content form.</param>
        /// <returns></returns>
        Task RemoveContentAsync(VsDocument source, IDocumentLocation startLocation, IDocumentLocation endLocation);

        /// <summary>
        /// Replaces all the content within the document.
        /// </summary>
        /// <param name="source">The target document to have content replaced.</param>
        /// <param name="content">Content to replace the existing content in the document.</param>
        Task ReplaceContentAsync(VsDocument source, string content);

        /// <summary>
        /// Replaces all the content within the document.
        /// </summary>
        /// <param name="source">The target document to have content replaced.</param>
        /// <param name="content">Content to replace the existing content in the document.</param>
        /// <param name="startLocation">The starting position within the document to replace content.</param>
        /// <param name="endLocation">The ending location within the document to replace content.</param>
        Task ReplaceContentAsync(VsDocument source, string content,IDocumentLocation startLocation, IDocumentLocation endLocation);

        /// <summary>
        /// If the document is implemented as a C# code model. Will return the C# source code model from the visual studio document.
        /// </summary>
        /// <param name="source">The source document to load the C# code model from.</param>
        /// <returns>The loaded model or null if the model could not be loaded.</returns>
        Task<DotNet.CSharp.CsSource> GetCSharpSourceModelAsync(VsDocument source);

    }
}
