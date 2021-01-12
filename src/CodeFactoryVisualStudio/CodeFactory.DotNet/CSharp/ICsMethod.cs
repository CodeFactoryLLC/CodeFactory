//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model definition of a method in c#.
    /// </summary>
    public interface ICsMethod:ICsMember,ICsGeneric,IDotNetMethod
    {
        /// <summary>
        /// Determines the type of method that was loaded into this model.
        /// </summary>
        new CsMethodType MethodType { get; }

        /// <summary>
        ///     The type information about the return type assigned to the method. if flag <see cref="IsVoid"/> is true then the return type will be set to null.
        /// </summary>
        new CsType ReturnType { get; }

        /// <summary>
        ///     Enumeration of the parameters that have been assigned to the method. If HasParameters property is set to false this will be null.
        /// </summary>
        new IReadOnlyList<CsParameter> Parameters { get; }

    }
}
