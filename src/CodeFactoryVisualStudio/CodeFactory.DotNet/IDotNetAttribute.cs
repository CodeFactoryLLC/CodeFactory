//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition for an attribute in a .net implementation.
    /// </summary>
    public interface IDotNetAttribute:IDotNetModel,IParent,ISourceFiles
    {
        /// <summary>
        ///     The type information for the attribute itself.
        /// </summary>
        IDotNetType Type { get; }

        /// <summary>
        ///     Flag that determines if the attribute has parameters
        /// </summary>
        bool HasParameters { get; }

        /// <summary>
        ///     Enumeration of the parameters that are assigned to the attribute. This will be an empty list if HasParameters is false.
        /// </summary>
        IReadOnlyList<IDotNetAttributeParameter> Parameters { get; }
    }
}
