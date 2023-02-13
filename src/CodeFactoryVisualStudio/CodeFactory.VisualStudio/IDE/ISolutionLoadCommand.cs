//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.IDE
{
    /// <summary>
    /// Code factory command that triggers once the solution has been loaded. Will only be called once. 
    /// </summary>
    public interface ISolutionLoadCommand : IVsEnvironmentCommand<VsSolution>
    {
        //Intentionally blank
    }
}
