//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model definition of a Field in .net.
    /// </summary>
    public interface ICsField:ICsMember,IDotNetField
    {
        /// <summary>
        ///     The data type assigned to the field.
        /// </summary>
        new CsType DataType { get; }
    }
}
