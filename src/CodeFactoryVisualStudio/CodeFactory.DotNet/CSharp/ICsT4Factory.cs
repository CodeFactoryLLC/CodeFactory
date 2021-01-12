//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Definition of the required properties, events, and methods that are required in  c# T4 factory. 
    /// </summary>
    public interface ICsT4Factory
    {
        /// <summary>
        /// C# models to be used by the T4 code factory.
        /// </summary>
        CsModelStore CsModels { get; set; }
    }
}
