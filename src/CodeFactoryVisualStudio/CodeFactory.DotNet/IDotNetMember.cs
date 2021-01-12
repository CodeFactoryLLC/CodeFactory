//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Base definition for all .net member models.
    /// </summary>
    public interface IDotNetMember:IDotNetModel,ISourceFiles,IDotNetAttributes,IDocumentation,IParent,ILookup
    {
        /// <summary>
        ///     The name assigned to the member.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The security scope that has been assigned to the member.
        /// </summary>
        DotNetSecurity Security { get; }

        /// <summary>
        /// The type of member the model is.
        /// </summary>
        DotNetMemberType MemberType { get; }

    }
}
