//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Defines lookup information for a model that supports being searched for.
    /// </summary>
    public interface ILookup
    {
        /// <summary>
        /// The fully qualified path for this model that can be used when searching the source for the model.
        /// </summary>
        string LookupPath { get; }
    }
}
