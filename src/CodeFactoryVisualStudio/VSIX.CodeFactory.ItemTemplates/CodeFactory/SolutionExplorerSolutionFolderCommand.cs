using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFactory.Logging;
using CodeFactory.VisualStudio;
using CodeFactory.VisualStudio.SolutionExplorer;

namespace $rootnamespace$
{

    /// <summary>
    /// Code factory command for automation of a folder that is managed under the solution when selected from solution explorer.
    /// </summary>
    public class $safeitemrootname$:SolutionFolderCommandBase
    {
        private static readonly string commandTitle = "Replace with command title to be displayed in context menu";
        private static readonly string commandDescription = "Replace with description of what this command does";
        #pragma warning disable CS1998
        /// <inheritdoc />
        public $safeitemrootname$(ILogger logger, IVsActions vsActions) : base(logger, vsActions,commandTitle,commandDescription)
        {
            //Intentionally blank
        }

        #region Overrides of VsCommandBase<VsSolutionFolder>

        /// <summary>
        /// Validation logic that will determine if this command should be enabled for execution.
        /// </summary>
        /// <param name="result">The target model data that will be used to determine if this command should be enabled.</param>
        /// <returns>Boolean flag that will tell code factory to enable this command or disable it.</returns>
        public override async Task<bool> EnableCommandAsync(VsSolutionFolder result)
        {
            //Result that determines if the the command is enabled and visible in the context menu for execution.
            bool isEnabled = false;

            try
            {
                //TODO: Add logic to determine if this command is enabled.
            }
            catch (Exception unhandledError)
            {
                _logger.Error($"The following unhandled error occurred while checking if the solution explorer solution folder command {commandTitle} is enabled. ",
                    unhandledError);
                isEnabled = false;
            }

            return isEnabled;
        }

        /// <summary>
        /// Code factory framework calls this method when the command has been executed. 
        /// </summary>
        /// <param name="result">The code factory model that has generated and provided to the command to process.</param>
        public override async Task ExecuteCommandAsync(VsSolutionFolder result)
        {
            try
            {
                //TODO: Add command logic
            }
            catch (Exception unhandledError)
            {
                _logger.Error($"The following unhandled error occurred while executing the solution explorer solution folder command {commandTitle}. ",
                    unhandledError);

            }
        }

        #endregion
    }
}
