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
    /// Data model that presents a visual studio reference that has been loaded.
    /// </summary>
    public abstract class VsReference:VsModel,IVsReference
    {
        #region Property backing fields
        private readonly string _filePath;
        private readonly ProjectReferenceType _type;
        private readonly IReadOnlyList<string> _aliases;
        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsModel"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occurred while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occurred if any.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="filePath">The fully qualified file path to the reference</param>
        /// <param name="type">The type of reference that is set for the project.</param>
        /// <param name="aliases">Readonly list of the aliases assigned to this reference.</param>
        protected VsReference(bool isLoaded, bool hasErrors, IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors,
            string name,string filePath, ProjectReferenceType type, IReadOnlyList<string> aliases) 
            : base(isLoaded, hasErrors, modelErrors, VisualStudioModelType.Reference, name)
        {
            _filePath = filePath;
            _type = type;
            _aliases = aliases ?? ImmutableList<string>.Empty;
        }

        /// <summary>
        ///     The fully qualified path to the source reference.
        /// </summary>
        public string FilePath => _filePath;

        /// <summary>
        /// Flag that determines if the reference has aliases. 
        /// </summary>
        public bool HasAliases => _aliases.Any();

        /// <summary>
        /// Readonly list of the aliases assigned to this reference.
        /// </summary>
        public IReadOnlyList<string> Aliases => _aliases;

        /// <summary>
        /// The type of the project reference.
        /// </summary>
        public ProjectReferenceType Type => _type;

        /// <summary>
        /// Gets the <see cref="VsProject"/> model for the project that represents this reference.
        /// </summary>
        /// <returns>The loaded project model or null if the reference does not support a project based reference.</returns>
        public abstract Task<VsProject> GetReferencedProjectAsync();
    }
}
