//*****************************************************************************
//* CodeFactory SDK
//* Copyright (c) 2021 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Target framework in which the project will output to. 
    /// </summary>
    public interface IVsProjectFramework
    {
        /// <summary>
        /// The framework that the project is targeting.
        /// </summary>
        string Framework { get; }

        /// <summary>
        /// The specified version the framework to be released to.
        /// </summary>
        string Version { get; }
    }
}
