//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Enumeration that identifies the target model type that is nested.
    /// </summary>
    public enum DotNetNestedType
    {
        /// <summary>
        /// This nested type is a Class implementation
        /// </summary>
        Class = 0,

        /// <summary>
        /// This nested type is a Enum implementation
        /// </summary>
        Enum = 1,

        /// <summary>
        /// This nested type is a Interface implementation
        /// </summary>
        Interface = 2,

        /// <summary>
        /// This nested type is a Struct implementation
        /// </summary>
        Structure = 3,

        /// <summary>
        /// This model is currently not nested in any other type.
        /// </summary>
        NotNested = 9999
    }
}
