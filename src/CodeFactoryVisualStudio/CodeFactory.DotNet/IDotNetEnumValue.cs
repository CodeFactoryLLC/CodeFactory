//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Data model that provides information to a specific enumeration value implemented in an enumeration.
    /// </summary>
    public interface  IDotNetEnumValue: IDotNetModel, IDotNetAttributes, IDocumentation, IParent, ILookup, ISourceFiles
    {
        /// <summary>
        ///     The name of the enumeration value.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The security scope assigned to the enumeration value.
        /// </summary>
        DotNetSecurity Security { get; }

        /// <summary>
        ///     The value that has been assigned to the enumeration value.
        /// </summary>
        string Value { get; }
    }
}
