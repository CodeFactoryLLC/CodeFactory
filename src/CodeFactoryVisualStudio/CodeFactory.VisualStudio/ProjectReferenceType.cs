//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Enumeration
    /// </summary>
    public enum ProjectReferenceType
    {
        /// <summary>
        /// Reference is a direct assembly file that is referenced by the project.
        /// </summary>
        Assembly = 0,

        /// <summary>
        /// Reference comes from a direct external nuget feed.
        /// </summary>
        NuGet = 1,

        /// <summary>
        /// Reference is an existing project within the solution.
        /// </summary>
        Project = 2,

        /// <summary>
        /// Reference is a com library.
        /// </summary>
        Com = 3,

        /// <summary>
        /// The reference is of an unknown type.
        /// </summary>
        Unknown = 9999
    }
}
