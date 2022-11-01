//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Threading.Tasks;

namespace CodeFactory.VisualStudio.UI
{
    /// <summary>
    /// Definition of the user interface actions that are supported in visual studio.
    /// </summary>
    public interface IVsUIActions
    {
        /// <summary>
        /// Creates a new instance of a visual studio user control supported by code factory. This will load the <see cref="IVsActions"/> into the control as well as the logger that supports the user control. 
        /// </summary>
        /// <typeparam name="T">The type of visual studio user control to create.</typeparam>
        /// <returns>New instance of the target user control.</returns>
        /// <exception cref="VisualStudioException">Raises a visual studio error if there was a problem creating the user control. Review the internal exception for the source of the error.</exception>
        Task<T> CreateVsUserControlAsync<T>() where T : VsUserControl;

        /// <summary>
        /// Displays a dialog window in visual studio that hosts a user control that implements <see cref="VsUserControl"/>. This makes sure the dialog window is thread safe to be used with visual studio. 
        /// </summary>
        /// <typeparam name="T">The type of the user control that will be hosted in the dialog window.</typeparam>
        /// <param name="userControl">The instance of the user control that is to be hosted in the dialog window.</param>
        /// <returns>Returns the result for the window which returns a true if a close event occurred, a false when a cancel event occurred, or null if neither were triggered.</returns>
        Task<bool?> ShowDialogWindowAsync(VsUserControl userControl);
    }
}
