//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// The base implementation all container type models must implement in .net.
    /// </summary>
    public interface IDotNetContainer:IDotNetModel,ISourceFiles,IDotNetAttributes,IDocumentation,IDotNetGeneric,IParent,ILookup
    {
        /// <summary>
        /// The type of container model that has been implemented.
        /// </summary>
        DotNetContainerType ContainerType { get; }

        /// <summary>
        ///     The name of the container.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The namespace the container objects belongs to.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        ///     The security scope assigned to the container.
        /// </summary>
        DotNetSecurity Security { get; }

        /// <summary>
        ///     List of the interfaces that are inherited by this container.
        /// </summary>
        IReadOnlyList<IDotNetInterface> InheritedInterfaces { get; }

        /// <summary>
        ///     List of the members that are implemented in this container.
        /// </summary>
        IReadOnlyList<IDotNetMember> Members { get; }

        /// <summary>
        ///     List of the methods that are implemented in this container.
        /// </summary>
        IReadOnlyList<IDotNetMethod> Methods { get; }

        /// <summary>
        ///     List of the properties that are implemented in this container.
        /// </summary>
        IReadOnlyList<IDotNetProperty> Properties { get; }

        /// <summary>
        ///     Enumeration of the events assigned to this container. If HasEvents is false this will be null.
        /// </summary>
        IReadOnlyList<IDotNetEvent> Events { get; }

        /// <summary>
        /// The source code syntax that is stored in the body of the container model. This will be null if the container was not loaded from source code.
        /// </summary>
        Task<string> GetBodySyntaxAsync();
    }
}
