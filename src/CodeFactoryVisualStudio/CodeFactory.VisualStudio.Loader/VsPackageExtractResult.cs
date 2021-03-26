//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;


namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    /// Data class that stores the results of extracting files from a Code Factory package.
    /// </summary>
    public class VsPackageExtractResult
    {
        /// <summary>
        /// Default constructor that initializes the properties.
        /// </summary>
        public VsPackageExtractResult()
        {
            HasErrors = false;
            Errors = new List<string>();
        }

        /// <summary>
        /// Flag that determines if there were errors extracting an of the files from the package.
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// List of the human readable error messaged that occurred. This will be null if HasErrors is false.
        /// </summary>
        public List<string> Errors { get; set; }

    }
}
