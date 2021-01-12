//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Definition of the a language has compiler support within a target project.
    /// </summary>
    public enum ProjectLanguage
    {
        /// <summary>
        /// The project supports the compile of the C# programming language.
        /// </summary>
        CSharp = 0,

        /// <summary>
        /// The project supports the compile of the visual basic programming language.
        /// </summary>
        VisualBasic = 1,

        /// <summary>
        /// The project supports the compile of the F# programming language
        /// </summary>
        FSharp = 2,

        /// <summary>
        /// The project supports the compile of the type script programming language.
        /// </summary>
        TypeScript = 3,

        /// <summary>
        /// The project supports the compile of the java script programming language. 
        /// </summary>
        JavaScript = 4,

        /// <summary>
        /// Code factory could not determine the programming language. 
        /// </summary>
        Unknown = 9999

    }
}
