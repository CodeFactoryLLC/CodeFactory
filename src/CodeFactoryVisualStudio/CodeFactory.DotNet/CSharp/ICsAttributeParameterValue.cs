//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;


namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// The model information for an attributes parameter value for c# implementation.
    /// </summary>
    public interface ICsAttributeParameterValue:ICsModel, IDotNetAttributeParameterValue
    {
        /// <summary>
        /// The type definition of the parameter that was passed. This will be populated if the property ParameterKind is set to 'Type'
        /// </summary>
        new CsType TypeValue { get; }

        /// <summary>
        /// Gets an enumeration of all the parameter values that were assigned to the attribute parameter. This will be populated if the property ParameterKind is set to 'Array'
        /// </summary>
        new IReadOnlyList<CsAttributeParameterValue> Values { get; }
    }
}
