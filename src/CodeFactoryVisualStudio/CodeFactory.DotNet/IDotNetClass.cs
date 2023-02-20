//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using CodeFactory.DotNet;
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition for a class in .net.
    /// </summary>
    public interface IDotNetClass:IDotNetNestedContainers
    {

        /// <summary>
        /// List of the constructors implemented in this class.
        /// </summary>
        IReadOnlyList<IDotNetMethod> Constructors { get; }

        /// <summary>
        /// The destructor implemented in this class.
        /// </summary>
        IDotNetMethod Destructor { get; }

        /// <summary>
        ///     List of the fields implemented in this class.
        /// </summary>
        IReadOnlyList<IDotNetField> Fields { get; }

        /// <summary>
        ///     The base class assigned to this class. This will be null if HasBase is false.
        /// </summary>
        IDotNetClass BaseClass { get; }

        /// <summary>
        ///     Flag that determines if this class is static.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        ///     Flat that determines if this is an abstract class.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        ///     Flag that determines if this class has been sealed.
        /// </summary>
        bool IsSealed { get; }
    }
}
