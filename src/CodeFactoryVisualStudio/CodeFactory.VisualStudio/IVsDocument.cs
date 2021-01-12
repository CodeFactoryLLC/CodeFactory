//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.SourceCode;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Definition of a document associated with a project in visual studio.
    /// </summary>
    public interface IVsDocument:IVsModel, IParent, IChildren
    {
        /// <summary>
        /// The fully qualified path to the project document. 
        /// </summary>
        string Path { get;}

        /// <summary>
        /// The type of document that is loaded.
        /// </summary>
        VsDocumentType DocumentType { get; }

        /// <summary>
        /// Flag that determines if the project document contains source code that can be managed by code factory.
        /// </summary>
        bool IsSourceCode { get;}

        /// <summary>
        /// The target type of source code that is implemented in the project document. 
        /// </summary>
        SourceCodeType SourceType { get;}



    }
}
