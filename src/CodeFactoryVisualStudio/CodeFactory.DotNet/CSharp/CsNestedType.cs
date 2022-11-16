//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Enumeration that identifies the target model type that is nested.
    /// </summary>
    public enum CsNestedType
    {
        /// <summary>
        /// This nested type is a Class implementation
        /// </summary>
        Class = DotNetNestedType.Class,

        /// <summary>
        /// This nested type is a Enum implementation
        /// </summary>
        Enum = DotNetNestedType.Enum,

        /// <summary>
        /// This nested type is a Interface implementation
        /// </summary>
        Interface = DotNetNestedType.Interface,

        /// <summary>
        /// This nested type is a Struct implementation
        /// </summary>
        Structure = DotNetNestedType.Structure,

        /// <summary>
        /// This model is currently not nested in any other type.
        /// </summary>
        NotNested = DotNetNestedType.NotNested
    }
}
