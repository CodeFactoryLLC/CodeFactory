//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.DotNet.CSharp;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Visual studio model that loads the source from a C# document.
    /// </summary>
    public interface IVsCSharpSource:IVsModel
    {
        /// <summary>
        /// The C# source in the document.
        /// </summary>
        CsSource SourceCode { get; }

    }
}
