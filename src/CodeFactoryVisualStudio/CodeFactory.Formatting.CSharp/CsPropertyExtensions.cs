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
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsProperty"/> model.
    /// </summary>
    public static class CsPropertyExtensions
    {

        /// <summary>
        /// Generates a default property definition for use in an interface definition.
        /// </summary>
        /// <example>
        /// [property type] [property name] { [get when used]; [set when used]; }
        /// </example>
        /// <param name="source">Property model used for generation.</param>
        /// <param name="manager">Namespace manager used to format type names.</param>
        /// <returns>Formatted property or null if model data was missing.</returns>
        public static string CSharpFormatInterfacePropertySignature(this CsProperty source,
            NamespaceManager manager = null)
        {
            if (!source.IsLoaded) return null;

            string propertyDeclaration = CSharpFormatPropertyDeclaration(source, manager, false, 
                false, false); 

            if (string.IsNullOrEmpty(propertyDeclaration)) return null;

            StringBuilder propertyDefinition = new StringBuilder($"{propertyDeclaration} {{ ");

            if (source.HasGet & source.GetSecurity == CsSecurity.Public) propertyDefinition.Append("get; ");
            if (source.HasSet & source.SetSecurity == CsSecurity.Public) propertyDefinition.Append("set; ");

            propertyDefinition.Append("}");

            return propertyDefinition.ToString();

        }

        /// <summary>
        /// Generates a default property definition with a backing field. Will determine security modifiers and append to get and set statements when needed.
        /// </summary>
        /// <example>
        /// With Keywords [security] [keywords] [property type] [property name] { [get when used] => [backingField]; [set when used] =>[backingField] = value;  }
        /// Without Keywords [security] [property type] [property name] { [get when used] => [backingField]; [set when used] =>[backingField] = value;  }
        /// </example>
        /// <param name="source">Property model used for generation.</param>
        /// <param name="backingFieldName">the name of the backing field to be managed by the property.</param>
        /// <param name="manager">Namespace manager used to format type names.</param>
        /// <param name="includeKeyword">Optional parameter that determines if the keywords will be appended. Default is false.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <param name="propertySecurity">Optional parameter that overrides the models property security and sets a new security access level.</param>
        /// <param name="setSecurity">Optional parameter that overrides the models set security level with a new access level. Will also define a set statement even if it is not defined.</param>
        /// <param name="getSecurity">Optional parameter that overrides the models get security level with a new access level. Will also define a get statement even if it is not defined.</param>
        /// <returns>Formatted property or null if model data was missing.</returns>
        public static string CSharpFormatDefaultExpressionBodyPropertySignatureWithBackingField(this CsProperty source,
            string backingFieldName, NamespaceManager manager = null, bool includeKeyword = false, 
            bool includeAbstractKeyword = false, CsSecurity propertySecurity = CsSecurity.Unknown,
            CsSecurity setSecurity = CsSecurity.Unknown, CsSecurity getSecurity = CsSecurity.Unknown)
        {
            if (!source.IsLoaded) return null;
            if (string.IsNullOrEmpty(backingFieldName)) return null;

            string propertyDeclaration = CSharpFormatPropertyDeclaration(source, manager, true,includeKeyword, 
                includeAbstractKeyword, propertySecurity);

            if (string.IsNullOrEmpty(propertyDeclaration)) return null;

            StringBuilder propertyDefinition = new StringBuilder($"{propertyDeclaration} {{ ");

            if (source.HasGet | getSecurity != CsSecurity.Unknown)
            {
                var getStatement = source.CSharpFormatGetStatement(propertySecurity, getSecurity);
                if (getStatement == null) return null;
                propertyDefinition.Append($"{getStatement} => {backingFieldName}; ");
            }

            if (source.HasSet | setSecurity != CsSecurity.Unknown)
            {
                var setStatement = source.CSharpFormatSetStatement(propertySecurity, setSecurity);
                if (setStatement == null) return null;
                propertyDefinition.Append($"{setStatement} => {backingFieldName} = value; ");
            }

            propertyDefinition.Append("}");

            return propertyDefinition.ToString();

        }

        /// <summary>
        /// Generates a default property definition with a backing properties. Will determine security modifiers and append to get and set statements when needed.
        /// </summary>
        /// <example>
        /// With Keywords [security] [keywords] [property type] [property name] { [get when used]{return [backingField];} [set when used]{ [backingField] = value;}  }
        /// Without Keywords [security] [property type] [property name] { [get when used]{return [backingField];} [set when used]{ [backingField] = value;}  }
        /// </example>
        /// <param name="source">Property model used for generation.</param>
        /// <param name="backingFieldName">the name of the backing field to be managed by the property.</param>
        /// <param name="manager">Namespace manager used to format type names.</param>
        /// <param name="includeKeyword">Optional parameter that determines if the keywords will be appended. Default is false.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <param name="propertySecurity">Optional parameter that overrides the models property security and sets a new security access level.</param>
        /// <param name="setSecurity">Optional parameter that overrides the models set security level with a new access level. Will also define a set statement even if it is not defined.</param>
        /// <param name="getSecurity">Optional parameter that overrides the models get security level with a new access level. Will also define a get statement even if it is not defined.</param>
        /// <returns>Formatted property or null if model data was missing.</returns>
        public static string CSharpFormatDefaultPropertySignatureWithBackingField(this CsProperty source,
            string backingFieldName, NamespaceManager manager = null, bool includeKeyword = false,
            bool includeAbstractKeyword = false, CsSecurity propertySecurity = CsSecurity.Unknown,
            CsSecurity setSecurity = CsSecurity.Unknown, CsSecurity getSecurity = CsSecurity.Unknown)
        {
            if (!source.IsLoaded) return null;
            if (string.IsNullOrEmpty(backingFieldName)) return null;

            string propertyDeclaration = CSharpFormatPropertyDeclaration(source, manager,true, includeKeyword,includeAbstractKeyword,
                propertySecurity);

            if (string.IsNullOrEmpty(propertyDeclaration)) return null;

            StringBuilder propertyDefinition = new StringBuilder($"{propertyDeclaration} {{ ");

            if (source.HasGet | getSecurity != CsSecurity.Unknown)
            {
                var getStatement = source.CSharpFormatGetStatement(propertySecurity, getSecurity);
                if (getStatement == null) return null;
                propertyDefinition.Append($"{getStatement} {{ return {backingFieldName}; }} ");
            }

            if (source.HasSet | setSecurity != CsSecurity.Unknown)
            {
                var setStatement = source.CSharpFormatSetStatement(propertySecurity, setSecurity);
                if (setStatement == null) return null;
                propertyDefinition.Append($"{setStatement} {{ {backingFieldName} = value; }}  ");
            }

            propertyDefinition.Append("}");

            return propertyDefinition.ToString();

        }

        /// <summary>
        /// Generates a default property definition with no backing properties. Will determine security modifiers and append to get and set statements when needed.
        /// </summary>
        /// <example>
        /// With Keywords [security] [keywords] [property type] [property name] { [get when used]; [set when used]; }
        /// No Keywords [security] [property type] [property name] { [get when used]; [set when used]; }
        /// </example>
        /// <param name="source">Property model used for generation.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <param name="includeKeyword">Optional parameter that determines if the keywords will be appended. Default is false.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <param name="propertySecurity">Optional parameter that overrides the models property security and sets a new security access level.</param>
        /// <param name="setSecurity">Optional parameter that overrides the models set security level with a new access level. Will also define a set statement even if it is not defined.</param>
        /// <param name="getSecurity">Optional parameter that overrides the models get security level with a new access level. Will also define a get statement even if it is not defined.</param>
        /// <returns>Formatted property or null if model data was missing.</returns>
        public static string CSharpFormatDefaultPropertySignature(this CsProperty source, NamespaceManager manager = null, bool includeKeyword = false,
            bool includeAbstractKeyword = false, CsSecurity propertySecurity = CsSecurity.Unknown, CsSecurity setSecurity = CsSecurity.Unknown,
            CsSecurity getSecurity = CsSecurity.Unknown)
        {
            if (!source.IsLoaded) return null;
            string propertyDeclaration = CSharpFormatPropertyDeclaration(source, manager,true, includeKeyword, includeAbstractKeyword,
                propertySecurity);

            if (string.IsNullOrEmpty(propertyDeclaration)) return null;

            StringBuilder propertyDefinition = new StringBuilder($"{propertyDeclaration} {{ ");

            if (source.HasGet | getSecurity != CsSecurity.Unknown)
            {
                var getStatement = source.CSharpFormatGetStatement(propertySecurity, getSecurity);
                if (getStatement == null) return null;
                propertyDefinition.Append($"{getStatement}; ");
            }

            if (source.HasSet | setSecurity != CsSecurity.Unknown)
            {
                var setStatement = source.CSharpFormatSetStatement(propertySecurity, setSecurity);
                if (setStatement == null) return null;
                propertyDefinition.Append($"{setStatement}; ");
            }

            propertyDefinition.Append("}");

            return propertyDefinition.ToString();
        }


        /// <summary>
        /// Generates the initial definition portion of a property.
        /// </summary>
        /// <example>
        /// Format with Keywords [Security] [Keywords*] [ReturnType] [PropertyName] = public static string FirstName
        /// Format without Keywords [Security] [ReturnType] [PropertyName] = public string FirstName
        /// </example>
        /// <param name="manager">Namespace manager used to format type names.</param>
        /// <param name="source">The source property to use for formatting.</param>
        /// <param name="includeSecurity">Optional flag that determines if the security scope will be applied to the property definition. Default is true.</param>
        /// <param name="includeKeyWords">Optional flag that determines if keywords assigned to the property should be included in the signature. Default is false.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <param name="propertySecurity">Optional parameter to override the models security and set your own security.</param>
        /// <returns>The formatted signature or null if the model data was not loaded.</returns>
        public static string CSharpFormatPropertyDeclaration(this CsProperty source, NamespaceManager manager = null, bool includeSecurity = true, bool includeKeyWords = false,
            bool includeAbstractKeyword = false, CsSecurity propertySecurity = CsSecurity.Unknown)
        {
            if (!source.IsLoaded) return null;

            StringBuilder propertyBuilder = new StringBuilder();

            if (includeKeyWords & source.IsSealed) propertyBuilder.Append($"{Keywords.Sealed} ");

            if (includeSecurity)
            {
                propertyBuilder.Append(propertySecurity == CsSecurity.Unknown
                    ? source.Security.CSharpFormatKeyword()
                    : propertySecurity.CSharpFormatKeyword());
            }

            if (includeKeyWords)
            {
                if (source.IsStatic) propertyBuilder.Append($" {Keywords.Static}");
                if (source.IsOverride) propertyBuilder.Append($" {Keywords.Override}"); 
                if (source.IsAbstract & !source.IsOverride & includeAbstractKeyword) propertyBuilder.Append($" {Keywords.Abstract}");
                if (source.IsVirtual & !source.IsOverride) propertyBuilder.Append($" {Keywords.Virtual}");
            }

            propertyBuilder.Append($" {source.PropertyType.CSharpFormatTypeName(manager)}");
            propertyBuilder.Append($" {source.Name}");

            return propertyBuilder.ToString();
        }

        /// <summary>
        /// Extension method that formats the get statement of a property definition.
        /// </summary>
        /// <example>
        /// With the same security   [get] will return example: get
        /// With different security [security] [get] will return example: public get
        /// </example>
        /// <param name="source">the source property definition</param>
        /// <param name="propertySecurity">Optional parameter that defined the security used by the implementing property.</param>
        /// <param name="getSecurity">Optional parameter that allows you to set the get security level.</param>
        /// <returns>Will return the formatted get statement or null if the property model is empty or the property does not support get.</returns>
        public static string CSharpFormatGetStatement(this CsProperty source, CsSecurity propertySecurity = CsSecurity.Unknown,
            CsSecurity getSecurity = CsSecurity.Unknown)
        {
            if (!source.IsLoaded) return null;
            if (!source.HasGet & getSecurity == CsSecurity.Unknown) return null;

            CsSecurity security = propertySecurity == CsSecurity.Unknown ? source.Security : propertySecurity;

            CsSecurity accessSecurity = getSecurity == CsSecurity.Unknown ? source.GetSecurity : getSecurity;

            return security == accessSecurity ? "get" : $"{accessSecurity.CSharpFormatKeyword()} get";

        }

        /// <summary>
        /// Extension method that formats the set statement of a property definition.
        /// </summary>
        /// <example>
        /// With the same security   [set] will return example: set
        /// With different security [security] [set] will return example: public set
        /// </example>
        /// <param name="source">the source property definition</param>
        /// <param name="propertySecurity">Optional parameter that defined the security used by the implementing property.</param>
        /// <param name="setSecurity">Optional parameter that allows you to set the set security level.</param>
        /// <returns>Will return the formatted set statement or null if the property model is empty or the property does not support set.</returns>
        public static string CSharpFormatSetStatement(this CsProperty source,CsSecurity propertySecurity = CsSecurity.Unknown,
            CsSecurity setSecurity = CsSecurity.Unknown)
        {
            if (!source.IsLoaded) return null;
            if (!source.HasSet & setSecurity == CsSecurity.Unknown) return null;
            CsSecurity security = propertySecurity == CsSecurity.Unknown ? source.Security : propertySecurity;

            CsSecurity accessSecurity = setSecurity == CsSecurity.Unknown ? source.SetSecurity : setSecurity;

            return security == accessSecurity ? "set" : $"{accessSecurity.CSharpFormatKeyword()} set";
        }

    }
}
