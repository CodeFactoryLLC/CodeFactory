//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Threading.Tasks;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition of a property in .net.
    /// </summary>
    public interface IDotNetProperty:IDotNetMember
    {
        /// <summary>
        ///     The source data type that is managed by this property.
        /// </summary>
        IDotNetType PropertyType { get; }

        /// <summary>
        ///     Flag that determines if this property supports get access.
        /// </summary>
        bool HasGet { get; }

        /// <summary>
        ///     The security scope that is assigned to the get accessor. Make sure you check the HasGet to determine if the property supports get operations.
        /// </summary>
        DotNetSecurity GetSecurity { get; }

        /// <summary>
        ///     Flag that determines if this property supports set access.
        /// </summary>
        bool HasSet { get; }

        /// <summary>
        ///     The security scope that is assigned to the set accessor. Make sure you check the HasSet to determine if the property supports set operations.
        /// </summary>
        DotNetSecurity SetSecurity { get; }

        /// <summary>
        ///     Flag that determines if the property is implemented as an abstract property.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        ///     Flag that determines if the property is implemented as virtual.
        /// </summary>
        bool IsVirtual { get; }

        /// <summary>
        ///     Flag that determines if the property has been sealed.
        /// </summary>
        bool IsSealed { get; }

        /// <summary>
        ///     Flag that determines if the property has been overridden.
        /// </summary>
        bool IsOverride { get; }

        /// <summary>
        ///     Flag that determines if the property has been implemented as static.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        /// Provides access to the get method statement in the property. This will be null the property does not have a get statement.
        /// </summary>
        IDotNetMethod GetMethod { get; }

        /// <summary>
        /// Provides access to the set method statement in the property. This will be null the property does not have a set statement.
        /// </summary>
        IDotNetMethod SetMethod { get; }

        /// <summary>
        /// The source code syntax that is stored in the body of the property get. This will be null if was not loaded from source code.
        /// </summary>
        [Obsolete("This will be removed in later editions of the SDK. Use the GetMethod property to access the get method details.",false)]
        Task<string> LoadGetBodySyntaxAsync();

        /// <summary>
        /// The source code syntax that is stored in the body of the property get. This will be null if was not loaded from source code.
        /// </summary>
        [Obsolete("This will be removed in later editions of the SDK. Use the SetMethod property to access the set method details.",false)]
        Task<string> LoadSetBodySyntaxAsync();
    }
}
