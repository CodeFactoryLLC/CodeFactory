//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio.Loader
{
    /// <summary>
    /// Data class that returns the results from reading from different parts of a Code Factory package.
    /// </summary>
    public class PackageReadResult<T> where T : class
    {
        /// <summary>
        /// Flag that determines if an error has occurred during the reading of a part of a package.
        /// </summary>
        public bool HasError { get; set; }

        /// <summary>
        /// Error message that occurred while reading from the package. This will be null if there is no error.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// The result that was returned from reading the package. This will be null if there was an error.
        /// </summary>
        public T Result { get; set; }
    }

}


