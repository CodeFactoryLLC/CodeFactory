//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition for a record structure in .net.
    /// </summary>
    public interface IDotNetRecordStructure:IDotNetContainer
    {
        /// <summary>
        /// List of the constructors for this record structure.
        /// </summary>
        IReadOnlyList<IDotNetMethod> Constructors { get; }

      
        /// <summary>
        ///     List of the fields for this record structure.
        /// </summary>
        IReadOnlyList<IDotNetField> Fields { get; }
    }
}
