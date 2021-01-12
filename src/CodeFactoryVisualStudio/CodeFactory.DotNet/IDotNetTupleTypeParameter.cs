//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Data model that tracks an individual part of a tuple definition.
    /// </summary>
    public interface IDotNetTupleTypeParameter:IDotNetModel
    {
        /// <summary>
        /// Flag that determines if the named assigned to the tuple was system generated or defined in source.
        /// </summary>
        bool HasDefaultName { get; }

        /// <summary>
        /// The name assigned to the tuple parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The model with the type definition assigned to the tuple.
        /// </summary>
        IDotNetType TupleType { get; }
    }
}
