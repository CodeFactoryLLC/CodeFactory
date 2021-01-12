//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using CodeFactory.Logging;

namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="ISolutionCommand"/>
    /// </summary>
    public abstract class SolutionCommandBase:VsCommandBase<VsSolution>,ISolutionCommand
    {

        /// <inheritdoc />
        protected SolutionCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger,vsActions,VsCommandType.SolutionExplorerSolution,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
