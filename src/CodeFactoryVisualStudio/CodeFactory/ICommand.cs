//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Threading.Tasks;

namespace CodeFactory
{
    /// <summary>
    /// Base implementation for all code factory commands.
    /// </summary>
    /// <typeparam name="TModel">Target code factory model to be provided for the command.</typeparam>
    public interface ICommand<TModel> where TModel:class
    {
        /// <summary>
        /// Validation logic that will determine if this command should be enabled for execution.
        /// </summary>
        /// <param name="result">The target model data that will be used to determine if this command should be enabled.</param>
        /// <returns>Boolean flag that will tell code factory to enable this command or disable it.</returns>
        Task<bool> EnableCommandAsync(TModel result);

        /// <summary>
        /// Code factory framework calls this method when the command has been executed. 
        /// </summary>
        /// <param name="result">The code factory model that has generated and provided to the command to process.</param>
        Task ExecuteCommandAsync(TModel result);
    }
}
