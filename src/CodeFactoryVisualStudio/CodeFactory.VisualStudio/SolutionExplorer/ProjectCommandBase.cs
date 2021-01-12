//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using CodeFactory.Logging;


namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="IProjectCommand"/>
    /// </summary>
    public abstract class ProjectCommandBase:VsCommandBase<VsProject>,IProjectCommand
    {
        /// <inheritdoc />
        protected ProjectCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger, vsActions, VsCommandType.SolutionExplorerProject,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
