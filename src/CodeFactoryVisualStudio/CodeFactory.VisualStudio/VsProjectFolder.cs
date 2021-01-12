//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;


namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Data model that represents a folder in a project hosted in visual studio.
    /// </summary>
    public abstract class VsProjectFolder:VsModel,IVsProjectFolder
    {
        #region Property backing fields
        private readonly bool _hasParent;
        private readonly bool _hasChildren;
        private readonly string _path;
        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsProjectFolder"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occured while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occured if any.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="hasParent">Flag that determines if the model has a parent model.</param>
        /// <param name="hasChildren">Flag that determines if the model has child models.</param>
        /// <param name="path">The fully qualified path to the project folder.</param>
        protected VsProjectFolder(bool isLoaded, bool hasErrors, 
            IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors,
            string name, bool hasParent, bool hasChildren, string path) 
            : base(isLoaded, hasErrors, modelErrors, VisualStudioModelType.ProjectFolder, name)
        {
            _hasParent = hasParent;
            _hasChildren = hasChildren;
            _path = path;
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
        /// the fully qualified path to the project folder.
        /// </summary>
        public string Path => _path;

        /// <summary>
        /// Gets the parent visual studio model that is the parent of this Project folder.
        /// </summary>
        /// <returns>The visual studio model of the parent or null if the project folder does not have a parent.</returns>
        public abstract Task<VsModel> GetParentAsync();

        /// <summary>
        /// Gets the <see cref="IVsModel"/> of the items that are direct children of this project folder.
        /// </summary>
        /// <param name="allChildren">Flag that determines if all children not just the first level children of the project folder.</param>
        /// <param name="loadSourceCode">Flag to determine if code files that support code factory source code will be loaded by default. If enabled this could be memory intensive.</param>
        /// <returns>Readonly list of the children that belong to this project folder. If no children are found an empty readonly list will be returned. </returns>
        public abstract Task<IReadOnlyList<VsModel>> GetChildrenAsync(bool allChildren, bool loadSourceCode = false);


        /// <summary>
        /// Deletes the project folder.
        /// </summary>
        /// <returns>Flag determining if the folder was deleted, True for deleted and false if the folder could not be deleted.</returns>
        public abstract Task<bool> DeleteAsync();

        /// <summary>
        /// Removes the project folder from visual studio, but does not delete it from the file system.
        /// </summary>
        /// <returns>Flag determining if the folder was removed, True for removed and false if the folder could not be removed.</returns>
        public abstract Task<bool> RemoveAsync();

        /// <summary>
        /// Adds a new project folder under the current project folder.
        /// </summary>
        /// <param name="folderName">The name of the project folder. The project folder name should be the name only no path.</param>
        /// <returns>The model for the created project folder.</returns>
        public abstract Task<VsProjectFolder> AddProjectFolderAsync(string folderName);

        /// <summary>
        /// Adds a document to the project folder.
        /// </summary>
        /// <param name="fileName">The file name for the document. This should be the file name only with extension.</param>
        /// <param name="content">The content to be added to the document once its added. Note, this is an optional parameter.</param>
        /// <returns>The model of the created project document.</returns>
        public abstract Task<VsDocument> AddDocumentAsync(string fileName, string content = null);


        /// <summary>
        /// Adds an existing document to the project folder.
        /// </summary>
        /// <param name="fileName">The file name for the document. This should be the file name only with extension. The file must already be in the project folder.</param>
        /// <returns>The model of the created project document.</returns>
        public abstract Task<VsDocument> AddExistingDocumentAsync( string fileName);

        /// <summary>
        /// Gets the target namespace for a document that support c# language to be placed in this folder. 
        /// </summary>
        /// <returns>The fully qualified namespace if the project is a c# project that supports this project folder. Otherwise null will be returned.</returns>
        public abstract Task<string> GetCSharpNamespaceAsync();
    }
}
