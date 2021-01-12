using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model contract for information about a parameter used in a generic definition.
    /// </summary>
    public interface ICsGenericParameter:ICsModel,IDotNetGenericParameter
    {
        /// <summary>
        /// The constraining types the generic parameter must ad hear to. If there are no constraining types an empty list will be returned.
        /// </summary>
        new IReadOnlyList<CsType> ConstrainingTypes { get; }

        /// <summary>
        /// The type definition of the generic parameter.
        /// </summary>
        new CsType Type { get; }
    }
}
