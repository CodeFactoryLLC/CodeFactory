//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.IO;
using System.Linq;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Static helper class that contains functions to support path management with visual studio.
    /// </summary>
    public static class PathHelper
    {
        /// <summary>
        /// Contains array of invalid characters allowed in a path.
        /// </summary>
        private static readonly char[] _invalidPathNameCharacter = Path.GetInvalidPathChars();

        /// <summary>
        /// The invalid characters not allowed in a path name.
        /// </summary>
        public static  string InvalidPathNameCharacters => new string(_invalidPathNameCharacter);

        /// <summary>
        /// Provided file name is checked to determine if it has
        /// </summary>
        /// <param name="path">The path to be evaluated.</param>
        /// <returns>True if invalid characters exists or false if the file does not have invalid characters.</returns>
        public static bool ContainsInvalidPathNameCharacter(string path)
        {
            bool result = false;
            if (string.IsNullOrEmpty(path)) return false;
            foreach (var invalidCharacter in _invalidPathNameCharacter)
            {
                result = path.Contains(invalidCharacter);
                if (result) break;
            }

            return result;
        }
    }
}
