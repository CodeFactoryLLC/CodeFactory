//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model storage class used to store c# code factory models, to be used to pass data to factories.
    /// </summary>
    public class CsModelStore
    {
        #region backing fields for the model data
        private ICsModel _model;
        private readonly Dictionary<string, IEnumerable<ICsModel>> _models;
        #endregion

        /// <summary>
        /// Sets the single model to be shared with a factory.
        /// </summary>
        /// <param name="model">Target model to be used in a factory.</param>
        public void SetModel(ICsModel model)
        {
            _model = model;
        }

        /// <summary>
        /// Adds many C# models to the store by category.
        /// </summary>
        /// <param name="category">Name used to keep track of the models that are stored together.</param>
        /// <param name="models">The models stored by the target category.</param>
        public void AddModels(string category, IEnumerable<ICsModel> models)
        {
            if (_models.ContainsKey(category))
            {
                _models.Remove(category);                
            }
            _models.Add(category, models);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CsModelStore"/> and initializes the store for data to be added.
        /// </summary>
        public CsModelStore()
        {
            _model = null;
            _models = new Dictionary<string, IEnumerable<ICsModel>>();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CsModelStore"/> and sets a single model in the store.
        /// </summary>
        /// <param name="model">The model to be added to the store.</param>
        public CsModelStore(ICsModel model)
        {
            _model = model;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="CsModelStore"/> and loads all the data for all the categories.
        /// </summary>
        /// <param name="allModels">All the model data to be added to the store.</param>
        public CsModelStore(Dictionary<string, IEnumerable<ICsModel>> allModels)
        {
            _model = null;
            _models = allModels ?? new Dictionary<string, IEnumerable<ICsModel>>();
        }

        /// <summary>
        /// The single <see cref="ICsModel"/> that is provided for the T4 Template.
        /// </summary>
        public ICsModel Model => _model;

        /// <summary>
        /// Gets the models from a target category.
        /// </summary>
        /// <param name="category">Category to get models for.</param>
        /// <returns>Returns a enumeration of the models. If no models were found then an empty enumeration is returned.</returns>
        public IEnumerable<ICsModel> Models(string category)
        {
            if (string.IsNullOrEmpty(category)) return new List<ICsModel>();

            var getModels = _models.TryGetValue(category, out var models);

            return getModels ? models : new List<ICsModel>();
        }
    }
}
