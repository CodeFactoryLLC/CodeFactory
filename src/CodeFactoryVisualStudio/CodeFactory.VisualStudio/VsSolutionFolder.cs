//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;


namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Data model that represents a solution folder in a loaded solution.
    /// </summary>
    public abstract class VsSolutionFolder:VsModel,IVsSolutionFolder
    {
        #region Property backing fields
        private readonly bool _hasParent;
        private readonly bool _hasChildren;

        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsSolutionFolder"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occured while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occured if any.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="hasParent">Flag that determines if this solution folder has a parent model.</param>
        /// <param name="hasChildren">Flag that determines has any child models.</param>
        protected VsSolutionFolder(bool isLoaded, bool hasErrors, IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors,
            string name, bool hasParent, bool hasChildren) : base(isLoaded, hasErrors, modelErrors, VisualStudioModelType.SolutionFolder, name)
        {
            _hasParent = hasParent;
            _hasChildren = hasChildren;
        }

        /// <summary>
        /// Flag that determines if the visual studio object has a parent.
        /// </summary>
        public bool HasParent => _hasParent;

        /// <summary>
        /// Flag that determines if this visual studio object has child objects.
        /// </summary>
        public bool HasChildren => _hasChildren;

        /// <summary>
        /// Gets the parent solution folder.
        /// </summary>
        /// <returns>The parent solution folder model or null if there is no parent for this solution folder.</returns>
        public abstract Task<VsSolutionFolder> GetParentAsync();

        /// <summary>
        /// Gets the children of the solution folder, this will return the files and projects that are part of the solution folder.
        /// </summary>
        /// <param name="allChildren">Flag that determines if all the direct children of the solution folder should also get there children.</param>
        /// <returns>Returns a readonly list of the children within this solution folder. Will return an empty list if there is no children.</returns>
        public abstract Task<IReadOnlyList<VsModel>> GetChildrenAsync(bool allChildren);

        /// <summary>
        /// Removes the solution folder from the visual studio solution that is hosting the solution folder.
        /// </summary>
        /// <returns>Boolean flag true - solution folder was been removed or false the folder is either already removed or could not be removed.</returns>
        public abstract Task<bool> Remove();

        /// <summary>
        /// Create a new solution folder under the current solution folder.
        /// </summary>
        /// <param name="folderName">The name of the solution folder.</param>
        /// <returns>Instance of the new solution folder.</returns>
        public abstract Task<VsSolutionFolder> AddSolutionFolder(string folderName);

        /// <summary>
        /// Creates a document that is hosted in the solution folder.
        /// </summary>
        /// <param name="fileName">The name of the document to create.</param>
        /// <param name="content">The content to add to the document.</param>
        /// <returns>Instance of the new document.</returns>
        public abstract Task<VsDocument> AddDocumentAsync(string fileName, string content = null);

        /// <summary>
        /// Adds an existing document to the solution folder.
        /// </summary>
        /// <param name="fileName">The file name for the document. This should be the file name only with extension. The file must already be in the solution folder.</param>
        /// <returns>The model of the created document.</returns>
        public abstract Task<VsDocument> AddExistingDocumentAsync(string fileName);
    }
}
