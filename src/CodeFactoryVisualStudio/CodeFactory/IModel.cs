//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Collections.Generic;

namespace CodeFactory
{
    /// <summary>
    /// Base implementation of a code factory model. All models will be derived from this base model definition.
    /// </summary>
    /// <typeparam name="TModelTypes">Enumeration of the model types that this model supports.</typeparam>
    public interface IModel<TModelTypes> where TModelTypes : struct, IComparable, IFormattable, IConvertible

    {
        /// <summary>
        /// Flag that determines if this model was able to load.
        /// </summary>
        bool IsLoaded { get; }

        /// <summary>
        /// Flag that determines if this model has errors.
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// List of all errors that occurred in this model.
        /// </summary>
        IReadOnlyList<ModelException<TModelTypes>> ModelErrors { get; }

        /// <summary>
        /// Determines the type of model that has been loaded.
        /// </summary>
        TModelTypes ModelType { get; }
    }
}
