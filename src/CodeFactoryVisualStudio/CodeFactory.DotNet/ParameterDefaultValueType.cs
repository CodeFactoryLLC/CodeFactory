//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    public enum ParameterDefaultValueType
    {
        /// <summary>
        /// There is no default value or it is unknown
        /// </summary>
        None = 0,

        /// <summary>
        /// The provided literal value should be used for the default type.
        /// </summary>
        Value = 1,

        /// <summary>
        /// The default keyword for the type should be used.
        /// </summary>
        DefaultKeyWord = 2,

        /// <summary>
        /// The keyword that represents a null implementation of the type should be used.
        /// </summary>
        NullKeyword = 3
    }
}
