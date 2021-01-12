//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// The type of dot net member.
    /// </summary>
    public enum DotNetMemberType
    {
        /// <summary>
        /// The member is a event model.
        /// </summary>
        Event = 0,

        /// <summary>
        /// The member is a field model.
        /// </summary>
        Field = 1,

        /// <summary>
        /// The member is a method model.
        /// </summary>
        Method = 2,

        /// <summary>
        /// The member is a property model.
        /// </summary>
        Property = 3,

        /// <summary>
        /// The member type is currently not known.
        /// </summary>
        Unknown = 9999
    }
}
