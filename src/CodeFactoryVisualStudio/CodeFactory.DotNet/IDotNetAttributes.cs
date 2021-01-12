//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet
{
    /// <summary>
    /// Interface that determines if a .net model has attributes assigned.
    /// </summary>
    public interface IDotNetAttributes
    {
        /// <summary>
        ///     Flag that determines if attributes are assigned.
        /// </summary>
        bool HasAttributes { get; }

        /// <summary>
        ///     The attributes assigned to this item. If the HasAttributes is false this will be an empty list.
        /// </summary>
        IReadOnlyList<IDotNetAttribute> Attributes { get; }
    }
}
