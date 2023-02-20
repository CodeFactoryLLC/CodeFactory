//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition for a structure in .net.
    /// </summary>
    public interface IDotNetStructure:IDotNetNestedContainers
    {
        /// <summary>
        /// List of the constructors for this structure.
        /// </summary>
        IReadOnlyList<IDotNetMethod> Constructors { get; }

      
        /// <summary>
        ///     List of the fields for this structure.
        /// </summary>
        IReadOnlyList<IDotNetField> Fields { get; }
    }
}
