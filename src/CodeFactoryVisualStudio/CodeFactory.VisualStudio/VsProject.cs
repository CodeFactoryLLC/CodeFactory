//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;


namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Data model that presents a visual studio project that has been loaded.
    /// </summary>
    public abstract class VsProject:VsModel,IVsProject
    {
        #region Property backing fields
        private readonly bool _hasParent;
        private readonly bool _hasChildren;
        private readonly string _path;
        private readonly bool _legacyProjectModel;
        private readonly IReadOnlyList<ProjectLanguage> _projectLanguages;
        private readonly string _defaultNamespace;
        private readonly IReadOnlyList<VsProjectFramework> _targetFrameworks;

        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsProject"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occurred while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occurred if any.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="hasParent">Flag that determines if there is a parent model for this model.</param>
        /// <param name="hasChildren">Flag that determines if this model has child models.</param>
        /// <param name="path">The fully qualified path of the project.</param>
        /// <param name="legacyProjectModel">Flag that determines if this project uses the legacy project system for visual studio.</param>
        /// <param name="projectLanguages">The programming languages this project supports.</param>
        /// <param name="defaultNamespace">The default namespace for the project if it support .net framework or .net core. Otherwise this will be null. </param>
        /// <param name="targetFrameworks">List of the target frameworks this project sends output to on compile.</param>
        protected VsProject(bool isLoaded, bool hasErrors, IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors,
             string name, bool hasParent, bool hasChildren, string path, bool legacyProjectModel, 
             IReadOnlyList<ProjectLanguage> projectLanguages, string defaultNamespace, IReadOnlyList<VsProjectFramework> targetFrameworks) 
            : base(isLoaded, hasErrors, modelErrors, VisualStudioModelType.Project, name)
        {
            _hasParent = hasParent;
            _hasChildren = hasChildren;
            _path = path;
            _legacyProjectModel = legacyProjectModel;
            _defaultNamespace = defaultNamespace;
            _targetFrameworks = targetFrameworks;
            _projectLanguages = projectLanguages ?? ImmutableList<ProjectLanguage>.Empty;
            _targetFrameworks = targetFrameworks ?? ImmutableList<VsProjectFramework>.Empty;
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
        ///     The fully qualified path to the project file name.
        /// </summary>
        public string Path => _path;

        /// <summary>
        /// Flag that determines if this visual studio project uses the legacy project model. If so then only basic capabilities and references will be available through code factory.
        /// </summary>
        public bool LegacyProjectModel => _legacyProjectModel;

        /// <summary>
        /// The default namespace for the project if it support .net framework or .net core. Otherwise this will be null.
        /// </summary>
        public string DefaultNamespace => _defaultNamespace;

        /// <summary>
        /// The project languages that are supported in this project. 
        /// </summary>
        public IReadOnlyList<ProjectLanguage> ProjectLanguages => _projectLanguages;

        /// <inheritdoc />
        public IReadOnlyList<VsProjectFramework> TargetFrameworks => _targetFrameworks;

        /// <summary>
        /// Gets the parent solution folder that holds the project.
        /// </summary>
        /// <returns>Returns a solution folder if the project has a parent or null if the project has no parent.</returns>
        public abstract Task<VsSolutionFolder> GetParentAsync();

        /// <summary>
        /// Get all the children that are direct children of the project.
        /// </summary>
        /// <param name="allChildren">Flag that determines if it should return all children of the project and not just the top level children.</param>
        /// <param name="loadSourceCode">Flag to determine if code files that support code factory source code will be loaded by default. If enabled this could be memory intensive.</param>
        /// <returns>The children of the project, if no children are found and empty enumeration will be returned.</returns>
        public abstract Task<IReadOnlyList<VsModel>> GetChildrenAsync(bool allChildren ,bool loadSourceCode = false);

        /// <summary>
        /// Adds a project document to the root of the project.
        /// </summary>
        /// <param name="fileName">The file name of the document. This should be the name only with no file path.</param>
        /// <param name="content">The content that will be initially added to the document. This is an optional parameter.</param>
        /// <returns>The created project document.</returns>
        public abstract Task<VsDocument> AddDocumentAsync(string fileName, string content = null);

        /// <summary>
        /// Adds an existing document to the project.
        /// </summary>
        /// <param name="fileName">The file name for the document. This should be the file name only with extension. The file must already be in the projects folder.</param>
        /// <returns>The model of the created project document.</returns>
        public abstract Task<VsDocument> AddExistingDocumentAsync(string fileName);

        /// <summary>
        /// Adds a project folder to the root of the project.
        /// </summary>
        /// <param name="folderName">The name of the project folder. This should be the name only with no path.</param>
        /// <returns>The created project folder.</returns>
        public abstract Task<VsProjectFolder> AddProjectFolderAsync(string folderName);

        /// <summary>
        /// Gets the references assigned to this project.
        /// </summary>
        /// <returns>Readonly list of the references.</returns>
        public abstract Task<IReadOnlyList<VsReference>> GetProjectReferencesAsync();

        /// <summary>
        /// Get the <see cref="VsProject"/> models for all projects that are referenced by this project.
        /// </summary>
        /// <returns>Readonly list of the referenced projects or an empty list if there is no referenced projects.</returns>
        public async Task<IReadOnlyList<VsProject>> GetReferencedProjects()
        {
            if (!IsLoaded) return ImmutableList<VsProject>.Empty;

            var projectReferences = await GetProjectReferencesAsync();

            if(!projectReferences.Any(r => r.Type == ProjectReferenceType.Project)) return ImmutableList<VsProject>.Empty;

            var projects = new List<VsProject>();
            foreach (var vsProjectReference in projectReferences)
            {
                var project = await vsProjectReference.GetReferencedProjectAsync();
                if(project != null) projects.Add(project);
            }

            return projects.Any() ? projects.ToImmutableList() : ImmutableList<VsProject>.Empty;
        }
    }
}
