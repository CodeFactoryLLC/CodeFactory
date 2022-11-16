//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Enumeration of the type of methods that are supported in C#.
    /// </summary>
    public enum CsMethodType
    {
        /// <summary>
        /// The method is a member of a supporting interface, class or structure.
        /// </summary>
        Member = DotNetMethodType.Member,

        /// <summary>
        /// The method is a constructor for a supporting class or structure.
        /// </summary>
        Constructor = DotNetMethodType.Constructor,

        /// <summary>
        /// The method is a destructor for a supporting class.
        /// </summary>
        Destructor = DotNetMethodType.Destructor,

        /// <summary>
        /// The method supports the get functionality from a property.
        /// </summary>
        Get = DotNetMethodType.Get,

        /// <summary>
        /// The method supports the set functionality from a property.
        /// </summary>
        Set = DotNetMethodType.Set,

        /// <summary>
        /// The method supports the raise functionality from an event.
        /// </summary>
        Raise = DotNetMethodType.Raise,

        /// <summary>
        /// The method supports the Invoke functionality from a delegate.
        /// </summary>
        Invoke = DotNetMethodType.Invoke,

        /// <summary>
        /// The method is a local method and imbedded in another method
        /// </summary>
        Local = DotNetMethodType.Local,

        /// <summary>
        /// The method is a add method that adds subscription to a event.
        /// </summary>
        Add = DotNetMethodType.Add,

        /// <summary>
        /// The method is a remove method that removes subscription from an event.
        /// </summary>
        Remove = DotNetMethodType.Remove,

        /// <summary>
        /// This method is the definition for a partial method.
        /// </summary>
        PartialDefinition = DotNetMethodType.PartialDefinition,

        /// <summary>
        /// This method is the implementation for a partial method.
        /// </summary>
        PartialImplementation = DotNetMethodType.PartialImplementation,

        /// <summary>
        /// The type of method is unknown
        /// </summary>
        Unknown = DotNetMethodType.Unknown

    }
}
