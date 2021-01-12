//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
namespace CodeFactory.DotNet
{
    /// <summary>
    /// Definition of data that will be provided to all T4 factories.
    /// </summary>
    public interface IT4Factory
    {
        /// <summary>
        /// Custom model data that has been assigned to the T4 factory.
        /// </summary>
        object ModelData { get; set; }
    }
}
