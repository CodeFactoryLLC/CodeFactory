//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2022 CodeFactory, LLC
//*****************************************************************************
using System.Text;
using CodeFactory.DotNet.CSharp;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.Formatting.CSharp
{
    /// <summary>
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsEvent"/> model.
    /// </summary>
    public static class CsEventExtensions
    {
        /// <summary>
        /// Defines a standard event declaration for a interface.
        /// </summary>
        /// <param name="source">Event model to load.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <returns>Fully formatted event definition or null if the event data could not be generated.</returns>
        public static string CSharpFormatInterfaceEventDeclaration(this CsEvent source, NamespaceManager manager = null)
        {
            return source.CSharpFormatEventDeclaration(manager, false, CsSecurity.Unknown,false,false);
        }

        /// <summary>
        /// Generates the syntax definition of an event in c# syntax. 
        /// </summary>
        /// <example>
        /// With Keywords [security] [keywords] event [event handler type] [name];
        /// Without Keywords [security] [keywords] event [event handler type] [name];
        /// </example>
        /// <param name="source">The source <see cref="CsEvent"/> model to generate.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <param name="includeSecurity">Includes the security scope which was defined in the model.</param>
        /// <param name="eventSecurity">Optional parameter that sets the target security scope for the event.</param>
        /// <param name="includeKeywords">Optional parameter that determines if it will include all keywords assigned to the source model, default is false.</param>
        /// <param name="includeAbstractKeyword">Optional parameter that determines if it will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <returns>Fully formatted event definition or null if the event data could not be generated.</returns>
        public static string CSharpFormatEventDeclaration(this CsEvent source, NamespaceManager manager = null, bool includeSecurity = true, CsSecurity eventSecurity = CsSecurity.Unknown,
           bool includeKeywords = true, bool includeAbstractKeyword = false)
        {
            if (source == null) return null;
            if (!source.IsLoaded) return null;

            StringBuilder eventFormatting = new StringBuilder();

            CsSecurity security = eventSecurity == CsSecurity.Unknown
                ? security = source.Security
                : security = eventSecurity;

            if(includeKeywords & source.IsSealed) eventFormatting.Append($"{Keywords.Sealed} ");

            if (includeSecurity) eventFormatting.Append($"{security.CSharpFormatKeyword()} ");
            
            if (includeKeywords)
            {
                if (source.IsStatic) eventFormatting.Append($"{Keywords.Static} ");
                if (includeAbstractKeyword & source.IsAbstract) eventFormatting.Append($"{Keywords.Abstract} ");
                if (source.IsOverride) eventFormatting.Append($"{Keywords.Override} ");
                if (source.IsVirtual) eventFormatting.Append($"{Keywords.Virtual} ");
            }

            eventFormatting.Append($"{Keywords.Event} {source.EventType.CSharpFormatTypeName(manager)} {source.Name};");

            return eventFormatting.ToString();
        }

    }
}
