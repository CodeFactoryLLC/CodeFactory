//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Definition of the container types that can be nested in other containers.
    /// </summary>
    public interface  IDotNetNestedContainers:IDotNetContainer
    {

        /// <summary>
        /// Models that are nested in the implementation of this container.
        /// </summary>
        IReadOnlyList<IDotNetNestedModel> NestedModels { get; }

        /// <summary>
        /// Classes that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetClass> NestedClasses { get; }

        /// <summary>
        /// Interfaces that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetInterface> NestedInterfaces { get; }

        /// <summary>
        /// Structures that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetStructure> NestedStructures { get; }

        /// <summary>
        /// Enums that are nested in this container.
        /// </summary>
        IReadOnlyList<IDotNetEnum> NestedEnums { get; }
    }
}
