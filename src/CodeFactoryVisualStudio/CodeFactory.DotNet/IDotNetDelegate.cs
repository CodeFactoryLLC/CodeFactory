//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition of a delegate in .net.
    /// </summary>
    public interface IDotNetDelegate:IDotNetModel,IDotNetAttributes,IDotNetGeneric,IDocumentation,IParent,ILookup,ISourceFiles
    {
        /// <summary>
        ///     The name assigned to the this item.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The namespace the delegate is assigned to.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        ///     The security scope that has been assigned to this item.
        /// </summary>
        DotNetSecurity Security { get; }

        /// <summary>
        ///     The type information about the return type assigned to the method.
        /// </summary>
        IDotNetType ReturnType { get; }

        /// <summary>
        ///     Flag that determines if the method has parameters assigned to it.
        /// </summary>
        bool HasParameters { get; }

        /// <summary>
        ///     List of the parameters that have been assigned to the delegate. If HasParameters property is set to false this will be an empty list.
        /// </summary>
        IReadOnlyList<IDotNetParameter> Parameters { get; }

        /// <summary>
        /// The invoke method definition for this delegate.
        /// </summary>
        IDotNetMethod InvokeMethod { get; }

        /// <summary>
        /// The begin invoke method definition for this delegate.
        /// </summary>
        IDotNetMethod BeginInvokeMethod { get; }

        /// <summary>
        /// The end invoke method definition for this delegate.
        /// </summary>
        IDotNetMethod EndInvokeMethod { get; }

        /// <summary>
        /// Flag that determines if the delegate return is a void.
        /// </summary>
        bool IsVoid { get; }
    }
}
