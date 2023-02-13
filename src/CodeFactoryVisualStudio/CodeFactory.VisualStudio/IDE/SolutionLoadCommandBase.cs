//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************

using CodeFactory.Logging;

namespace CodeFactory.VisualStudio.IDE
{
    /// <summary>
    /// Base implementation of the solution explorer command <see cref="ISolutionLoadCommand"/>
    /// </summary>
    public abstract class SolutionLoadCommandBase: VsEnviromentCommandBase<VsSolution>,ISolutionLoadCommand
    {

        /// <inheritdoc />
        protected SolutionLoadCommandBase(ILogger logger, IVsActions vsActions,string commandTitle, string commandDescription) : base(logger,vsActions,VsCommandType.IDESolutionLoad,commandTitle,commandDescription)
        {
            //Intentionally blank
        }
    }
}
