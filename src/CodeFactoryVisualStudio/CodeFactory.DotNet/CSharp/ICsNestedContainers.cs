//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2023 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Definition of the container types that can be nested in other containers.
    /// </summary>
    public interface ICsNestedContainers:ICsContainer,IDotNetNestedContainers
    {
        /// <summary>
        /// Models that are nested in the implementation of this container.
        /// </summary>
        new IReadOnlyList<ICsNestedModel> NestedModels { get; }

        /// <summary>
        /// Classes that are nested in this container.
        /// </summary>
        new IReadOnlyList<CsClass> NestedClasses { get; }

        /// <summary>
        /// Interfaces that are nested in this container.
        /// </summary>
        new IReadOnlyList<CsInterface> NestedInterfaces { get; }

        /// <summary>
        /// Structures that are nested in this container.
        /// </summary>
        new IReadOnlyList<CsStructure> NestedStructures { get; }

        /// <summary>
        /// Enums that are nested in this container.
        /// </summary>
        new IReadOnlyList<CsEnum> NestedEnums { get; }
    }
}
