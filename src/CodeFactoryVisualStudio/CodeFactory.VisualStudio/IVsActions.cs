//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Threading.Tasks;
using CodeFactory.VisualStudio.UI;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Code factory commands that are globally used in Visual Studio.
    /// </summary>
    public interface IVsActions
    {

        /// <summary>
        /// Gets the most current model of the solution.
        /// </summary>
        /// <returns>The solution model.</returns>
        Task<VsSolution> GetSolutionAsync();

        /// <summary>
        /// Visual Studio actions that directly interact with Visual Studio itself.
        /// </summary>
        IVsEnvironmentActions EnvironmentActions { get; }

        /// <summary>
        /// Visual Studio actions that work with the <see cref="IVsSolution"/> model.
        /// </summary>
        IVsSolutionActions SolutionActions { get;}

        /// <summary>
        /// Visual Studio actions that work with the <see cref="IVsSolutionFolder"/> model.
        /// </summary>
        IVsSolutionFolderActions SolutionFolderActions { get; }

        /// <summary>
        /// Visual Studio actions that work with the <see cref="IVsProject"/> model.
        /// </summary>
        IVsProjectActions ProjectActions { get; }

        /// <summary>
        /// Visual Studio actions that work with the <see cref="IVsReference"/> model.
        /// </summary>
        IVsReferenceActions ProjectReferenceActions { get; }

        /// <summary>
        /// Visual Studio actions that work with the <see cref="IVsProjectFolder"/> model.
        /// </summary>
        IVsProjectFolderActions ProjectFolderActions { get; }

        /// <summary>
        /// Visual Studio actions that work with the <see cref="IVsDocument"/> model.
        /// </summary>
        IVsDocumentActions DocumentActions { get; }

        /// <summary>
        /// Visual Studio actions that work the the Visual Studio user interface.
        /// </summary>
        IVsUIActions UserInterfaceActions { get; }

        /// <summary>
        /// Visual Studio actions that work with source models.
        /// </summary>
        IVsSourceActions SourceActions { get; }

        
    }
}
