//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Visual studio actions that support the <see cref="IVsReference"/> model.
    /// </summary>
    public interface IVsReferenceActions
    {
        /// <summary>
        /// Gets the <see cref="VsProject"/> model for the project that represents this reference.
        /// </summary>
        /// <param name="source">The project reference to load.</param>
        /// <returns>The loaded project model or null if the project reference does not support a project based reference.</returns>
        Task<VsProject> GetReferencedProjectAsync(VsReference source);
    }
}
