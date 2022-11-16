//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model definition of a property in C#.
    /// </summary>
    public interface ICsProperty:ICsMember,IDotNetProperty
    {
        /// <summary>
        ///     The source data type that is managed by this property.
        /// </summary>
        new CsType PropertyType { get; }

        /// <summary>
        ///     The security scope that is assigned to the get accessor. Make sure you check the HasGet to determine if the property supports get operations.
        /// </summary>
        [Obsolete("This will be removed in later editions of the SDK. Use the GetMethod property to access the get method details.",false)]
        new CsSecurity GetSecurity { get; }

        /// <summary>
        ///     The security scope that is assigned to the set accessor. Make sure you check the HasSet to determine if the property supports set operations.
        /// </summary>
        [Obsolete("This will be removed in later editions of the SDK. Use the SetMethod property to access the set method details.",false)]
        new CsSecurity SetSecurity { get; }
    }
}
