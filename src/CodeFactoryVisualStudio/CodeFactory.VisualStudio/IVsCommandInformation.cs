//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Interface that provides information used by code factory to load the command.
    /// </summary>
    public interface IVsCommandInformation
    {
        /// <summary>
        /// Command title that will be displayed within visual studio.
        /// </summary>
        string CommandTitle { get; }

        /// <summary>
        /// An optional description that describes what this factory command is intended for. 
        /// </summary>
        string CommandDescription { get; }



        /// <summary>
        /// The target type of command that is being loaded.
        /// </summary>
        VsCommandType CommandType { get; }
    }
}
