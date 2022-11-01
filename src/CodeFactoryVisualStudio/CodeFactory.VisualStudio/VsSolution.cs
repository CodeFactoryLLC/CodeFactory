//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;


namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Data model that represents the loaded solution in visual studio.
    /// </summary>
    public abstract class VsSolution:VsModel,IVsSolution
    {
        #region Property backing fields
        private readonly bool _hasChildren;
        private readonly string _path;
        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsSolution"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occurred while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occurred if any.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="hasChildren">Flag that determines if the solution has any children.</param>
        /// <param name="path">The fully qualified path of the solution.</param>
        protected VsSolution(bool isLoaded, bool hasErrors, IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors, 
             string name, bool hasChildren, string path) : base(isLoaded, hasErrors, modelErrors, VisualStudioModelType.Solution, name)
        {
            _hasChildren = hasChildren;
            _path = path;
        }

        /// <summary>
        /// Flag that determines if this visual studio object has child objects.
        /// </summary>
        public bool HasChildren => _hasChildren;

        /// <summary>
        ///     The fully qualified path to the solution file name.
        /// </summary>
        public string Path => _path;

        /// <summary>
        /// Gets the solution folders and projects that belong to the solution. 
        /// </summary>
        /// <param name="allChildren">Get all children not just the first children of the solution.</param>
        /// <returns>Returns a readonly list of the children to the solution. If there are no children an empty list will be returned.</returns>
        public abstract Task<IReadOnlyList<VsModel>> GetChildrenAsync(bool allChildren);

        /// <summary>
        /// Gets the solution folders for the solution.
        /// </summary>
        /// <param name="allChildren">Get all children not just the first children of the solution.</param>
        /// <returns>Returns a readonly of the solutions folders that are part of the solution. If there are no solution folders an empty list will be returned.</returns>
        public abstract Task<IReadOnlyList<VsSolutionFolder>> GetSolutionFoldersAsync(bool allChildren);

        /// <summary>
        /// Gets the projects for the solution.
        /// </summary>
        /// <param name="allChildren">Get all children not just the first children of the solution.</param>
        /// <returns>Returns all the projects that are part of the solution. Will return an empty list if no projects are found.</returns>
        public abstract Task<IReadOnlyList<VsProject>> GetProjectsAsync(bool allChildren);

        /// <summary>
        /// Creates a new solution folder for the target solution.
        /// </summary>

        /// <param name="name">The name of the solution folder to be added.</param>
        /// <returns>Returns the solution folder.</returns>
        public abstract Task<VsSolutionFolder> CreateSolutionFolderAsync(string name);
    }
}
