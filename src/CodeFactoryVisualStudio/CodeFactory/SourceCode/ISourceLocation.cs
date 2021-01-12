//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.Document;

namespace CodeFactory.SourceCode
{
    /// <summary>
    /// Notes the location in a source document where the model starts and ends in definition. 
    /// </summary>
    public interface ISourceLocation
    {
        /// <summary>
        /// The starting location for the definition of the source.
        /// </summary>
        DocumentLocation StartLocation { get; }

        /// <summary>
        /// The ending location for the definition of the source.
        /// </summary>
        DocumentLocation EndLocation { get; }
    }
}
