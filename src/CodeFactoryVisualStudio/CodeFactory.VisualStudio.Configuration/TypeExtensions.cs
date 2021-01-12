//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System;
using System.Linq;
using CodeFactory.Logging;


namespace CodeFactory.VisualStudio.Configuration
{
    /// <summary>
    /// Class that holds extension methods that support management of the type system in .Net
    /// </summary>
    public static class TypeExtensions
    {
        private static readonly ILogger _logger = LogManager.GetLogger(typeof(TypeExtensions));

        /// <summary>
        /// Extension method that confirms if a target interface type is implemented in the supplied type.
        /// </summary>
        /// <param name="source">The source type to validate.</param>
        /// <param name="targetInterface">The definition of the target interface to search for.</param>
        /// <returns>True if implemented or false if not found.</returns>
        public static bool InheritsInterface(this Type source, Type targetInterface)
        {
            _logger.DebugEnter();
            if (source == null)
            {
                _logger.Information("No source type was provided, cannot confirm if the type implements the interface.");
                _logger.DebugExit();
                return false;
            }

            if (targetInterface == null)
            {
                _logger.Information("No target interface type was provided, cannot continue.");
                _logger.DebugExit();
                return false;
            }

            if (!targetInterface.IsInterface)
            {
                _logger.Information(
                    $"The target interface '{targetInterface.Name}' is not an interface, cannot check inheritance for '{source.Name}'.");
                _logger.DebugExit();
                return false;
            }
            bool result = false;
            try
            {
                var interfaces = source.GetInterfaces();

                result = interfaces.Any(i => i.FullName == targetInterface.FullName);
            }
            catch (Exception inheritCheckException)
            {
                _logger.Error(
                    $"The following unhandled exception occurred while checking the inheritance for '{source.Name}' ",
                    inheritCheckException);
             
                result = false;
            }

            _logger.DebugExit();
            return result;
        }
    }
}
