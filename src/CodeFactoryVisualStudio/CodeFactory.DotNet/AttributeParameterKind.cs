//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Enumeration that determines the type of attribute parameter data that is being returned.
    /// </summary>
    public enum AttributeParameterKind
    {
        /// <summary>
        /// Is a simple value.
        /// </summary>
        Value = 0,

        /// <summary>
        /// Is a target named type.
        /// </summary>
        Type = 1,

        /// <summary>
        /// Is an enumeration item.
        /// </summary>
        Enum = 2,

        /// <summary>
        /// Is an array of multiple parameter values.
        /// </summary>
        Array = 3,

        /// <summary>
        /// The return data is unknown.
        /// </summary>
        Unknown = 9999
    }
}
