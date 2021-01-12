//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using CodeFactory.Logging;

namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="ISolutionDocumentCommand"/>
    /// </summary>
    public abstract class SolutionDocumentCommandBase:VsCommandBase<VsDocument>,ISolutionDocumentCommand
    {
        /// <inheritdoc />
        protected SolutionDocumentCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger, vsActions, VsCommandType.SolutionExplorerSolutionDocument,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
