using System;

namespace CodeFactory.Logging
{
    /// <summary>
    /// Manager class that returns the correct instance of the logger managed by code factory.
    /// </summary>
    public static class LogManager
    {
        /// <summary>
        /// Loads the target logger instance.
        /// </summary>
        /// <typeparam name="T">The target class type to be logged.</typeparam>
        /// <returns>Instance of the target code factory logger.</returns>
        public static ILogger GetLogger<T>() where T : class
        {
            Type loggerType = typeof(T);

            return GetLogger(loggerType.FullName);
        }

        /// <summary>
        /// Loads the target logger instance.
        /// </summary>
        /// <param name="targetType">The target type to load the logger for.</param>
        /// <returns>Instance of the target code factory logger.</returns>
        public static ILogger GetLogger(Type targetType)
        {
            return GetLogger(targetType.FullName);
        }

        /// <summary>
        /// Loads the target logger instance.
        /// </summary>
        /// <param name="loggerName">The name of the logger to be loaded.</param>
        /// <returns>Instance of the target code factory logger.</returns>
        public static ILogger GetLogger(string loggerName)
        {
            var logger = NLog.LogManager.GetLogger(loggerName);

            return new NLogLogger(logger);
        }
    }
}
