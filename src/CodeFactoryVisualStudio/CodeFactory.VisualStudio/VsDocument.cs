//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.Document;
using CodeFactory.SourceCode;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Data model that represents a document that is hosted in visual studio.
    /// </summary>
    public abstract class VsDocument:VsModel,IVsDocument
    {
        #region Propery backing fields
        private readonly bool _hasParent;
        private readonly bool _hasChildren;
        private readonly string _path;
        private readonly VsDocumentType _documentType;
        private readonly bool _isSourceCode;
        private readonly SourceCodeType _sourceType;
        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsDocument"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occured while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occured if any.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="hasParent">Flag that determines if this model has a parent model.</param>
        /// <param name="hasChildren">Flag that determines if this model has child models.</param>
        /// <param name="path">The fully qualified path to the document.</param>
        /// <param name="documentType">The type of visual studio document.</param>
        /// <param name="isSourceCode">Is a source code file loadable by code factory.</param>
        /// <param name="sourceType">The type of source code found in the document.</param>
        protected VsDocument(bool isLoaded, bool hasErrors, IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors,
            string name, bool hasParent, bool hasChildren, string path, VsDocumentType documentType, bool isSourceCode,
            SourceCodeType sourceType) : base(isLoaded, hasErrors, modelErrors, VisualStudioModelType.Document, name)
        {
            _hasParent = hasParent;
            _hasChildren = hasChildren;
            _path = path;
            _documentType = documentType;
            _isSourceCode = isSourceCode;
            _sourceType = sourceType;
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
        /// The fully qualified path to the project document. 
        /// </summary>
        public string Path => _path;

        /// <summary>
        /// The type of document that is loaded.
        /// </summary>
        public VsDocumentType DocumentType => _documentType;

        /// <summary>
        /// Flag that determines if the project document contains source code that can be managed by code factory.
        /// </summary>
        public bool IsSourceCode => _isSourceCode;

        /// <summary>
        /// The target type of source code that is implemented in the project document. 
        /// </summary>
        public SourceCodeType SourceType => _sourceType;

        /// <summary>
        /// Get the parent visual studio model of the document. 
        /// </summary>
        /// <returns>Model of the parent of this document. The model will be returned unless there is no parent, otherwise null will be returned.</returns>
        public abstract Task<VsModel> GetParentAsync();

        /// <summary>
        /// Gets the direct children of the document.
        /// </summary>
        /// <param name="allChildren">Flag that determines if all children from the document should be returned.</param>
        /// <returns>Readonly list of all the project documents, if no children are found then an empty readonly list will be returned.</returns>
        public abstract Task<IReadOnlyList<VsDocument>> GetChildrenAsync(bool allChildren);

        /// <summary>
        /// Deletes the document.
        /// </summary>
        /// <remarks>Currently does not support deleting solution documents.</remarks>
        /// <returns>Flag that notifies if the delete operation completed successfully.</returns>
        public abstract Task<bool> DeleteAsync();

        /// <summary>
        /// Removes a document from visual studio but does not remove it from the file system. 
        /// </summary>
        /// <remarks>Currently does not support removing solution documents.</remarks>
        /// <returns>Flag that notifies if the remove operation completed successfully.</returns>
        public abstract Task<bool> RemoveAsync();

        /// <summary>
        /// Gets the content of the document.
        /// </summary>
        /// <returns>The content of the document or null if there is no content in the document.</returns>
        public abstract Task<string> GetDocumentContentAsStringAsync();

        /// <summary>
        /// Gets the content of the document.
        /// </summary>
        /// <param name="startLocation">The starting position within the document to get content from.</param>
        /// <param name="endLocation">The ending position within the document to get content form.</param>
        /// <returns>The content of the document or null if there is no content in the document.</returns>
        public abstract Task<string> GetDocumentContentAsStringAsync( IDocumentLocation startLocation, IDocumentLocation endLocation);

        /// <summary>
        /// Gets the content of the document.
        /// </summary>
        /// <returns>Document content as </returns>
        public abstract Task<IDocumentContent> GetDocumentContentAsContentAsync();

        /// <summary>
        /// Adds content to the beginning of a document.
        /// </summary>
        /// <param name="content">The content to be added.</param>
        public abstract Task AddContentToBeginningAsync(string content);

        /// <summary>
        /// Adds content to the end of a document.
        /// </summary>
        /// <param name="content">The content to be added.</param>
        public abstract Task AddContentToEndAsync(string content);

        /// <summary>
        /// Adds content to a target starting at an assigned
        /// </summary>
        /// <param name="location">Location within the document to add content to.</param>
        /// <param name="content">The content to be added to the document.</param>
        public abstract Task AddContentAsync(IDocumentLocation location, string content);

        /// <summary>
        /// Removes all the content from a document.
        /// </summary>
        public abstract Task RemoveContentAsync();

        /// <summary>
        /// Removes a target set of content from the document.
        /// </summary>
        /// <param name="startLocation">The starting position within the document to remove content from.</param>
        /// <param name="endLocation">The ending position within the document to remove content form.</param>
        /// <returns></returns>
        public abstract Task RemoveContentAsync(IDocumentLocation startLocation, IDocumentLocation endLocation);

        /// <summary>
        /// Replaces all the content within the document.
        /// </summary>
        /// <param name="content">Content to replace the existing content in the document.</param>
        public abstract Task ReplaceContentAsync(string content);

        /// <summary>
        /// Replaces all the content within the document.
        /// </summary>
        /// <param name="content">Content to replace the existing content in the document.</param>
        /// <param name="startLocation">The starting position within the document to replace content.</param>
        /// <param name="endLocation">The ending location within the document to replace content.</param>
        public abstract Task ReplaceContentAsync( string content, IDocumentLocation startLocation, IDocumentLocation endLocation);

        /// <summary>
        /// If the document is implemented as a C# code model. Will return the C# source code model from the visual studio document.
        /// </summary>
        /// <returns>The loaded model or null if the model could not be loaded.</returns>
        public abstract Task<DotNet.CSharp.CsSource> GetCSharpSourceModelAsync();
    }
}
