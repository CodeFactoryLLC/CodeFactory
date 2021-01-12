//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Linq;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsType"/> model.
    /// </summary>
    public static class CsTypeExtensions
    {
        /// <summary>
        /// Checks a type definition to see if it inherits a target interface.
        /// </summary>
        /// <param name="source">Type to check for inheritance </param>
        /// <param name="interfaceName">The name of the interface</param>
        /// <param name="interfaceNamespace">Optional parameter that contains the target namespace for the interface.</param>
        /// <returns>True if inherited or false if not.</returns>
        public static bool InheritsInterface(this CsType source, string interfaceName,
            string interfaceNamespace = null)
        {
            if (source == null) return false;
            if (!source.IsLoaded) return false;
            if (!source.IsClass & !source.IsStructure) return false;

            CsContainer containerData = source.IsClass ? source.GetClassModel() as CsContainer
                : source.GetStructureModel() as CsContainer;

            if (containerData == null) return false;
            if (!containerData.IsLoaded) return false;
            if (!containerData.InheritedInterfaces.Any()) return false;

            var interfaceData = interfaceNamespace == null
                ? containerData.InheritedInterfaces.FirstOrDefault(i => interfaceName == i.Name)
                : containerData.InheritedInterfaces.FirstOrDefault(i =>
                    (interfaceNamespace == i.Namespace & interfaceName == i.Name));

            return interfaceData != null;
        }

        /// <summary>
        /// Flag that determines if the type has a base class that is inherited by the type.
        /// </summary>
        /// <param name="source">The target type to check for base class implementation.</param>
        /// <param name="baseClassName">The name of the base class that is inherited.</param>
        /// <param name="baseClassNamespace">Optional parameter for the namespace of the base class.</param>
        /// <returns>True if inherited or false if not found.</returns>
        public static bool InheritsBaseClass(this CsType source, string baseClassName, string baseClassNamespace = null)
        {
            if (source == null) return false;
            if (!source.IsLoaded) return false;
            if (!source.IsClass) return false;
            var classData = source.GetClassModel();

            if (classData == null) return false;

            return classData.InheritsBaseClass(baseClassName, baseClassNamespace);

        }


    }
}
