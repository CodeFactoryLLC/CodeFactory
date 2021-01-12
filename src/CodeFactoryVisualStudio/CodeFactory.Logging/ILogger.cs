using System;
using System.Runtime.CompilerServices;

namespace CodeFactory.Logging
{
    /// <summary>
    /// Standard logging interface used by Code factory to log information about the execution of code factory.
    /// </summary>
    public interface ILogger
    {

        /// <summary>
        /// Logs the entering into a member. This is an trace level log message.
        /// </summary>
        /// <param name="memberName">The name of the member being logged. Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs. Important the compiler will populate this value automatically.</param>
        void TraceEnter([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the exiting of a member. This is an trace level log message.
        /// </summary>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void TraceExit([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the entering into a member. This is an debuglevel log message.
        /// </summary>
        /// <param name="memberName">The name of the member being logged. Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs. Important the compiler will populate this value automatically.</param>
        void DebugEnter([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the exiting of a member. This is an debug level log message.
        /// </summary>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void DebugExit([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the entering into a member. This is an information level log message.
        /// </summary>
        /// <param name="memberName">The name of the member being logged. Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs. Important the compiler will populate this value automatically.</param>
        void InfoEnter([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs the exiting of a member. This is an information level log message.
        /// </summary>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void InfoExit([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs detailed execution information. This level is used for application tracing.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Trace(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs debug level information. This level is used for application debugging.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Debug(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs general information about the executing code base. This is the default logging level.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Information(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs warning level information about the executing code base. This level is always logged when enabled.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Warning(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs warning level information about the executing code base. This level is always logged when enabled.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">The exception that occured that needs to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Warning(string message, Exception exception, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs error level information about the executing code base. This level is always logged when enabled.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Error(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs error level information about the executing code base. This level is always logged when enabled.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">The exception that occured that needs to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Error(string message, Exception exception, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);


        /// <summary>
        /// Logs critical level information about the executing code base. This level is always logged when enabled.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Critical(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);

        /// <summary>
        /// Logs critical level information about the executing code base. This level is always logged when enabled.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="exception">The exception that occured that needs to be logged.</param>
        /// <param name="memberName">The name of the member being logged.Important the compiler will populate this value automatically.</param>
        /// <param name="lineNumber">The line number where the logging event occurs.Important the compiler will populate this value automatically.</param>
        void Critical( string message, Exception exception, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0);
    }
}
