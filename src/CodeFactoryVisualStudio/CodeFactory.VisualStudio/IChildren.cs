//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Defining if the visual studio object has child objects.
    /// </summary>
    public interface IChildren
    {
        /// <summary>
        /// Flag that determines if this visual studio object has child objects.
        /// </summary>
        bool HasChildren { get; }

    }
}
