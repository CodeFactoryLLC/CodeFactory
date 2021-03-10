using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Visual Studio actions handle interaction with Visual Studio itself.
    /// </summary>
    public interface IVsEnvironmentActions
    {
        /// <summary>
        /// Writes the provided message to the CodeFactory output window in Visual Studio.
        /// </summary>
        /// <param name="message">The message to be written to the output window.</param>
        Task WriteToCodeFactoryOutputWindowAsync(string message);
    }
}
