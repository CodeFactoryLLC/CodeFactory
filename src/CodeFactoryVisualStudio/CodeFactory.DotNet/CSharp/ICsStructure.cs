//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model definition for a structure in C#.
    /// </summary>
    public interface ICsStructure:ICsContainer,IDotNetStructure
    {
        /// <summary>
        /// List of the constructors for this structure.
        /// </summary>
        new IReadOnlyList<CsMethod> Constructors { get; }


        /// <summary>
        ///     List of the fields for this structure.
        /// </summary>
        new IReadOnlyList<CsField> Fields { get; }
    }
}
