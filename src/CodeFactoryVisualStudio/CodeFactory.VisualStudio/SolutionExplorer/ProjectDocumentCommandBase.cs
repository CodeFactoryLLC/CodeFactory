//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using CodeFactory.Logging;


namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="IProjectDocumentCommand"/>
    /// </summary>
    public abstract class ProjectDocumentCommandBase:VsCommandBase<VsDocument>,IProjectDocumentCommand
    {
        /// <inheritdoc />
        protected ProjectDocumentCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger, vsActions, VsCommandType.SolutionExplorerProjectDocument,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
