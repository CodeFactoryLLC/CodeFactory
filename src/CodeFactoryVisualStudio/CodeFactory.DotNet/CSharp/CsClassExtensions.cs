//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="CsClass"/> model.
    /// </summary>
    public static class CsClassExtensions
    {

        /// <summary>
        /// Extension method that determines if a target class inherits a target base class.
        /// </summary>
        /// <param name="source">The source class to check for inheritance.</param>
        /// <param name="name">The name of the inherited class</param>
        /// <param name="nameSpace">Optional parameter for the namespace of the inherited class.</param>
        /// <returns>True if the class is inherited or false if not.</returns>
        public static bool InheritsBaseClass(this CsClass source, string name, string nameSpace = null)
        {
            if (source == null) return false;
            if (!source.IsLoaded) return false;
            if (string.IsNullOrEmpty(name)) return false;

            var baseClass = source.BaseClass;

            if (baseClass == null) return false;

            bool result = nameSpace == null
                ? baseClass.Name == name
                : (baseClass.Namespace == nameSpace & baseClass.Name == name);

            if (!result & baseClass.BaseClass != null) result = baseClass.InheritsBaseClass(name, nameSpace);

            return result;
        }
    }
}
