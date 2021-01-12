//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Actions that can be used with the a <see cref="IVsSolution"/> model.
    /// </summary>
    public interface IVsSolutionActions:IVsActions
    {
        /// <summary>
        /// Gets the solution folders and projects that belong to the solution. 
        /// </summary>
        /// <param name="source">The solution model to get the children from.</param>
        /// <param name="allChildren">Get all children not just the first children of the solution.</param>
        /// <returns>Returns a readonly list of the children to the solution. If there are no children an empty list will be returned.</returns>
        Task<IReadOnlyList<VsModel>> GetChildrenAsync(VsSolution source, bool allChildren);

        /// <summary>
        /// Gets the solution folders for the solution.
        /// </summary>
        /// <param name="source">The solution model to get the solution folders from.</param>
        /// <param name="allChildren">Get all children not just the first children of the solution.</param>
        /// <returns>Returns a readonly of the solutions folders that are part of the solution. If there are no solution folders an empty list will be returned.</returns>
        Task<IReadOnlyList<VsSolutionFolder>> GetSolutionFoldersAsync(VsSolution source, bool allChildren);

        /// <summary>
        /// Gets the projects for the solution.
        /// </summary>
        /// <param name="source">The solution model to get the projects from.</param>
        /// <param name="allChildren">Get all children not just the first children of the solution.</param>
        /// <returns>Returns all the projects that are part of the solution. Will return an empty list if no projects are found.</returns>
        Task<IReadOnlyList<VsProject>> GetProjectsAsync(VsSolution source, bool allChildren);

        /// <summary>
        /// Creates a new solution folder for the target solution.
        /// </summary>
        /// <param name="source">The solution to add the solution folder to.</param>
        /// <param name="name">The name of the solution folder to be added.</param>
        /// <returns>Returns the solution folder.</returns>
        Task<VsSolutionFolder> CreateSolutionFolderAsync(VsSolution source, string name);
    }
}
