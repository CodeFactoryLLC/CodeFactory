//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet
{

    /// <summary>
    /// Definition that determines if the .net model implements generics.
    /// </summary>
    public interface IDotNetGeneric
    {
        /// <summary>
        ///     Flag the determines if this item supports generics
        /// </summary>
        bool IsGeneric { get; }

        /// <summary>
        ///     List of the generic parameters assigned.
        /// </summary>
        IReadOnlyList<IDotNetGenericParameter> GenericParameters { get; }

        /// <summary>
        ///     Flag that determines if the generics implementation has strong types passed in to the generics implementation.
        /// </summary>
        bool HasStrongTypesInGenerics { get; }

        /// <summary>
        ///     Enumeration of the strong types that are implemented for each generic parameter. This will be an empty list when there is no generic types implemented.
        /// </summary>
        IReadOnlyList<IDotNetType> GenericTypes { get; }
    }
}
