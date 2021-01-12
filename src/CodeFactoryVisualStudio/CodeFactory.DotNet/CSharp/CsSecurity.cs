//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Enumeration that determines the security scope of the C# model being represented.
    /// </summary>
    public enum CsSecurity
    {
        /// <summary>
        /// Security is set to public access
        /// </summary>
        Public = DotNetSecurity.Public,

        /// <summary>
        /// Security is set to protected access
        /// </summary>
        Protected = DotNetSecurity.Protected,

        /// <summary>
        /// Security is set to internal access
        /// </summary>
        Internal = DotNetSecurity.Internal,

        /// <summary>
        /// Security is set to private access
        /// </summary>
        Private = DotNetSecurity.Private,

        /// <summary>
        /// Security is set to protected internal access
        /// </summary>
        ProtectedInternal = DotNetSecurity.ProtectedInternal,

        /// <summary>
        /// Security is set to projected or internal access
        /// </summary>
        ProtectedOrInternal = DotNetSecurity.ProtectedOrInternal,

        /// <summary>
        /// Security scope is unknown
        /// </summary>
        Unknown = DotNetSecurity.Unknown
    }
}
