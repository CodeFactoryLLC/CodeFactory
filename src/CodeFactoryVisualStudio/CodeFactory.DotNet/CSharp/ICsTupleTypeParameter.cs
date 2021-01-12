using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.DotNet.CSharp
{
    public interface ICsTupleTypeParameter:ICsModel,IDotNetTupleTypeParameter
    {
        /// <summary>
        /// The model with the type definition assigned to the tuple.
        /// </summary>
        new CsType TupleType { get; }
    }
}
