//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory.DotNet.CSharp.FormattedSyntax
{
    /// <summary>
    /// Data class that contains the C# formatted syntax for keywords. 
    /// </summary>
    public static class Keywords
    {
        /// <summary>
        /// Keyword for an abstraction
        /// </summary>
        public const string Abstract = "abstract";

        /// <summary>
        /// Keyword for type conversion using an 'as' statement
        /// </summary>
        public const string As = "as";

        /// <summary>
        /// Keyword for usage of the base keyword used with constructors
        /// </summary>
        public const string Base = "base";

        /// <summary>
        /// Keyword for exiting a running loop.
        /// </summary>
        public const string Break = "break";

        /// <summary>
        /// Keyword for a particular item to be evaluated in a switch statement.
        /// </summary>
        public const string Case = "case";

        /// <summary>
        /// Keyword that captures an exception used with a try statement.
        /// </summary>
        public const string Catch = "catch";

        /// <summary>
        /// Keyword to check math operations are within bounds of the target type.
        /// </summary>
        public const string Checked = "checked";

        /// <summary>
        /// Keyword that defines a class.
        /// </summary>
        public const string Class = "class";

        /// <summary>
        /// Keyword that denotes the field is a constant value.
        /// </summary>
        public const string Constant = "const";

        /// <summary>
        /// Keyword that manages control flow in a loop and tell the control to continue operation at the beginning of the loop.
        /// </summary>
        public const string Continue = "continue";

        /// <summary>
        /// Keyword to denote the default label in a switch statement, also used to return the default value of a type.
        /// </summary>
        public const string Default = "default";

        /// <summary>
        /// Keyword to know the definition of a delegate method.
        /// </summary>
        public const string Delegate = "delegate";

        /// <summary>
        /// Keyword to define an expression check to be true in order for the loop to continue execution.
        /// </summary>
        public const string Do = "do";

        /// <summary>
        /// Keyword to cause execution of an alternate set of logic when an if statement is not true.
        /// </summary>
        public const string Else = "else";

        /// <summary>
        /// Keyword to begin the definition of an enumeration type.
        /// </summary>
        public const string Enum = "enum";

        /// <summary>
        /// Keyword to begin the definition of an event.
        /// </summary>
        public const string Event = "event";

        /// <summary>
        /// Keyword that denotes a data conversion that can throw an error or lose information.
        /// </summary>
        public const string Explicit = "explicit";

        /// <summary>
        /// Keyword used to declare a method that is implemented in an externally accessed library. (Used with DLL imports)
        /// </summary>
        public const string Extern = "extern";

        /// <summary>
        /// Keyword that notes a false statement for a <see cref="Boolean"/> data type.
        /// </summary>
        public const string False = "false";

        /// <summary>
        /// Keyword to force the execution of statement after try and catch blocks have executed.
        /// </summary>
        public const string Finally = "finally";

        /// <summary>
        /// Keyword to keep the garbage collector from moving a variable. Generally used with external api and unmanaged calls.
        /// </summary>
        public const string Fixed = "fixed";

        /// <summary>
        /// Keyword to define a for loop.
        /// </summary>
        public const string For = "for";

        /// <summary>
        /// Keyword to define a for each loop.
        /// </summary>
        public const string ForEach = "foreach";

        /// <summary>
        /// Keyword that informs where the logic execution will move to.
        /// </summary>
        public const string Goto = "goto";

        /// <summary>
        /// Keyword that starts an evaluation to determine if a statement is true.
        /// </summary>
        public const string If = "if";

        /// <summary>
        /// Keyword used to declare a data conversion that is safe and will not throw an error or lose data.
        /// </summary>
        public const string Implicit = "implicit";

        /// <summary>
        /// Keyword used in 4 cases, generic type parameters , a parameter modifer to pass arguments, define the target value in for each statements, usage in from clauses, and in join clauses.
        /// </summary>
        public const string In = "in";

        /// <summary>
        /// Keyword that starts the definition of a interface type.
        /// </summary>
        public const string Interface = "interface";

        /// <summary>
        /// Keyword that checks if an expression is compatible with a target type.
        /// </summary>
        public const string Is = "is";

        /// <summary>
        /// Keyword that starts the execution of code that can be accessed by one thread at a time.
        /// </summary>
        public const string Lock = "lock";

        /// <summary>
        /// Keyword that defines the namespace the following code definitions belong to.
        /// </summary>
        public const string Namespace = "namespace";

        /// <summary>
        /// Keyword that defines the new instance of a data type.
        /// </summary>
        public const string New = "new";

        /// <summary>
        /// Keyword that defines a reference type does not exist and has no memory reference.
        /// </summary>
        public const string Null = "null";

        /// <summary>
        /// Keyword that starts a custom definition of operation for the target type.
        /// </summary>
        public const string Operator = "operator";

        /// <summary>
        /// Keyword that signals that a passed parameter will receive an output of data. Also used with generic definitions to note the type parameter is covariant.
        /// </summary>
        public const string Out = "out";

        /// <summary>
        /// Keyword that signals that an extension or modification of methods, properties, indexers, or events. 
        /// </summary>
        public const string Override = "override";

        /// <summary>
        /// Keyword that signals that a method parameter will be taking on a variable number of additional arguments of the target type.
        /// </summary>
        public const string Params = "params";

        /// <summary>
        /// Keyword that notes a field cannot be changed once the constructor has run.
        /// </summary>
        public const string Readonly = "readonly";

        /// <summary>
        /// Keyword to note the value was passed by reference.
        /// </summary>
        public const string Ref = "ref";

        /// <summary>
        /// Keyword to return a target set of data from the executing method body.
        /// </summary>
        public const string Return = "return";

        /// <summary>
        /// Keyword to lock the definition from being inherited by other classes.
        /// </summary>
        public const string Sealed = "sealed";

        /// <summary>
        /// Keyword operator that returns the number of bytes occupied by the variable.
        /// </summary>
        public const string SizeOf = "sizeof";

        /// <summary>
        /// Keyword allocates memory during execution of a method and removes at the end of the execution of the method. Allocated directly from the stack.
        /// </summary>
        public const string StackAlloc = "stackalloc";

        /// <summary>
        /// Keyword that declares a static member that belongs to the type and not to an instance of the type.
        /// </summary>
        public const string Static = "static";

        /// <summary>
        /// Keyword that declares the creation of a structure.
        /// </summary>
        public const string Structure = "struct";

        /// <summary>
        /// Keyword that declares a switch statement.
        /// </summary>
        public const string Switch = "switch";

        /// <summary>
        /// Keyword that references the current instance of the hosting class.
        /// </summary>
        public const string This = "this";

        /// <summary>
        /// Keyword that raises an instance of a target exception.
        /// </summary>
        public const string Throw = "throw";

        /// <summary>
        /// Keyword that is a true condition in a <see cref="System.Boolean"/> data type.
        /// </summary>
        public const string True = "true";

        /// <summary>
        /// Keyword that is the start of a try block.
        /// </summary>
        public const string Try = "try";

        /// <summary>
        /// Keyword that determines gets the type definition of the object.
        /// </summary>
        public const string TypeOf = "typeof";

        /// <summary>
        /// Keyword to suppress overflow checking in arithmetic operations and conversions.
        /// </summary>
        public const string UnChecked = "unchecked";

        /// <summary>
        /// Keyword to note this call access pointers and is unsafe for memory collection.
        /// </summary>
        public const string UnSafe = "unsafe";

        /// <summary>
        /// Keyword directive to note a target namespace that is used in the scope of a code file.
        /// </summary>
        public const string Using = "using";

        /// <summary>
        /// Keyword directive to a static type where the static members and nested type can be accessed without specifying the type. 
        /// </summary>
        public const string UsingStatic = "using static";

        /// <summary>
        /// Keyword to note that a method, property, indexer, or event can be overridden.
        /// </summary>
        public const string Virtual = "virtual";

        /// <summary>
        /// Keyword that notes that the method will not return a value.
        /// </summary>
        public const string Void = "void";

        /// <summary>
        /// Keyword that determines a field can be modified by multiple threads during execution at the same time. 
        /// </summary>
        public const string Volatile = "volatile";

        /// <summary>
        /// Keyword that continues execution of a code block while the evaluation statement is true.
        /// </summary>
        public const string While = "while";
    }
}
