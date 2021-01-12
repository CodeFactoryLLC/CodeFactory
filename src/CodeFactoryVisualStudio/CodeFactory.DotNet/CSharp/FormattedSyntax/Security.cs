//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp.FormattedSyntax
{
    /// <summary>
    /// Data class that defines the syntax for security scope within the C# language.
    /// </summary>
    public static class Security
    {
        /// <summary>
        /// Security scope that allows access to types and members only within files in the same assembly.
        /// </summary>
        public const string Internal = "internal";

        /// <summary>
        /// Security scope that allows access only within the scope of the body of a class or structure.
        /// </summary>
        public const string Private = "private";

        /// <summary>
        /// Security scope that allows access only within the containing class or types that derive from the containing class. (Note: Only in version 7.2 or later of the C# language)
        /// </summary>
        public const string PrivateProtected = "private protected";

        /// <summary>
        /// Security scope that allows access with the target class and any classes that derived from that class.
        /// </summary>
        public const string Protected = "protected";

        /// <summary>
        /// Security scope limited access to the current assembly or types derived from the containing class.
        /// </summary>
        public const string ProtectedInternal = "protected internal";

        /// <summary>
        /// Security scope that allows access to types and members and is the least restrictive security type.
        /// </summary>
        public const string Public = "public";


    }
}
