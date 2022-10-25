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

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Manual data model class that captures a target namespace and potentinally alias. Will throw exceptions if any of the methods are called.
    /// </summary>
    public class CsManualUsingStatement : ICsUsingStatement
    {
        //property backing fields.
        private readonly string _referenceNamspace;
        private readonly string _alais;

        /// <summary>
        /// Creates a instance of <see cref="CsManualUsingStatement"/>
        /// </summary>
        /// <param name="nameSpace">Target namespace that is called in the using statement.</param>
        /// <param name="alais">Optional the alais assigned to the referenced namespace.</param>
        public CsManualUsingStatement(string nameSpace, string alais = null)
        { 
            _referenceNamspace = nameSpace;
            _alais = alais;
        }
        public string ReferenceNamespace => _referenceNamspace;

        public bool HasAlias => !string.IsNullOrEmpty(_alais);

        public string Alias => _alais;

        public string LookupPath => null;

        public CsModelType ModelType =>  CsModelType.Using;

        public bool LoadedFromSource => false;

        public SourceCodeType Language => SourceCodeType.CSharp;

        public string SourceDocument => null;

        public bool IsLoaded => true;

        public bool HasErrors => false;

        public CsModel Parent => null;

        DotNetModelType IDotNetModel.ModelType => DotNetModelType.NamespaceReference;

        IDotNetModel DotNet.IParent.Parent => null;

        public Task<CsSource> AddAfterAsync(string sourceDocument, string sourceCode)
        {
            throw new NotImplementedException();
        }

        public Task<CsSource> AddAfterAsync(string sourceCode)
        {
            throw new NotImplementedException();
        }

        public Task<CsSource> AddBeforeAsync(string sourceDocument, string sourceCode)
        {
            throw new NotImplementedException();
        }

        public Task<CsSource> AddBeforeAsync(string sourceCode)
        {
            throw new NotImplementedException();
        }

        public Task<CsSource> DeleteAsync(string sourceDocument)
        {
            throw new NotImplementedException();
        }

        public Task<CsSource> DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<ModelLoadException> GetErrors()
        {
            throw new NotImplementedException();
        }

        public CsModel GetModel(string lookupPath)
        {
            throw new NotImplementedException();
        }

        public Task<ISourceLocation> GetSourceLocationAsync(string sourceDocument)
        {
            throw new NotImplementedException();
        }

        public Task<ISourceLocation> GetSourceLocationAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CsSource> ReplaceAsync(string sourceDocument, string sourceCode)
        {
            throw new NotImplementedException();
        }

        public Task<CsSource> ReplaceAsync(string sourceCode)
        {
            throw new NotImplementedException();
        }

        T ICsModel.GetModel<T>(string lookupPath)
        {
            throw new NotImplementedException();
        }
    }
}
