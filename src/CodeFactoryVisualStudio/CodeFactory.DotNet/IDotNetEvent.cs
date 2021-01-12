//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Model definition of a event in .net.
    /// </summary>
    public interface IDotNetEvent:IDotNetMember
    {
        /// <summary>
        ///     The event handler delegate used by the event.
        /// </summary>
        IDotNetDelegate EventHandlerDelegate { get; }

        /// <summary>
        ///     The method definition to raise the event.
        /// </summary>
        IDotNetMethod RaiseMethod { get; }

        /// <summary>
        ///     The method that adds a subscription to the event.
        /// </summary>
        IDotNetMethod AddMethod { get; }

        /// <summary>
        ///     The method that removes a subscription to the event.
        /// </summary>
        IDotNetMethod RemoveMethod { get; }

        /// <summary>
        ///     The event handler type that is assigned to the event. 
        /// </summary>
        IDotNetType EventType { get; }

        /// <summary>
        ///     Flag that determines if the event has been implemented as an abstract event.
        /// </summary>
        bool IsAbstract { get; }

        /// <summary>
        ///     Flag that determines if the event is implemented as virtual.
        /// </summary>
        bool IsVirtual { get; }

        /// <summary>
        ///     Flag that determines if the event has been overridden.
        /// </summary>
        bool IsOverride { get; }

        /// <summary>
        ///     Flag that determines if the event has been sealed.
        /// </summary>
        bool IsSealed { get; }

        /// <summary>
        ///     Flag that determines if the event is static.
        /// </summary>
        bool IsStatic { get; }
    }
}
