//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.Logging;


namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="ICSharpSourceCommand"/>
    /// </summary>
    public abstract class CSharpSourceCommandBase:VsCommandBase<VsCSharpSource>,ICSharpSourceCommand
    {
        /// <inheritdoc />
        protected CSharpSourceCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger, vsActions, VsCommandType.SolutionExplorerCSharpSourceCode,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
