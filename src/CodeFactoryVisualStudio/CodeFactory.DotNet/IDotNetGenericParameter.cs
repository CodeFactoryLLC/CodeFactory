//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet
{
    
    /// <summary>
    /// Model contract for information about a parameter used in a generic definition.
    /// </summary>
    public interface IDotNetGenericParameter:IDotNetModel
    {
        /// <summary>
        /// Flag that determines if the generic parameter uses the out keyword.
        /// </summary>
        bool HasOutKeyword { get; }

        /// <summary>
        /// Flag that determines if the generic parameter has a constraint that is must support construction of a new type.
        /// </summary>
        bool HasNewConstraint { get; }

        /// <summary>
        /// Flag that determines if the generic parameter has a constraint that it must implement from a class.
        /// </summary>
        bool HasClassConstraint { get; }

        /// <summary>
        /// Flag that determines if the generic parameter has a constraint that is must implement from a structure.
        /// </summary>
        bool HasStructConstraint { get; }

        /// <summary>
        /// Flag that determines if the generic parameter has constraining types the parameter must ad hear to.
        /// </summary>
        bool HasConstraintTypes { get; }

        /// <summary>
        /// The constraining types the generic parameter must ad hear to. If there are no constraining types an empty list will be returned.
        /// </summary>
        IReadOnlyList<IDotNetType> ConstrainingTypes { get; }

        /// <summary>
        /// The type definition of the generic parameter.
        /// </summary>
        IDotNetType Type { get; }
    }
}
