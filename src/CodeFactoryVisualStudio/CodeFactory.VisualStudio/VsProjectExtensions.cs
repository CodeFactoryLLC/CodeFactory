//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Linq;
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="VsProject"/> model.
    /// </summary>
    public static class VsProjectExtensions
    {
        /// <summary>
        /// Extension method that determines if a project reference has been loaded.
        /// </summary>
        /// <param name="source">Source project to search</param>
        /// <param name="libraryName">The full name of the library to confirm exists.</param>
        /// <returns>boolean flag to determine if the library was found.</returns>
        public static async Task<bool> HasReferenceLibraryAsync(this VsProject source, string libraryName)
        {
            if (source == null) return false;
            if (string.IsNullOrEmpty(libraryName)) return false;

            var references = await source.GetProjectReferencesAsync();

            return references.Any(r => r.Name == libraryName);
        }
    }
}
