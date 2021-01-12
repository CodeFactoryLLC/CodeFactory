//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// The model information for a attribute used for a c# implementation.
    /// </summary>
    public interface ICsAttributeParameter:ICsModel,IDotNetAttributeParameter
    {
        /// <summary>
        ///     The value that was assigned to the parameter.
        /// </summary>
        new CsAttributeParameterValue Value { get; }
    }
}
