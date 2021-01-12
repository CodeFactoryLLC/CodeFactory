//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Collections.Generic;
using CodeFactory.SourceCode;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Data model that represents the definition of an event.
    /// </summary>
    public abstract class CsEvent:CsMember,ICsEvent
    {
        #region Property backing fields
        private readonly bool _isAbstract;
        private readonly bool _isVirtual;
        private readonly bool _isOverride;
        private readonly bool _isSealed;
        private readonly bool _isStatic;
        private readonly CsDelegate _eventHandlerDelegate;
        private readonly CsMethod _raiseMethod;
        private readonly CsMethod _addMethod;
        private readonly CsMethod _removeMethod;
        private readonly CsType _eventType;
        #endregion

        /// <summary>
        /// Constructor for the <see cref="CsEvent"/>
        /// </summary>
        /// <param name="isLoaded">Flag that determines if the model was loaded.</param>
        /// <param name="hasErrors">Flag that determine if errors were found creating the model.</param>
        /// <param name="loadedFromSource">Flag that determines if the model was loaded from source code or from an existing library.</param>
        /// <param name="language">The target language the model was generated from.</param>
        /// <param name="eventType">The type definition that supports this event.</param>
        /// <param name="sourceDocument">The source document that was used to build this model. This is optional parameter and can be null.</param>
        /// <param name="modelStore">Optional the lookup storage for models created during the compile or lookup of the model.</param>
        /// <param name="modelErrors">Optional the error that occured while creating the model.</param>
        /// <param name="attributes">List of the attributes assigned to this model.</param>
        /// <param name="sourceFiles">List of the fully qualified paths to the source code files this member is defined in.</param>
        /// <param name="hasDocumentation">Flag that determines if the model has XML documentation assigned to it.</param>
        /// <param name="documentation">The xml documentation assigned to the model.</param>
        /// <param name="lookupPath">The fully qualified model lookup path for this model.</param>
        /// <param name="name">The name of the model.</param>
        /// <param name="parentPath">THe fully qualified lookup path for the parent model to this one.</param>
        /// <param name="security">The security scope assigned to this model.</param>
        /// <param name="isAbstract">Flag that determines if the model is abstract.</param>
        /// <param name="isVirtual">Flag that determines if the model is virtual.</param>
        /// <param name="isSealed">Flag that determines if the model is sealed.</param>
        /// <param name="isOverride">Flag that determines if the model is overridden.</param>
        /// <param name="isStatic">Flag that determines if the model is static.</param>
        /// <param name="eventHandlerDelegate">Delegate model for this event.</param>
        /// <param name="raiseMethod">Model for the raise method for this event.</param>
        /// <param name="addMethod">Model for the add method for this event.</param>
        /// <param name="removeMethod">Model for the remove method for this event.</param>
        protected CsEvent(bool isLoaded, bool hasErrors, bool loadedFromSource, SourceCodeType language,
            IReadOnlyList<CsAttribute> attributes, IReadOnlyList<string> sourceFiles, bool hasDocumentation, string documentation,
            string lookupPath, string name, string parentPath, CsSecurity security, bool isAbstract, bool isVirtual, bool isOverride, 
            bool isSealed, bool isStatic, CsDelegate eventHandlerDelegate, CsMethod raiseMethod, CsMethod addMethod, CsMethod removeMethod,
            CsType eventType, string sourceDocument = null, ModelStore<ICsModel> modelStore = null, IReadOnlyList<ModelLoadException> modelErrors = null): base(isLoaded, hasErrors, loadedFromSource, 
            language, CsModelType.Event, attributes, sourceFiles, hasDocumentation, documentation, 
            lookupPath, name, parentPath, security, CsMemberType.Event, sourceDocument, modelStore, modelErrors)
        {
            _isAbstract = isAbstract;
            _isVirtual = isVirtual;
            _isOverride = isOverride;
            _isSealed = isSealed;
            _isStatic = isStatic;
            _eventHandlerDelegate = eventHandlerDelegate;
            _raiseMethod = raiseMethod;
            _addMethod = addMethod;
            _removeMethod = removeMethod;
            _eventType = eventType;
        }

        /// <summary>
        ///     The event handler delegate used by the event.
        /// </summary>
        IDotNetDelegate IDotNetEvent.EventHandlerDelegate => EventHandlerDelegate;

        /// <summary>
        ///     The method definition to raise the event.
        /// </summary>
        public CsMethod RaiseMethod => _raiseMethod;

        /// <summary>
        ///     The method that adds a subscription to the event.
        /// </summary>
        public CsMethod AddMethod => _addMethod;

        /// <summary>
        ///     The method that removes a subscription to the event.
        /// </summary>
        public CsMethod RemoveMethod => _removeMethod;

        /// <summary>
        ///     The event handler type that is assigned to the event. 
        /// </summary>
        public CsType EventType => _eventType;

        /// <summary>
        ///     The event handler delegate used by the event.
        /// </summary>
        public CsDelegate EventHandlerDelegate => _eventHandlerDelegate;

        /// <summary>
        ///     The method definition to raise the event.
        /// </summary>
        IDotNetMethod IDotNetEvent.RaiseMethod => RaiseMethod;

        /// <summary>
        ///     The method that adds a subscription to the event.
        /// </summary>
        IDotNetMethod IDotNetEvent.AddMethod => AddMethod;

        /// <summary>
        ///     The method that removes a subscription to the event.
        /// </summary>
        IDotNetMethod IDotNetEvent.RemoveMethod => RemoveMethod;

        /// <summary>
        ///     The event handler type that is assigned to the event. 
        /// </summary>
        IDotNetType IDotNetEvent.EventType => EventType;

        /// <summary>
        ///     Flag that determines if the event has been implemented as an abstract event.
        /// </summary>
        public bool IsAbstract => _isAbstract;

        /// <summary>
        ///     Flag that determines if the event is implemented as virtual.
        /// </summary>
        public bool IsVirtual => _isVirtual;

        /// <summary>
        ///     Flag that determines if the event has been overridden.
        /// </summary>
        public bool IsOverride => _isOverride;

        /// <summary>
        ///     Flag that determines if the event has been sealed.
        /// </summary>
        public bool IsSealed => _isSealed;

        /// <summary>
        ///     Flag that determines if the event is static.
        /// </summary>
        public bool IsStatic => _isStatic;
    }
}
