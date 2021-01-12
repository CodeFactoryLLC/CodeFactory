//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp.FormattedSyntax
{
    /// <summary>
    /// Syntax formatting for common keywords that are contextual in nature and not reserved words in the C# language. They will belong to one or more target libraries. 
    /// </summary>
    public  static class CommonContextualKeywords
    {
        /// <summary>
        /// Keyword to defining a custom event accessor.
        /// </summary>
        public const string Add = "add";

        /// <summary>
        /// Keyword to assign an alias name to reference types in a target assembly.
        /// </summary>
        public const string Alias = "alias";

        /// <summary>
        /// Keyword to denote an ascending sort order from smallest to largest in an order by clause in a LINQ expression.
        /// </summary>
        public const string Ascending = "ascending";

        /// <summary>
        /// Keyword that denotes the method is implemented as an async operation and is always paired with one or more await keywords.
        /// </summary>
        public const string Async = "async";

        /// <summary>
        /// Keyword that denotes an async operation is executing and waiting for the result of the operation. Always used with one Async keyword decloration.
        /// </summary>
        public const string Await = "await";

        /// <summary>
        /// Keyword that is used in a grouping clause how the returned items should be grouped. This is used in LINQ syntax.
        /// </summary>
        public const string By = "by";

        /// <summary>
        /// Keyword to denote an descending sort order from largest to smallest in an order by clause in a LINQ expression.
        /// </summary>
        public const string Descending = "descending";

        /// <summary>
        /// Keyword that is used by variables that skips compile time checking.
        /// </summary>
        public const string Dynamic = "dynamic";

        /// <summary>
        /// Keyword that is used in join clauses to denotes the two target values are equal. This is used in LINQ expressions.
        /// </summary>
        public const string KeywordEquals = "equals";

        /// <summary>
        /// Keyword that denotes the source of a an expression. This is used in LINQ expressions.
        /// </summary>
        public const string From = "from";

        /// <summary>
        /// Keyword that defines an accessor method for properties or indexers.
        /// </summary>
        public const string Get = "get";

        /// <summary>
        /// Keyword that denotes a global scope namespace.
        /// </summary>
        public const string Global = "global";

        /// <summary>
        /// Keyword that defines a grouping operation in a LINQ expression.
        /// </summary>
        public const string Group = "group";

        /// <summary>
        /// Keyword that creates a temporary named identifier for the results of a group, join or select clause in a LINQ expression.
        /// </summary>
        public const string Into = "into";

        /// <summary>
        /// Keyword that defines the start of a join operation in a LINQ expression.
        /// </summary>
        public const string Join = "join";

        /// <summary>
        /// Keyword that stores the results of a sub expression used in LINQ expressions.
        /// </summary>
        public const string Let = "let";

        /// <summary>
        /// Keyword operation that gets the name of the variable, type, or member.
        /// </summary>
        public const string NameOf = "nameof";

        /// <summary>
        /// Keyword using in join operations used to specify a join condition. This is used in LINQ expressions.
        /// </summary>
        public const string On = "on";

        /// <summary>
        /// Keyword used to set the return order definition from a LINQ expression.
        /// </summary>
        public const string OrderBy = "orderby";

        /// <summary>
        /// Keyword that defines that a class or method definition will be split across at least two code files. 
        /// </summary>
        public const string Partial = "partial";

        /// <summary>
        /// Keyword that defines an event accessor method that removes a subscription from a target event.
        /// </summary>
        public const string Remove = "remove";

        /// <summary>
        /// Keyword that defines the collection of data, used in LINQ expressions.
        /// </summary>
        public const string Select = "select";

        /// <summary>
        /// Keyword that defines an accessor method for properties and indexers.
        /// </summary>
        public const string Set = "set";

        /// <summary>
        /// Keyword that denotes the value that has been passed to a set accessor.
        /// </summary>
        public const string Value = "value";

        /// <summary>
        /// Keyword that defines a local variable used within the scope of a method body.
        /// </summary>
        public const string Var = "var";

        /// <summary>
        /// Keyword that is used a validation condition in switch statements. (Note: Available in C# 7.0 and later). Also used as a validation condition with catch statements. (Note: Available in C# 6.0 and later).
        /// </summary>
        public const string When = "when";

        /// <summary>
        /// Keyword used to start the definition of constraining condition on a generic type. Also used a evaluation to determine what data will be returned from a LINQ expression.
        /// </summary>
        public const string Where = "where";

        /// <summary>
        /// Keyword used to denote in an iterator. Used with return and break statements.
        /// </summary>
        public const string Yield = "yield";

    }

}
