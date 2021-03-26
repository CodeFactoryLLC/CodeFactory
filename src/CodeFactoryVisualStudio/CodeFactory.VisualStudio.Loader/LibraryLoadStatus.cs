//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    /// Data class that tracks if the code factory libraries were loaded into memory correctly.
    /// </summary>
    public class LibraryLoadStatus
    {
        /// <summary>
        /// Default constructor that initializes the properties.
        /// </summary>
        public LibraryLoadStatus()
        {
            HasErrors = false;

            Errors = new List<string>();
        }

        /// <summary>
        /// Flag that determines if errors occurred while loading libraries.
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// List of end user formatted errors. 
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
