//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using CodeFactory.Logging;

namespace CodeFactory.VisualStudio.UI
{
    /// <summary>
    /// The base implementation of a WPF <see cref="UserControl"/> that has been extended to provide direct access to visual studio for code factory integration.
    /// </summary>
    public  class VsUserControl:UserControl
    {
        /// <summary>
        /// Logger class that is assigned to this user control.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected readonly ILogger _logger;

        /// <summary>
        /// The visual studio actions provided by code factory for use with visual studio.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected readonly IVsActions _visualStudioActions;

        /// <summary>
        /// Default constructor only to be used for compatibility with the visual editor.
        /// </summary>
        public VsUserControl()
        {
            WindowTitle = string.Empty;
            //Intentionally blank only use this constructor to be compatible with the UI editor.
        }

        /// <summary>
        /// Initializes the base implementation of a <see cref="VsUserControl"/> user control.
        /// </summary>
        /// <param name="actions">The visual studio actions accessible in this user control. </param>
        /// <param name="logger">The logger for interaction inside this user control.</param>
        public VsUserControl(IVsActions actions, ILogger logger) : base()
        {
            _logger = logger;
            _visualStudioActions = actions;
            WindowTitle = string.Empty;
        }


        /// <summary>
        /// The title that will be assigned to windows that host this user control. 
        /// </summary>
        public string WindowTitle
        {
            get => (string)GetValue(WindowTitleProperty);
            set => SetValue(WindowTitleProperty, value);
        }

        /// <summary>
        /// Backing store for the dependance property <see cref="WindowTitle"/> 
        /// </summary>
        // Using a DependencyProperty as the backing store for WindowTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowTitleProperty =
            DependencyProperty.Register("WindowTitle", typeof(string), typeof(VsUserControl));



        /// <summary>
        /// Event handler when the <see cref="Window.Activated"/> is raised to this user control. 
        /// </summary>
        /// <param name="sender">Source window that has been activated.</param>
        /// <param name="e">Args from the window.</param>
        public virtual void WindowActivated(object sender, EventArgs e)
        {
            _logger.DebugEnter();
            _logger.Debug("Window activated event fired.");
            _logger.DebugExit();
        }

        /// <summary>
        /// Event handler when the <see cref="Window.Closing"/> is raised to this user control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void WindowClosing(object sender, CancelEventArgs e)
        {
            _logger.DebugEnter();
            _logger.Debug("Window closing event fired.");
            _logger.DebugExit();
        }

        /// <summary>
        /// Event that is raised when the user control informs the hosting window or control in visual studio to close. 
        /// </summary>
        public event EventHandler CloseHost;

        /// <summary>
        /// Triggers the <see cref="CloseHost"/> event that will inform the host of this user control to close.
        /// </summary>
        protected void Close()
        {
            _logger.DebugEnter();
            var closeHandler = CloseHost;

            if (closeHandler == null)
            {
                _logger.Debug("No subscribers to the CloseHost event will not raise the CloseHost event.");
                _logger.DebugExit();
                return;
            }

            try
            {
                EventArgs args = new EventArgs();

                _logger.Debug("Invoking the event CloseHost");
                closeHandler.Invoke(this, args);

            }
            catch (Exception unhandledEventError)
            {
                _logger.Error("The following unhandled error occurred while raising the CloseHost event.",
                    unhandledEventError);
            }

            _logger.DebugExit();
        }

        /// <summary>
        /// Used by the code factory to subscribe to the hosts windows events to be made available to this user control. This is for internal code factory use only.
        /// </summary>
        /// <param name="host">The hosting window that will display this user control implementation.</param>
        public void SubscribeToHostWindow(Window host)
        {
            _logger.DebugEnter();
            if (host == null)
            {
                _logger.Error("No host was supplied, will not subscriber to the hosting windows events.");
                _logger.DebugExit();
                return;
            }

            try
            {
                host.Closing += WindowClosing;
                host.Activated += WindowActivated;
            }
            catch (Exception unhandledSubscribe)
            {
                _logger.Error("The following unhandled exception occurred while subscribing to the hosting window.",
                    unhandledSubscribe);
            }

            _logger.DebugExit();

        }

        /// <summary>
        /// Used by the code factory to release subscriptions to the host windows events. This is for internal code factory use only.
        /// </summary>
        /// <param name="host">The hosting window to release subscriptions.</param>
        public void ReleaseSubscriptionToHostWindow(Window host)
        {
            _logger.DebugEnter();
            if (host == null)
            {
                _logger.Error("No host was supplied, will not be able to remove subscriptions to the hosting window.");
                _logger.DebugExit();
                return;
            }

            try
            {
                host.Closing -= WindowClosing;
                host.Activated -= WindowActivated;
            }
            catch (Exception unhandledRelease)
            {
                _logger.Error(
                    "The following unhandled exception occurred while releasing the event subscriptions from the hosting window",
                    unhandledRelease);
            }

            _logger.DebugExit();
        }
    }
}
