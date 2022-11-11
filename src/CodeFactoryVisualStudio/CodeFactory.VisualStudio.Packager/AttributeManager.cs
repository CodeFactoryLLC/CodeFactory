using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio.Packager
{
    /// <summary>
    /// Helper class that helps manage attributes.
    /// </summary>
    internal static class AttributeManager
    {
        /// <summary>
        /// Regex expression to locate the AssemblyCFEnvironment attribute.
        /// </summary>
        public const string RegexFindCFEnvironment = @"\[.*\bAssemblyCFEnvironment\b.*]";

        /// <summary>
        /// Regex expression to locate the AssemblyCFSdkVersion attribute.
        /// </summary>
        public const string RegexFindCFSdkVersion = @"\[.*\bAssemblyCFSdkVersion\b.*]";

        /// <summary>
        /// Regex expression to locate the AssemblyCFSdkVersion attribute.
        /// </summary>
        public const string RegexFindNamespace = @"\busing\b.*\bCodeFactory.VisualStudio\b";
    }
}
