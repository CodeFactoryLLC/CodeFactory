//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    /// Configuration data model that holds loading information for loading a target visual studio command into code factory.
    /// </summary>
    public interface IVsActionConfiguration
    {
        /// <summary>
        ///     The assembly full name for an command.
        /// </summary>
        string ActionAssemblyFullName { get;}

        /// <summary>
        ///     The title that is assigned to the command.
        /// </summary>
        string Title { get;}

        /// <summary>
        /// The type of visual studio command being loaded.
        /// </summary>
        VsCommandType VisualStudioActionType { get;}
    }
}
