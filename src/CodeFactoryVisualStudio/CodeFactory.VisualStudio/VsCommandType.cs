//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Enumeration that determines the type of visual studio command is being executed.
    /// </summary>
    public enum VsCommandType
    {
        /// <summary>
        /// Solution explorer command that is triggered from the context menu from the solution node.
        /// </summary>
        SolutionExplorerSolution = 0,

        /// <summary>
        /// Solution explorer command that is triggered from the context menu from a solution folder node.
        /// </summary>
        SolutionExplorerSolutionFolder = 1,

        /// <summary>
        /// Solution explorer command that is triggered from the context menu from a project node.
        /// </summary>
        SolutionExplorerProject = 2,

        /// <summary>
        /// Solution explorer command that is triggered from the context menu from a project folder node.
        /// </summary>
        SolutionExplorerProjectFolder = 3,

        /// <summary>
        /// Solution explorer command that is triggered from the context menu from a project document node.
        /// </summary>
        SolutionExplorerProjectDocument = 4,

        /// <summary>
        /// Solution explorer command that is triggered from the context menu from a solution document node.
        /// </summary>
        SolutionExplorerSolutionDocument = 5,

        /// <summary>
        /// Solution explorer command that is triggered from the context menu from a project document that supports source code.
        /// </summary>
        SolutionExplorerCSharpSourceCode = 6,

        /// <summary>
        /// IDE level command that is fired once the solution has been loaded. Will only be triggered once the solution is loaded.
        /// </summary>
        IDESolutionLoad = 7,

        /// <summary>
        /// The command type is unknown
        /// </summary>
        Unknown = 999999

    }
}
