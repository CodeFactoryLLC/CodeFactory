using System;
using System.Runtime.CompilerServices;
using NLog;
using NLog.Fluent;

namespace CodeFactory.Logging
{
    /// <summary>
    /// Concrete implementation of code factory <see cref="ILogger"/> interface for NLog.
    /// </summary>
    internal class NLogLogger : Logger, ILogger
    {
        /// <summary>
        /// Static logging message to notify entering a member.
        /// </summary>
        private const string ENTER_MEMBER_MESSAGE = "Entering Member";

        /// <summary>
        /// Static logging message to notify exitng a member.
        /// </summary>
        private const string EXIT_MEMBER_MESSAGE = "Exiting Member";

        /// <summary>
        /// Holds the Nlog logger.
        /// </summary>
        private readonly Logger _logger;

        /// <summary>
        /// Constructior that injects the provided nlog logger.
        /// </summary>
        /// <param name="logger">NLog logger to be used for logging.</param>
        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }

        #region Implementation of ILogger

        /// <inheritdoc />
        public void TraceEnter([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsTraceEnabled) return;

            _logger.Info()
                .Message(ENTER_MEMBER_MESSAGE)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void TraceExit([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsTraceEnabled) return;

            _logger.Info()
                .Message(EXIT_MEMBER_MESSAGE)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void DebugEnter([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsDebugEnabled) return;

            _logger.Info()
                .Message(ENTER_MEMBER_MESSAGE)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void DebugExit([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsDebugEnabled) return;

            _logger.Info()
                .Message(EXIT_MEMBER_MESSAGE)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void InfoEnter([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsInfoEnabled) return;

            _logger.Info()
                .Message(ENTER_MEMBER_MESSAGE)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void InfoExit([CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsInfoEnabled) return;

            _logger.Info()
                .Message(EXIT_MEMBER_MESSAGE)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void Trace(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsTraceEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            _logger.Trace()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void Debug(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsDebugEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            _logger.Debug()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void Information(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsInfoEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            _logger.Info()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void Warning(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsWarnEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            _logger.Warn()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void Warning(string message, Exception exception, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsWarnEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            var builder = _logger.Warn()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber);

            if (exception != null) builder.Exception(exception);

            builder.Write();

        }

        /// <inheritdoc />
        public void Error(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsErrorEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            _logger.Error()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void Error(string message, Exception exception, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsErrorEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            var builder = _logger.Error()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber);

            if (exception != null) builder.Exception(exception);

            builder.Write();
        }

        /// <inheritdoc />
        public void Critical(string message, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsFatalEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            _logger.Fatal()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber)
                .Write();
        }

        /// <inheritdoc />
        public void Critical(string message, Exception exception, [CallerMemberName] string memberName = null, [CallerLineNumber] int lineNumber = 0)
        {
            if (_logger == null) return;

            if (!_logger.IsFatalEnabled) return;

            if (string.IsNullOrEmpty(message)) return;

            var builder = _logger.Fatal()
                .Message(message)
                .Property(LoggingProperties.MemberName, memberName)
                .Property(LoggingProperties.LineNumber, lineNumber);

            if (exception != null) builder.Exception(exception);

            builder.Write();

        }

        #endregion
    }
}
