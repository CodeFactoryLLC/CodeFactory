//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition for a namespace definition inside a code file in .net.
    /// </summary>
    public interface IDotNetNamespace:IDotNetModel,IParent,ILookup,ISourceFiles
    {
        /// <summary>
        /// The name of the namespace.
        /// </summary>
        string Name { get; }
    }
}
