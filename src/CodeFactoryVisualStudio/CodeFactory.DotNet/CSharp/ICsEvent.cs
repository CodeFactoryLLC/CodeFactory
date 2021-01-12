//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model definition of a event in c#.
    /// </summary>
    public interface ICsEvent:ICsMember,IDotNetEvent
    {
        /// <summary>
        ///     The event handler delegate used by the event.
        /// </summary>
        new CsDelegate EventHandlerDelegate { get; }

        /// <summary>
        ///     The method definition to raise the event.
        /// </summary>
        new CsMethod RaiseMethod { get; }

        /// <summary>
        ///     The method that adds a subscription to the event.
        /// </summary>
        new CsMethod AddMethod { get; }

        /// <summary>
        ///     The method that removes a subscription to the event.
        /// </summary>
        new CsMethod RemoveMethod { get; }

        /// <summary>
        ///     The event handler type that is assigned to the event. 
        /// </summary>
        new CsType EventType { get; }
    }
}
