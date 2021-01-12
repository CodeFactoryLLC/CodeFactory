//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// The code factory model types that represent the C# source code type.
    /// </summary>
    public enum CsModelType
    {
        /// <summary>
        /// Model is a class implementation.
        /// </summary>
        Class = DotNetModelType.Class,

        /// <summary>
        /// Model is a interface implementation.
        /// </summary>
        Interface = DotNetModelType.Interface,

        /// <summary>
        /// Model is a structure implementation.
        /// </summary>
        Structure = DotNetModelType.Structure,

        /// <summary>
        /// Model is a attribute implementation.
        /// </summary>
        Attribute = DotNetModelType.Attribute,

        /// <summary>
        /// Model is a attribute parameter implementation.
        /// </summary>
        AttributeParameter = DotNetModelType.AttributeParameter,

        /// <summary>
        /// Model is a namespace definition.
        /// </summary>
        Namespace = DotNetModelType.Namespace,

        /// <summary>
        /// Model is a field definition.
        /// </summary>
        Field = DotNetModelType.Field,

        /// <summary>
        /// Model is a event definition.
        /// </summary>
        Event = DotNetModelType.Event,

        /// <summary>
        /// Model is a property definition.
        /// </summary>
        Property = DotNetModelType.Property,

        /// <summary>
        /// Model is a method definition.
        /// </summary>
        Method = DotNetModelType.Method,

        /// <summary>
        /// Model is a parameter definition.
        /// </summary>
        Parameter = DotNetModelType.Parameter,

        /// <summary>
        /// Model is a type definition.
        /// </summary>
        Type = DotNetModelType.Type,

        /// <summary>
        /// Model is a delegate definition.
        /// </summary>
        Delegate = DotNetModelType.Delegate,

        /// <summary>
        /// Model is a delegate parameter definition.
        /// </summary>
        DelegateParameter = DotNetModelType.DelegateParameter,

        /// <summary>
        /// Model is a delegate parameter value.
        /// </summary>
        DelegateParameterValue = DotNetModelType.DelegateParameterValue,

        /// <summary>
        /// Model is a using statement.
        /// </summary>
        Using = DotNetModelType.NamespaceReference,

        /// <summary>
        /// Model is a generic parameter that belongs to a generic type.
        /// </summary>
        GenericParameter = DotNetModelType.GenericParameter,

        /// <summary>
        /// Model stores a parameter value from an attribute.
        /// </summary>
        AttributeParameterValue = DotNetModelType.AttributeParameterValue,

        /// <summary>
        /// Model that hosts all the source models that have been loaded.
        /// </summary>
        Source = DotNetModelType.Source,

        /// <summary>
        /// Model stores enumeration definition.
        /// </summary>
        Enum = DotNetModelType.Enum,

        /// <summary>
        /// Model that stores a unique value in an enumeration.
        /// </summary>
        EnumValue = DotNetModelType.EnumValue,

        /// <summary>
        /// Model that stores default value information for a parameter.
        /// </summary>
        ParameterDefaultValue = DotNetModelType.ParameterDefaultValue,

        /// <summary>
        /// Model is a tuple type parameter that belongs to a tuple type.
        /// </summary>
        TupleTypeParameter = DotNetModelType.TupleTypeParameter,

        /// <summary>
        /// The model is currently not know by the C# source type.
        /// </summary>
        Unknown = DotNetModelType.Unknown
    }
}
