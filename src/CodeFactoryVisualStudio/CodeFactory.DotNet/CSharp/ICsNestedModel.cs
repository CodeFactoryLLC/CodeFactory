//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Interface that identifies if the implementation of this model is nested within another model.
    /// </summary>
    public interface ICsNestedModel: ICsModel, ICsAttributes,IDotNetNestedModel,IParent
    {
        /// <summary>
        /// Identifies the type of model that has been nested.
        /// </summary>
        new CsNestedType NestedType { get; }
    }
}
