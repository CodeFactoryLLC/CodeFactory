using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Base implementation all C# models must implement.
    /// </summary>
    public interface ICsModel:IDotNetModel
    {
        /// <summary>
        /// The type of c# model that is implemented.
        /// </summary>
        new CsModelType ModelType { get; }

    }
}
