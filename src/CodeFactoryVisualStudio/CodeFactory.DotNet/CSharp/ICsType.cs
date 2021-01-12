//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model that defines a type used in a C# model definition.
    /// </summary>
    public interface ICsType:ICsModel,ICsGeneric,IDotNetType
    {
        /// <summary>
        /// List of the types that are implemented in the Tuple. This will an empty list if the type is not a tuple.
        /// </summary>
        new IReadOnlyList<CsTupleTypeParameter> TupleTypes { get; }

        /// <summary>
        ///     Enumeration of the target well known type this type represents.
        /// </summary>
        new CsKnownLanguageType WellKnownType { get; }

        /// <summary>
        /// Loads the full <see cref="ICsEnum"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an enumeration.</returns>
        new CsEnum GetEnumModel();

        /// <summary>
        /// Loads the full <see cref="ICsDelegate"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a delegate.</returns>
        new CsDelegate GetDelegateModel();

        /// <summary>
        /// Loads the full <see cref="ICsClass"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a class.</returns>
        new CsClass GetClassModel();

        /// <summary>
        /// Loads the full <see cref="ICsInterface"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not an interface.</returns>
        new CsInterface GetInterfaceModel();

        /// <summary>
        /// Loads the full <see cref="ICsStructure"/> model from the type definition.
        /// </summary>
        /// <returns>Return the fully loaded model or an empty model if the type is not a structure.</returns>
        new CsStructure GetStructureModel();
    }
}
