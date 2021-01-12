//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Concurrent;

namespace CodeFactory
{
    /// <summary>
    /// Stores code factory models so they can be extracted when needed.
    /// </summary>
    /// <typeparam name="T">The type of model that is being stored.</typeparam>
    public class ModelStore<T> where T:class
    {

        /// <summary>
        /// Dictionary that stores the model content for code factory.
        /// </summary>
        private readonly ConcurrentDictionary<string,T> _modelStore;

        /// <summary>
        /// Initialization of the model store
        /// </summary>
        public ModelStore()
        { 
            _modelStore = new ConcurrentDictionary<string, T>();
        }

        /// <summary>
        /// Gets a target model from the store.
        /// </summary>
        /// <param name="index">Index number of the model to load.</param>
        /// <returns>The stored model or null if the model could not be returned.</returns>
        /// <remarks>Thread safe operation.</remarks>
        public T GetModel(string index)
        {
            var hasModel = _modelStore.TryGetValue(index, out var result);

            return !hasModel ? null : result;
        }

        /// <summary>
        /// Adds a model to the model store.
        /// </summary>
        /// <param name="index">The unique index for the model.</param>
        /// <param name="model">The model to be added to the store. The model cannot be null otherwise it will not be added.</param>
        public void AddModel(string index, T model)
        {
            if (model == null) return;

            _modelStore.AddOrUpdate(index, model, (key, oldValue) => model);
        
        }


    }
}
