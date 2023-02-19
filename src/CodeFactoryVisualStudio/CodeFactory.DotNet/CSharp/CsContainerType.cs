﻿//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020-2023 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Definition of the different types of container based members are supported by the C# source code type.
    /// </summary>
    public enum CsContainerType
    {
        /// <summary>
        /// The container implements a class model.
        /// </summary>
        Class = DotNetContainerType.Class,

        /// <summary>
        /// The container implements a interface model.
        /// </summary>
        Interface = DotNetContainerType.Interface,

        /// <summary>
        /// The container implements a structure model.
        /// </summary>
        Structure = DotNetContainerType.Structure,

        /// <summary>
        /// The container implements a record model.
        /// </summary>
        Record = DotNetContainerType.Record,

        /// <summary>
        /// The container implements a record structure model.
        /// </summary>
        RecordStructure = DotNetContainerType.RecordStructure,

        /// <summary>
        /// The container is of an unknown type.
        /// </summary>
        Unknown = DotNetContainerType.Unknown
 
    }
}
