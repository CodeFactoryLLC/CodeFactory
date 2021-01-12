using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Definition that determines if the c# model implements generics.
    /// </summary>
    public interface ICsGeneric:IDotNetGeneric
    {
        /// <summary>
        ///     List of the generic parameters assigned.
        /// </summary>
        new IReadOnlyList<CsGenericParameter> GenericParameters { get; }

        /// <summary>
        ///     List of the strong types that are implemented for each generic parameter. This will be an empty List when there is no generic types implemented.
        /// </summary>
        new IReadOnlyList<CsType> GenericTypes { get; }
    }
}
