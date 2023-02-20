//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2023 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model definition for a class in C#.
    /// </summary>
    public interface ICsClass:ICsNestedContainers,IDotNetClass
    {
        /// <summary>
        /// List of the constructors implemented in this class.
        /// </summary>
        new IReadOnlyList<CsMethod> Constructors { get; }

        /// <summary>
        /// The destructor implemented in this class.
        /// </summary>
        new CsMethod Destructor { get; }

        /// <summary>
        ///     List of the fields implemented in this class.
        /// </summary>
        new IReadOnlyList<CsField> Fields { get; }

        /// <summary>
        ///     The base class assigned to this class. This will be null if HasBase is false.
        /// </summary>
        new CsClass BaseClass { get; }


    }
}
