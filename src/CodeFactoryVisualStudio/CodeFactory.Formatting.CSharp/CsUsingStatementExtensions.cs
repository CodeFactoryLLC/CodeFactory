//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsUsingStatement"/> model.
    /// </summary>
    public static class CsUsingStatementExtensions
    {
        /// <summary>
        /// Extension method that creates a fully formatted using statement.
        /// </summary>
        /// <example>
        /// Format with alias using [alias] = [namespace];
        /// Format without alias  using [namespace];
        /// </example>
        /// <param name="source">The source using statement to use.</param>
        /// <param name="includeAlias">Optional flag that determines if a alias is included to add it to the using statement definition.</param>
        /// <param name="alias">Optional flag that allows you to set a custom alias. If set this will always overrider the <see cref="includeAlias"/> flag and any internal alias assigned to the model.</param>
        /// <returns>Fully formatted using statement, or null if namespace data is missing from the model</returns>
        public static string CSharpFormatUsingStatement(this CsUsingStatement source, bool includeAlias = true, string alias = null)
        {
            var nameSpace = source.ReferenceNamespace;

            if (string.IsNullOrEmpty(nameSpace)) return null;

            var formattedAlias = alias;
            bool useAlias = !string.IsNullOrEmpty(formattedAlias);

            if (!useAlias)
            {
                if (includeAlias & source.HasAlias)
                {
                    formattedAlias = source.Alias;
                    useAlias = true;
                }
            }

            return !useAlias ? $"using {nameSpace};" : $"using {formattedAlias} = {nameSpace};";
        }
    }
}
