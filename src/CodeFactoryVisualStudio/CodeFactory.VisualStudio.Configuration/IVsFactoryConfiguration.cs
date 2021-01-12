//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Collections.Generic;

namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Configuration model definition all data needed to load a code factory configuration into visual studio.
    /// </summary>
    public interface IVsFactoryConfiguration
    {
        /// <summary>
        /// The name assigned to this automation configuration. 
        /// </summary>
        string Name { get;}

        /// <summary>
        /// The unique identifier that is assigned to the factory configuration.
        /// </summary>
        Guid Id { get;}

        /// <summary>
        /// Enumeration of the support libraries that need to be loaded to run the code factory libraries.
        /// </summary>
        List<VsLibraryConfiguration> SupportLibraries { get;}

        /// <summary>
        /// Enumeration of the code factory libraries that need to be loaded.
        /// </summary>
        List<VsLibraryConfiguration> CodeFactoryLibraries { get;}

        /// <summary>
        /// Enumeration of the commands to be loaded into the code factory.
        /// </summary>
       List<VsActionConfiguration> CodeFactoryActions { get;}
    }
}
