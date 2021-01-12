//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Definition of a visual studio project model information.
    /// </summary>
    public interface IVsProject : IVsModel, IParent, IChildren
    {
        /// <summary>
        ///     The fully qualified path to the project file name.
        /// </summary>
        string Path { get; }

        /// <summary>
        /// Flag that determines if this visual studio project uses the legacy project model. If so then only basic capabilities and references will be available through code factory.
        /// </summary>
        bool LegacyProjectModel {get;}

        /// <summary>
        /// The default namespace for the project if it support .net framework or .net core. Otherwise this will be null.
        /// </summary>
        string DefaultNamespace { get; }

        /// <summary>
        /// The project languages that are supported in this project. 
        /// </summary>
        IReadOnlyList<ProjectLanguage> ProjectLanguages { get;}

    }
}