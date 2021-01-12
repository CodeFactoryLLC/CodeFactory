//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Enumeration of the types of member comparison 
    /// </summary>
    public enum MemberComparisonType
    {
        /// <summary>
        /// Member is compared by the base signature only, no key words, instance scoping , or security added.
        /// </summary>
        Base = 0,

        /// <summary>
        /// Member is compared by the base signature and the security assigned to the member.
        /// </summary>
        Security = 1,

        /// <summary>
        /// Member is compared by the full signature including scoping and target keywords
        /// </summary>
        Full = 2
    }
}
