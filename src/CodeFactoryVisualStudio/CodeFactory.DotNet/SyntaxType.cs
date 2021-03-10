//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Determines the type of syntax that is hosted in a Dot Net model.
    /// </summary>
    public enum SyntaxType
    {
        /// <summary>
        /// The syntax is hosted in the body of the target model.
        /// </summary>
        Body = 0,

        /// <summary>
        /// The syntax is hosted in a single expression using a => directive.
        /// </summary>
        Expression = 1,

        /// <summary>
        /// No syntax definition has been identified or an unknown declaration was used. 
        /// </summary>
        Unknown = 9999
    }
}
