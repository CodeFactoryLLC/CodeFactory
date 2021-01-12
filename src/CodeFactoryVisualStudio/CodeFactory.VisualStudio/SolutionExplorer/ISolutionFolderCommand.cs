//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.SolutionExplorer
{
    /// <summary>
    /// Code factory command that is triggered from the context menu of the a solution folder in the solution explorer window.
    /// </summary>
    public interface ISolutionFolderCommand:IVsFactoryCommand<VsSolutionFolder>
    {
        //Intentionally blank
    }
}
