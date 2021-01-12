//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Enumeration of the types of members that are supported in the c# source code type.
    /// </summary>
    public enum CsMemberType
    {
        /// <summary>
        /// The member is a event model.
        /// </summary>
        Event = DotNetMemberType.Event,

        /// <summary>
        /// The member is a field model.
        /// </summary>
        Field = DotNetMemberType.Field,

        /// <summary>
        /// The member is a method model.
        /// </summary>
        Method = DotNetMemberType.Method,

        /// <summary>
        /// The member is a property model.
        /// </summary>
        Property = DotNetMemberType.Property,

        /// <summary>
        /// The member type is currently not known.
        /// </summary>
        Unknown = DotNetMemberType.Unknown
    }
}
