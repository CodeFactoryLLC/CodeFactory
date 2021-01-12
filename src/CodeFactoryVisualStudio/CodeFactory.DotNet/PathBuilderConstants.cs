//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
// ReSharper disable InconsistentNaming

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Data constants that are used when building the unique path for a dot net model.
    /// </summary>
    public static class PathBuilderConstants
    {
        
        /// <summary>
        /// Definition of the source entry point that holds all dot net models. 
        /// </summary>
        public const string Source = "//SRC:";

        /// <summary>
        /// Definition  of a namespace path for a dot net model.
        /// </summary>
        public const string Namespace = "/NS:";

        /// <summary>
        /// Reference to a namespace that is used in a dot net model.
        /// </summary>
        public const string NamespaceReference = "/NSREF:";

        /// <summary>
        /// Definition of a attribute model in the path for a dot net model.
        /// </summary>
        public const string Attribute = "/A:";

        /// <summary>
        /// Definition of a class model in the path for a dot net model.
        /// </summary>
        public const string Class = "/C:";

        /// <summary>
        /// Definition of a interface model in the path for a dot net model.
        /// </summary>
        public const string Interface = "/I:";

        /// <summary>
        /// Definition of a structure model in the path for a dot net model.
        /// </summary>
        public const string Structure = "/S:";

        /// <summary>
        /// Definition of a delegate model in the path for a dot net model.
        /// </summary>
        public const string Delegate = "/D:";

        /// <summary>
        /// Definition of a field model in the path for a dot net model.
        /// </summary>
        public const string Field = "/F:";

        /// <summary>
        /// Definition of a property model in the path for a dot net model.
        /// </summary>
        public const string Property = "/P:";

        /// <summary>
        /// Definition of a method model in the path for a dot net model.
        /// </summary>
        public const string Method = "/M:";

        /// <summary>
        /// Definition of a parameter model in the path for a dot net model.
        /// </summary>
        public const string Parameter = "/PARM:";

        /// <summary>
        /// Definition of a parameter model default value in the path for a dot net model.
        /// </summary>
        public const string ParameterDefaultValue = "/PARMDV:";

        /// <summary>
        /// Definition of a event model in the path for a dot net model.
        /// </summary>
        public const string Event = "/E:";

        /// <summary>
        /// Definition of a enumeration model in the path for a dot net model.
        /// </summary>
        public const string Enum = "/EN:";

        /// <summary>
        /// Definition of a enumeration value model in the path for a dot net model.
        /// </summary>
        public const string EnumValue = "/ENV:";



    }
}
