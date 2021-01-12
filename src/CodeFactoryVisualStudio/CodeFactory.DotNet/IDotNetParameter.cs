//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    ///     The definition of a parameter used in .Net.
    /// </summary>
    public interface IDotNetParameter:IDotNetModel,IDotNetAttributes,IParent,ILookup
    {
        /// <summary>
        ///     The name of the parameter.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The data type assigned to the parameter.
        /// </summary>
        IDotNetType ParameterType { get; }

        /// <summary>
        ///     Flag that determines if the parameter is assigned the out keyword.
        /// </summary>
        bool IsOut { get; }

        /// <summary>
        ///     Flag that determines if the parameter is assigned the ref keyword.
        /// </summary>
        bool IsRef { get; }

        /// <summary>
        ///     Flag that determines if the parameter is an parameter array.
        /// </summary>
        bool IsParams { get; }

        /// <summary>
        ///     Flag that determines if the parameter is optional.
        /// </summary>
        bool IsOptional { get; }

        /// <summary>
        ///     Flag that determines if the parameter is a generic place holder.
        /// </summary>
        bool IsGenericParameter { get; }

        /// <summary>
        ///     Flag that determines if the parameter has a default value.
        /// </summary>
        bool HasDefaultValue { get; }

        /// <summary>
        ///     The default value assigned to the parameter. This will be null if the HasDefaultValue property is set to false.
        /// </summary>
        IDotNetParameterDefaultValue DefaultValue { get; }
    }
}
