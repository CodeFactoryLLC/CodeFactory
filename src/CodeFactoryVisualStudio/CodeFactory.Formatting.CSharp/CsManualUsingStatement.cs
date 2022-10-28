//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.DotNet;
using CodeFactory.DotNet.CSharp;
using CodeFactory.SourceCode;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeFactory.Document;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Manual data model class that captures a target namespace and potential alias. Will throw exceptions if any of the methods are called.
    /// </summary>
    public class CsManualUsingStatement : ICsUsingStatement
    {
        //property backing fields.
        private readonly string _referenceNamespace;
        private readonly string _alias;

        /// <summary>
        /// Creates a instance of <see cref="CsManualUsingStatement"/>
        /// </summary>
        /// <param name="nameSpace">Target namespace that is called in the using statement.</param>
        /// <param name="alais">Optional the alais assigned to the referenced namespace.</param>
        public CsManualUsingStatement(string nameSpace, string alais = null)
        { 
            _referenceNamespace = nameSpace;
            _alias = alais;
        }


        /// <summary>
        /// The target namespace that is being imported into the sources scope.
        /// </summary>
        public string ReferenceNamespace => _referenceNamespace;


        /// <summary>
        /// Flag that determines if the namespace reference has an alias.
        /// </summary>
        public bool HasAlias => !string.IsNullOrEmpty(_alias);


        /// <summary>
        /// The alias assigned to the namespace being imported. This will be null if the <see cref="IDotNetNamespaceReference.HasAlias"/> is false. 
        /// </summary>
        public string Alias => _alias;

        /// <summary>
        /// The fully qualified path for this model that can be used when searching the source for the model. This will not be populated on the manual model.
        /// </summary>
        public string LookupPath => null;

        /// <inheritdoc />
        public CsModelType ModelType =>  CsModelType.Using;


        /// <summary>
        /// Flag that determines if this model was loaded from source code or was loaded through reflects or symbol libraries. This will always be false since its a manual model.
        /// </summary>
        public bool LoadedFromSource => false;

        /// <inheritdoc />
        public SourceCodeType Language => SourceCodeType.CSharp;

        /// <summary>
        /// The fully qualified path to the document that was used to load the model from source. This will not be populated on the manual model.
        /// </summary>
        public string SourceDocument => null;


        /// <summary>
        /// Flag that determines if this model was able to load.
        /// </summary>
        public bool IsLoaded => true;

        /// <summary>
        /// Flag that determines if this model or one of the children of this model has an error.
        /// </summary>
        public bool HasErrors => false;

        /// <summary>
        /// The parent to the current model. This will return null since it is a manual model.
        /// </summary>
        public CsModel Parent => null;


        /// <summary>
        /// The type of dot net model that was loaded.
        /// </summary>
        DotNetModelType IDotNetModel.ModelType => DotNetModelType.NamespaceReference;

        /// <summary>
        /// The parent to the current model. This will be null since this is manual model. 
        /// </summary>
        IDotNetModel DotNet.IParent.Parent => null;

        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Adds the source code directly after the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> AddAfterAsync(string sourceCode)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the source code directly before the definition of the <see cref="ICsUsingStatement"/> in the target document.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> AddBeforeAsync(string sourceCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the definition of the using statement from the source document. 
        /// </summary>
        /// <param name="sourceDocument">The source document that the using statement is to be removed from.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the using statement has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> DeleteAsync(string sourceDocument)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the definition of the using statement from the source document. 
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the using statement has been removed from the document.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="ModelLoadException"/> from the current model and all child models of this model.
        /// </summary>
        /// <returns>Returns a <see cref="IReadOnlyList{T}"/> of the <see cref="ModelLoadException"/> exceptions or an empty list if no exceptions exist.</returns>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public IReadOnlyList<ModelLoadException> GetErrors()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Searchs for an existing C# model that has been loaded with the load of the source code.
        /// </summary>
        /// <param name="lookupPath">The lookup path that is assigned to a loaded model.</param>
        /// <returns>Returns the model as the base <see cref="CsModel"/> type. </returns>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public CsModel GetModel(string lookupPath)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the starting and ending locations within the document where the using statement is located.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the document that has the using statement defined in.</param>
        /// <returns>The source location for the using statement.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the starting and ending locations within the document where the using statement is located.
        /// </summary>
        /// <returns>The source location for the using statement.</returns>
        /// <exception cref="DocumentException">Raised when an error occurs getting the location from the document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<ISourceLocation> GetSourceLocationAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replaces the current using statement with the provided source code.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replaces the current using statement with the provided source code.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        public Task<CsSource> ReplaceAsync(string sourceCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Searchs for an existing C# model that has been loaded with the load of the source code.
        /// </summary>
        /// <typeparam name="T">The target <see cref="CsModel"/> type to cast to before returning. </typeparam>
        /// <param name="lookupPath">The lookup path that is assigned to a loaded model.</param>
        /// <returns>Returns the model as the identified type it will either return the instance or null if it is not found or not the correct type.</returns>
        /// <remarks>This will always throw a <see cref="NotImplementedException"/> since it is a manual model.</remarks>
        T ICsModel.GetModel<T>(string lookupPath)
        {
            throw new NotImplementedException();
        }
    }
}
