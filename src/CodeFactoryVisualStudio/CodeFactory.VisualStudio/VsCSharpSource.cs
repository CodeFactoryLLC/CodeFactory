//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Data model that represents C# source code.
    /// </summary>
    public abstract class VsCSharpSource:VsModel,IVsCSharpSource
    {
        #region Property backing fields
        private readonly CsSource _sourceCode;
        #endregion

        /// <summary>
        /// Constructor for the base class <see cref="VsCSharpSource"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model is loaded.</param>
        /// <param name="hasErrors">Flag that determines if errors occurred while loading the model.</param>
        /// <param name="modelErrors">The list of errors that occurred if any.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="sourceCode">The loaded C# model data.</param>
        protected VsCSharpSource(bool isLoaded, bool hasErrors, 
            IReadOnlyList<ModelException<VisualStudioModelType>> modelErrors, string name, 
            CsSource sourceCode) : base(isLoaded, hasErrors, modelErrors, VisualStudioModelType.CSharpSource, name)
        {
            _sourceCode = sourceCode;
        }

        /// <summary>
        /// The C# source in the document.
        /// </summary>
        public CsSource SourceCode => _sourceCode;

        /// <summary>
        /// Loads the visual studio document model from the current loaded source model.
        /// </summary>
        /// <returns>The loaded document model.</returns>
        public abstract Task<VsDocument> LoadDocumentModelAsync();
    }
}
