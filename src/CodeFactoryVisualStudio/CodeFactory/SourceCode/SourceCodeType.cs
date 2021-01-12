//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.SourceCode
{
    /// <summary>
    /// Enumeration of the source code types that are supported by code factory.
    /// </summary>
    public enum SourceCodeType
    {
        /// <summary>
        /// The source code is implemented in the C# programming language.
        /// </summary>
        CSharp = 0,

        /// <summary>
        /// The source code is implemented in the visual basic programming language.
        /// </summary>
        VisualBasic = 1,

        /// <summary>
        /// The source code type is not supported or unknown to code factory.
        /// </summary>
        Unknown = 9999
    }
}
