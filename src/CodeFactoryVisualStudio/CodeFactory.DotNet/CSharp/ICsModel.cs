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

        /// <summary>
        /// Searchs for an existing C# model that has been loaded with the load of the source code.
        /// </summary>
        /// <typeparam name="T">The target <see cref="CsModel"/> type to cast to before returning. </typeparam>
        /// <param name="lookupPath">The lookup path that is assigned to a loaded model.</param>
        /// <returns>Returns the model as the identified type it will either return the instance or null if it is not found or not the correct type.</returns>
        T GetModel<T>(string lookupPath) where T : class, ICsModel;

        /// <summary>
        /// Searchs for an existing C# model that has been loaded with the load of the source code.
        /// </summary>
        /// <param name="lookupPath">The lookup path that is assigned to a loaded model.</param>
        /// <returns>Returns the model as the base <see cref="CsModel"/> type. </returns>
        CsModel GetModel(string lookupPath);
    }
}
