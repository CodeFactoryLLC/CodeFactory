//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Definition of a visual studio project reference model information.
    /// </summary>
    public interface IVsReference:IVsModel
    {

        /// <summary>
        ///     The fully qualified path to the source reference.
        /// </summary>
        string FilePath { get; }

        /// <summary>
        /// Flag that determines if the reference has aliases. 
        /// </summary>
        bool HasAliases { get; }

        /// <summary>
        /// Readonly list of the aliases assigned to this reference.
        /// </summary>
        IReadOnlyList<string> Aliases { get; }

        /// <summary>
        /// The type of the project reference.
        /// </summary>
        ProjectReferenceType Type { get; }


    }
}
