//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory
{
    /// <summary>
    /// Status information about a code factory model that has been created.
    /// </summary>
    public interface IModelStatus
    {
        /// <summary>
        /// Flag that determines if this model was able to load.
        /// </summary>
        bool IsLoaded { get; }

        /// <summary>
        /// Flag that determines if this model or one of the children of this model has an error.
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// Gets the <see cref="ModelLoadException"/> from the current model and all child models of this model.
        /// </summary>
        /// <returns>Returns a <see cref="IReadOnlyList{T}"/> of the <see cref="ModelLoadException"/> exceptions or an empty list if no exceptions exist.</returns>
        IReadOnlyList<ModelLoadException> GetErrors();
    }
}
