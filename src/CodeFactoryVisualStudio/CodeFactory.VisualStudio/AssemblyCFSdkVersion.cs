//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Assembly attribute that tracks the CodeFactory SDK that was used to build this assembly.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyCFSdkVersion:Attribute
    {
        /// <summary>
        /// Backing field for the value property.
        /// </summary>
        private readonly string _value;

        /// <summary>
        /// The value assigned to the assembly attribute.
        /// </summary>
        public string Value => _value;

        /// <summary>
        /// Initializes a new instance of the attribute with no data.
        /// </summary>
        public AssemblyCFSdkVersion():this(""){}

        /// <summary>
        /// Initializes a new instance of the attribute.
        /// </summary>
        /// <param name="value">The type of CodeFactory library being created.</param>
        public AssemblyCFSdkVersion(string value)
        {
            _value = value;
        }
    }
}
