//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{

    /// <summary>
    /// Base implementation for all code factory commands that are directly executed by the Visual Studio Enviornment.
    /// </summary>
    /// <typeparam name="TModel">Target code factory model to be provided for the command.</typeparam>
    public interface IVsEnvironmentCommand<TModel>: IVsCommandInformation where TModel : class
    {
        /// <summary>
        /// Code factory framework calls this method when the command has been executed. 
        /// </summary>
        /// <param name="result">The code factory model that has generated and provided to the command to process.</param>
        Task ExecuteCommandAsync(TModel result);

        /// <summary>
        /// Global visual studio commands that can be accessed from this visual studio command.
        /// </summary>
        IVsActions VisualStudioActions { get; }
    }
}
