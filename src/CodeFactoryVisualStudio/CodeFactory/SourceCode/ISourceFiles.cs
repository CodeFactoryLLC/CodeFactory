//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;

namespace CodeFactory.SourceCode
{
    /// <summary>
    /// Interface that stores where target source code originated from.
    /// </summary>
    public interface ISourceFiles
    {
        /// <summary>
        /// The source file or files in which the model was loaded from. This will be an empty enumeration if the source models were loaded from metadata only.
        /// </summary>
        IReadOnlyList<string> SourceFiles { get; }
    }
}
