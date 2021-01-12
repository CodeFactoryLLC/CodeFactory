//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition of a method in .net.
    /// </summary>
    public interface IDotNetMethod:IDotNetMember,IDotNetGeneric
    {
        /// <summary>
        /// Determines the type of method that was loaded into this model.
        /// </summary>
        DotNetMethodType MethodType { get; }

        /// <summary>
        ///     The type information about the return type assigned to the method. if flag <see cref="IsVoid"/> is true then the return type will be set to null.
        /// </summary>
        IDotNetType ReturnType { get; }

        /// <summary>
        ///     Flag that determines if the method has parameters assigned to it.
        /// </summary>
        bool HasParameters { get; }

        /// <summary>
        ///     Enumeration of the parameters that have been assigned to the method. If HasParameters property is set to false this will be null.
        /// </summary>
        IReadOnlyList<IDotNetParameter> Parameters { get; }

        /// <summary>
        ///     Flag that determines if the method has been implemented as abstract.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        ///     Flag that determines if the method has been implemented as virtual.
        /// </summary>
        bool IsVirtual { get; }

        /// <summary>
        ///     Flag that determines if the method has been sealed.
        /// </summary>
        bool IsSealed { get; }

        /// <summary>
        ///     Flag that determines if the method has been overridden.
        /// </summary>
        bool IsOverride { get; }

        /// <summary>
        ///     Flag that determines if this is a static method.
        /// </summary>
        bool IsStatic { get; }

        /// <summary>
        ///     Flag that determines if the methods return type is void.
        /// </summary>
        bool IsVoid { get; }

        /// <summary>
        ///     Flag that determines if the method implements the Async keyword.
        /// </summary>
        bool IsAsync { get; }

        /// <summary>
        ///     Flag that determines if the method is an extension method.
        /// </summary>
        bool IsExtension { get; }

        /// <summary>
        /// The source code syntax that is stored in the body of the method. This will be null if the method was not loaded from source code.
        /// </summary>
        Task<string> GetBodySyntaxAsync();

    }
}
