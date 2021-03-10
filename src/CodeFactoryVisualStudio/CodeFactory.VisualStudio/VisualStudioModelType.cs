//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Enumeration of the different type of code factory models that support visual studio integration.
    /// </summary>
    public enum VisualStudioModelType
    {
        /// <summary>
        /// The target model represents a visual studio solution.
        /// </summary>
        Solution = 0,

        /// <summary>
        /// The target model represents a visual studio solution folder.
        /// </summary>
        SolutionFolder = 1,

        /// <summary>
        /// Target model represents a visual studio project.
        /// </summary>
        Project = 2,

        /// <summary>
        /// Target model represents a visual studio project folder.
        /// </summary>
        ProjectFolder = 3,

        /// <summary>
        /// Target model for a reference used by a project
        /// </summary>
        Reference = 4,

        /// <summary>
        /// Target model represents a visual studio document.
        /// </summary>
        Document = 5,

        /// <summary>
        /// Target model represents visual studio source  contained in a document. 
        /// </summary>
        CSharpSource = 6,

        /// <summary>
        /// The target framework output for a project.
        /// </summary>
        ProjectFramework = 7,

        /// <summary>
        /// Target model is unknown
        /// </summary>
        Unknown = 9999
    }
}
