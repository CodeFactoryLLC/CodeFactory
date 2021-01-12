//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.IO;
using System.Linq;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Static helper class that contains functions to support file management with visual studio.
    /// </summary>
    public static class FileHelper
    {
        /// <summary>
        /// Contains array of invalid characters allowed in a file.
        /// </summary>
        private static readonly char[] _invalidFileNameCharacter = Path.GetInvalidFileNameChars();
        

        /// <summary>
        /// The invalid characters not allowed in a file name.
        /// </summary>
        public static  string InvalidFileNameCharacters => new string(_invalidFileNameCharacter);

        /// <summary>
        /// Provided file name is checked to determine if it has
        /// </summary>
        /// <param name="fileName">The filename to be evaluated.</param>
        /// <returns>True if invalid characters exists or false if the file does not have invalid characters.</returns>
        public static bool ContainsInvalidFileNameCharacter(string fileName)
        {
            bool result = false;
            if (string.IsNullOrEmpty(fileName)) return false;
            foreach (var invalidCharacter in _invalidFileNameCharacter)
            {
                result = fileName.Contains(invalidCharacter);
                if (result) break;
            }

            return result;
        }
    }
}
