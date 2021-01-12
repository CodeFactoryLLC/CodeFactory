//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    ///     The definition of a parameter used in C#.
    /// </summary>
    public interface ICsParameter:ICsModel,ICsAttributes,IDotNetParameter,IParent
    {
        /// <summary>
        ///     The data type assigned to the parameter.
        /// </summary>
        new CsType ParameterType { get; }

        /// <summary>
        ///     The default value assigned to the parameter. This will be null if the HasDefaultValue property is set to false.
        /// </summary>
        new CsParameterDefaultValue DefaultValue { get; }
    }
}
