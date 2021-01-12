//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using CodeFactory.Logging;

namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="ISolutionFolderCommand"/>
    /// </summary>
    public abstract class SolutionFolderCommandBase:VsCommandBase<VsSolutionFolder>,ISolutionFolderCommand
    {
        /// <inheritdoc />
        protected SolutionFolderCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger, vsActions, VsCommandType.SolutionExplorerSolutionFolder,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
