//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp.FormattedSyntax
{
    /// <summary>
    /// Data class that provides the syntax to common symbols used in the definition of C# source code.
    /// </summary>
    public static class Symbols
    {
        /// <summary>
        /// Symbol that starts the definition of a generic.
        /// </summary>
        public const string GenericDefinitionStart = "<";

        /// <summary>
        /// Symbol that ends the definition of a generic.
        /// </summary>
        public const string GenericDefinitionEnd = ">";

        /// <summary>
        /// Symbol that starts the definition of a parameters section.
        /// </summary>
        public const string ParametersDefinitionStart = "(";

        /// <summary>
        /// Symbol that ends the definition of a parameters section.
        /// </summary>
        public const string ParametersDefinitionEnd = ")";

        /// <summary>
        /// Symbol that starts the definition of an array.
        /// </summary>
        public const string ArrayDefinitionStart = "[";

        /// <summary>
        /// Symbol that ends the definition of an array.
        /// </summary>
        public const string ArrayDefinitionEnd = "]";

        /// <summary>
        /// Symbol that starts the definition for multiple C# statements to be executed.
        /// </summary>
        public const string MultipleStatementStart = "{";

        /// <summary>
        /// Symbol that ends the definition of multiple C# statements to be executed. 
        /// </summary>
        public const string MultipleStatementEnd = "}";

        /// <summary>
        /// Symbol that denotes the end of a C# code statement.
        /// </summary>
        public const string EndOfStatement = ";";


    }
}
