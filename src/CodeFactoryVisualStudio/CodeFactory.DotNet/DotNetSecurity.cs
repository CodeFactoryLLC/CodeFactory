//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Enumeration of the security scope the target .net model is set to.
    /// </summary>
    public enum DotNetSecurity
    {
        /// <summary>
        /// Security is set to public access
        /// </summary>
        Public = 0,

        /// <summary>
        /// Security is set to protected access
        /// </summary>
        Protected = 1,

        /// <summary>
        /// Security is set to internal access
        /// </summary>
        Internal = 2,

        /// <summary>
        /// Security is set to private access
        /// </summary>
        Private = 3,

        /// <summary>
        /// Security is set to protected internal access
        /// </summary>
        ProtectedInternal = 4,

        /// <summary>
        /// Security is set to projected or internal access
        /// </summary>
        ProtectedOrInternal = 5,

        /// <summary>
        /// Security scope is unknown
        /// </summary>
        Unknown = 9999
    }
}
