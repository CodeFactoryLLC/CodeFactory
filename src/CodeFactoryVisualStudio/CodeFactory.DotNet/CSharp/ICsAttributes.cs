//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2022 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Interface that determines if a c# model has attributes assigned.
    /// </summary>
    public interface ICsAttributes:IDotNetAttributes
    {
        /// <summary>
        ///     The attributes assigned to this item. If the HasAttributes is false this will be an empty list.
        /// </summary>
        new IReadOnlyList<CsAttribute> Attributes { get; }
    }
}
