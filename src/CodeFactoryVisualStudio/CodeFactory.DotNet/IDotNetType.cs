//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model that defines a .net type.
    /// </summary>
    public interface IDotNetType:IDotNetModel,IDotNetGeneric
    {
        /// <summary>
        ///     The name of the type.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     The namespace the type belongs to.
        /// </summary>
        string Namespace { get; }

        /// <summary>
        ///     Flag that determines if the type is one of the well know data types of the language.
        /// </summary>
        bool IsWellKnownType { get; }

        /// <summary>
        ///     Enumeration of the target well known type this type represents.
        /// </summary>
        WellKnownLanguageType WellKnownType { get; }

        /// <summary>
        /// The default value for well known value data types. This will be null if the value is not a well known value type.
        /// </summary>
        string ValueTypeDefaultValue { get; }

        /// <summary>
        ///     Flag that determines if the type is a value type.
        /// </summary>
        bool IsValueType { get; }

        /// <summary>
        ///     Flag that determines if the type supports the interface <see cref="IDisposable"/>.
        /// </summary>
        bool SupportsDisposable { get; }

        /// <summary>
        ///     Flag that determines if the type is an interface.
        /// </summary>
        bool IsInterface { get; }

        /// <summary>
        /// Flag that determines if the type is a structure.
        /// </summary>
        bool IsStructure { get; }

        /// <summary>
        /// Flag that determines if the type is a class.
        /// </summary>
        bool IsClass { get; }

        /// <summary>
        ///     Flag that determines if the type is an array of the target type.
        /// </summary>
        bool IsArray { get; }

        /// <summary>
        /// Gets a list of the dimensions that are assigned to the array. This will contain more then one value if the array is a jagged array. This will be empty if the type is not an array.
        /// </summary>
        IReadOnlyList<int> ArrayDimensions { get; }

        /// <summary>
        /// Flag that determines if the type is a generic place holder definition.
        /// </summary>
        bool IsGenericPlaceHolder { get; }

        /// <summary>
        /// Flag that determines if the type is a enumeration.
        /// </summary>
        bool IsEnum { get; }

        /// <summary>
        /// Flag that determines if the type is a delegate.
        /// </summary>
        bool IsDelegate { get; }

        /// <summary>
        /// Flag that determine if the type is a Tuple
        /// </summary>
        bool IsTuple { get; }

        /// <summary>
        /// List of the types that are implemented in the Tuple. This will an empty list if the type is not a tuple.
        /// </summary>
        IReadOnlyList<IDotNetTupleTypeParameter> TupleTypes { get; }

        /// <summary>
        /// Loads the full <see cref="IDotNetEnum"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an enumeration.</returns>
        IDotNetEnum GetEnumModel();

        /// <summary>
        /// Loads the full <see cref="IDotNetDelegate"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a delegate.</returns>
        IDotNetDelegate GetDelegateModel();

        /// <summary>
        /// Loads the full <see cref="IDotNetClass"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a class.</returns>
        IDotNetClass GetClassModel();

        /// <summary>
        /// Loads the full <see cref="IDotNetInterface"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an interface.</returns>
        IDotNetInterface GetInterfaceModel();

        /// <summary>
        /// Loads the full <see cref="IDotNetStructure"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a structure.</returns>
        IDotNetStructure GetStructureModel();

    }
}
