//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Data model that provides information on an enumeration.
    /// </summary>
    public interface IDotNetEnum: IDotNetModel, IDotNetAttributes, IDocumentation, IParent, ILookup, ISourceFiles
    {
        /// <summary>
        ///     The name of the enumeration.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The namespace the enumeration belongs to.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        ///     The security scope assigned to the enumeration.
        /// </summary>
        DotNetSecurity Security { get; }

        /// <summary>
        ///     List of the enumeration values implemented in this enumeration.
        /// </summary>
        IReadOnlyList<IDotNetEnumValue> Values { get; }
    }
}
