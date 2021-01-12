//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Visual studio actions that support the <see cref="IVsProject"/> model.
    /// </summary>
    public interface IVsProjectActions
    {
        /// <summary>
        /// Gets the parent solution folder that holds the project.
        /// </summary>
        /// <param name="source">Project to get the parent for.</param>
        /// <returns>Returns a solution folder if the project has a parent or null if the project has no parent.</returns>
        Task<VsSolutionFolder> GetParentAsync(VsProject source);

        /// <summary>
        /// Get all the children that are direct children of the project.
        /// </summary>
        /// <param name="source">the project to get the children from.</param>
        /// <param name="allChildren">Flag that determines if it should return all children of the project and not just the top level children.</param>
        /// <param name="loadSourceCode">Flag that determines if code factory managed source code models should be loaded instead of the standard <see cref="VsDocument"/> model.</param>
        /// <returns>The children of the project, if no children are found and empty enumeration will be returned.</returns>
        Task<IReadOnlyList<VsModel>> GetChildrenAsync(VsProject source, bool allChildren, bool loadSourceCode = false);

        /// <summary>
        /// Adds a project document to the root of the project.
        /// </summary>
        /// <param name="source">The project to be added to.</param>
        /// <param name="fileName">The file name of the document. This should be the name only with no file path.</param>
        /// <param name="content">The content that will be initially added to the document. This is an optional parameter.</param>
        /// <returns>The created project document.</returns>
        Task<VsDocument> AddDocumentAsync(VsProject source, string fileName, string content = null);

        /// <summary>
        /// Adds an existing document to the project.
        /// </summary>
        /// <param name="source">The project to be added to.</param>
        /// <param name="fileName">The file name for the document. This should be the file name only with extension. The file must already be in the projects folder.</param>
        /// <returns>The model of the created project document.</returns>
        Task<VsDocument> AddExistingDocumentAsync(VsProject source, string fileName);

        /// <summary>
        /// Adds a project folder to the root of the project.
        /// </summary>
        /// <param name="source">The project to be added to.</param>
        /// <param name="folderName">The name of the project folder. This should be the name only with no path.</param>
        /// <returns>The created project folder.</returns>
        Task<VsProjectFolder> AddProjectFolderAsync(VsProject source, string folderName);

        /// <summary>
        /// Gets the references assigned to this project.
        /// </summary>
        /// <param name="source">The source project to get the references from.</param>
        /// <returns>Readonly list of the references.</returns>
        Task<IReadOnlyList<VsReference>> GetReferencesAsync(VsProject source);

        /// <summary>
        /// Get the <see cref="VsProject"/> models for all projects that are referenced by this project.
        /// </summary>
        /// <param name="source">Source project to get referenced projects from.</param>
        /// <returns>Readonly list of the referenced projects or an empty list if there is no referenced projects.</returns>
        Task<IReadOnlyList<VsProject>> GetReferencedProjects(VsProject source);

    }
}
