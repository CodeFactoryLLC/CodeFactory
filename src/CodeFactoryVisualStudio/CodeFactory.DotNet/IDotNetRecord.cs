//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using CodeFactory.DotNet;
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition for a record in .net.
    /// </summary>
    public interface IDotNetRecord:IDotNetContainer
    {

        /// <summary>
        /// List of the constructors implemented in this record.
        /// </summary>
        IReadOnlyList<IDotNetMethod> Constructors { get; }

        /// <summary>
        /// The destructor implemented in this record.
        /// </summary>
        IDotNetMethod Destructor { get; }

        /// <summary>
        ///     List of the fields implemented in this record.
        /// </summary>
        IReadOnlyList<IDotNetField> Fields { get; }

        /// <summary>
        ///     The base record assigned to this record. This will be null if HasBase is false.
        /// </summary>
        IDotNetRecord BaseRecord { get; }

        /// <summary>
        ///     Flag that determines if this record is static.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        ///     Flat that determines if this is an abstract record.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        ///     Flag that determines if this record has been sealed.
        /// </summary>
        bool IsSealed { get; }
    }
}
