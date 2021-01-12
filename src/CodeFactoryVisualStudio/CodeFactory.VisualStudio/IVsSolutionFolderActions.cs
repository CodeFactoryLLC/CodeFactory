//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Visual studio actions that support the <see cref="IVsSolutionFolder"/> model.
    /// </summary>
    public interface IVsSolutionFolderActions
    {
        /// <summary>
        /// Gets the parent solution folder.
        /// </summary>
        /// <param name="source">The solution folder to find the parent for.</param>
        /// <returns>The parent solution folder model or null if there is no parent for this solution folder.</returns>
        Task<VsSolutionFolder> GetParentAsync(VsSolutionFolder source);

        /// <summary>
        /// Gets the children of the solution folder, this will return the files and projects that are part of the solution folder.
        /// </summary>
        /// <param name="source">The solution folder to get the children from.</param>
        /// <param name="allChildren">Flag that determines if all the direct children of the solution folder should also get there children.</param>
        /// <returns>Returns a readonly list of the children within this solution folder. Will return an empty list if there is no children.</returns>
        Task<IReadOnlyList<VsModel>> GetChildrenAsync(VsSolutionFolder source, bool allChildren);

        /// <summary>
        /// Removes the solution folder from the visual studio solution that is hosting the solution folder.
        /// </summary>
        /// <param name="source">The solution folder that is to be removed from visual studio.</param>
        /// <returns>Boolean flag true - solution folder was been removed or false the folder is either already removed or could not be removed.</returns>
        Task<bool> Remove(VsSolutionFolder source);

        /// <summary>
        /// Create a new solution folder under the current solution folder.
        /// </summary>
        /// <param name="source">The solution folder that the new solution folder will be added to.</param>
        /// <param name="folderName">The name of the solution folder.</param>
        /// <returns>Instance of the new solution folder.</returns>
        Task<VsSolutionFolder> AddSolutionFolder(VsSolutionFolder source, string folderName);

        /// <summary>
        /// Creates a document that is hosted in the solution folder.
        /// </summary>
        /// <param name="source">The solution folder to add the document to.</param>
        /// <param name="fileName">The name of the document to create.</param>
        /// <param name="content">The content to add to the document.</param>
        /// <returns>Instance of the new document.</returns>
        Task<VsDocument> AddDocumentAsync(VsSolutionFolder source, string fileName, string content = null);


        /// <summary>
        /// Adds an existing document to the solution folder.
        /// </summary>
        /// <param name="source">The solution folder to add the document to.</param>
        /// <param name="fileName">The file name for the document. This should be the file name only with extension. The file must already be in the solution folder.</param>
        /// <returns>The model of the created document.</returns>
        Task<VsDocument> AddExistingDocumentAsync(VsSolutionFolder source, string fileName);

    }
}
