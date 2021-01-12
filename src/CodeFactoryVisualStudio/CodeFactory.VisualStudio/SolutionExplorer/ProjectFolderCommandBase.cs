//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.Logging;


namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="IProjectFolderCommand"/>
    /// </summary>
    public abstract class ProjectFolderCommandBase:VsCommandBase<VsProjectFolder>,IProjectFolderCommand
    {
        /// <inheritdoc />
        protected ProjectFolderCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger, vsActions, VsCommandType.SolutionExplorerProjectFolder,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
