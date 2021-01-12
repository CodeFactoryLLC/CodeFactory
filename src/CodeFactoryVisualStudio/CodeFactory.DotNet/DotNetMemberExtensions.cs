//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System;
using System.Text;
using CodeFactory.DotNet.CSharp.FormattedSyntax;

namespace CodeFactory.DotNet
{
    /// <summary>
    /// Extension methods that support model that implement the <see cref="IDotNetMember"/> interface.
    /// </summary>
    public static class DotNetMemberExtensions
    {


        /// <summary>
        /// Gets the hash code for a formatted model signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="IDotNetModel"/> model.</param>
        /// <param name="comparisonType">The type of comparision format to use when generating the hashcode. Default is set to the base comparision type.</param>
        /// <returns>The has code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the model is null.</exception>
        public static int FormatCSharpMemberComparisonHashCode(this IDotNetMember source,
            MemberComparisonType comparisonType = MemberComparisonType.Base)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            int result = 0;

            bool includeSecurity = false;
            bool includeAttributes = false;
            bool includeKeywords = false;

            switch (comparisonType)
            {
                case MemberComparisonType.Security:
                    includeSecurity = true;
                    break;
                case MemberComparisonType.Full:
                    includeSecurity = true;
                    includeKeywords = true;
                    break;
               
            }

            switch (source.MemberType)
            {
                case DotNetMemberType.Event:
                    var memberEvent = source as IDotNetEvent;
                    result = memberEvent.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes,
                        includeKeywords);
                    break;
                case DotNetMemberType.Field:
                    var memberField = source as IDotNetField;

                    result = memberField.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes,
                        includeKeywords);
                    break;
                case DotNetMemberType.Method:
                    var memberMethod = source as IDotNetMethod;

                    result = memberMethod.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes,
                        includeKeywords);
                    break;
                case DotNetMemberType.Property:
                    var memberProperty = source as IDotNetProperty;

                    result = memberProperty.FormatCSharpComparisonHashCode(includeSecurity, includeAttributes,
                        includeKeywords);

                    break;
                
                default:
                    result = 0;
                    break;
            }

            return result;
        }


        /// <summary>
        /// Generates the syntax definition of field in c# syntax. The default definition with all options turned off will return the filed signature and constants if defined and the default values.
        /// </summary>
        /// <param name="source">The source <see cref="IDotNetField"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which the field was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the field from the source model.</param>
        /// <returns>Fully formatted field definition or null if the field data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this IDotNetField source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true)
        {
            if (source == null) return null;

            StringBuilder fieldFormatting = new StringBuilder();

            if (includeAttributes & source.HasAttributes)
            {
                foreach (var sourceAttribute in source.Attributes)
                {
                    fieldFormatting.AppendLine(sourceAttribute.FormatCSharpAttributeSignatureSyntax());
                }
            }

            if (includeSecurity)
            {
                fieldFormatting.Append($"{source.Security.FormatCSharpSyntax()} ");
            }

            if (includeKeywords)
            {
                if (source.IsStatic) fieldFormatting.Append($"{Keywords.Static} ");
                if (source.IsReadOnly) fieldFormatting.Append($"{Keywords.Readonly} ");
            }

            if (source.IsConstant) fieldFormatting.Append($"{Keywords.Constant} ");
            fieldFormatting.Append($"{source.DataType.FormatCSharpFullTypeName()} ");
            fieldFormatting.Append($"{source.DataType.Name}");
            if (source.IsConstant)
                fieldFormatting.Append($" = {source.DataType.FormatCSharpValueSyntax(source.ConstantValue)}");

            return fieldFormatting.ToString();

        }

        /// <summary>
        /// Gets the hash code for a formatted field signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="IDotNetField"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords other then constant are included in the definition. By default this is false.</param>
        /// <returns>The has code of the formatted field.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this IDotNetField source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords).GetHashCode();
        }

        /// <summary>
        /// Generates the syntax definition of a default no backing fields property definition in c# syntax.
        /// </summary>
        /// <param name="source">The source <see cref="IDotNetProperty"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which the property was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the property from the source model.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <returns>Fully formatted property definition or null if the property data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this IDotNetProperty source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true,bool includeAbstractKeyword = false)
        {
            if (source == null) return null;

            StringBuilder propertyFormatting = new StringBuilder();

            if (includeAttributes & source.HasAttributes)
            {
                foreach (var sourceAttribute in source.Attributes)
                {
                    propertyFormatting.AppendLine(sourceAttribute.FormatCSharpAttributeSignatureSyntax());
                }
            }

            if (includeSecurity)
            {
                propertyFormatting.Append($"{source.Security.FormatCSharpSyntax()} ");
            }

            if (includeKeywords)
            {
                if (source.IsStatic) propertyFormatting.Append($"{Keywords.Static} ");
                if (source.IsSealed) propertyFormatting.Append($"{Keywords.Sealed} ");
                if (includeAbstractKeyword & source.IsAbstract) propertyFormatting.Append($"{Keywords.Abstract} ");
                if (source.IsOverride) propertyFormatting.Append($"{Keywords.Override} ");
                if (source.IsVirtual) propertyFormatting.Append($"{Keywords.Virtual} ");
            }

            propertyFormatting.Append($"{source.PropertyType.FormatCSharpFullTypeName()} ");
            propertyFormatting.Append($"{source.Name} {Symbols.MultipleStatementStart} ");

            if (source.HasGet)
            {
                if (includeSecurity)
                {
                    if (source.Security != source.GetSecurity)
                        propertyFormatting.Append($"{source.GetSecurity.FormatCSharpSyntax()} ");
                }

                propertyFormatting.Append("get; ");

            }

            if (source.HasSet)
            {
                if (includeSecurity)
                {
                    if (source.Security != source.SetSecurity)
                        propertyFormatting.Append($"{source.SetSecurity.FormatCSharpSyntax()} ");
                }

                propertyFormatting.Append("set; ");
            }

            propertyFormatting.Append(Symbols.MultipleStatementEnd);

            return propertyFormatting.ToString();

        }

        /// <summary>
        /// Gets the hash code for a formatted property signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="IDotNetProperty"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords are included in the definition. By default this is false.</param>
        /// <returns>The hash code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the  model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this IDotNetProperty source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords).GetHashCode();
        }

        /// <summary>
        /// Generates the syntax definition of an event in c# syntax. 
        /// </summary>
        /// <param name="source">The source <see cref="IDotNetEvent"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the source model.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <returns>Fully formatted event definition or null if the event data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this IDotNetEvent source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true, bool includeAbstractKeyword = false)
        {
            if (source == null) return null;

            StringBuilder eventFormatting = new StringBuilder();

            if (includeAttributes & source.HasAttributes)
            {
                foreach (var sourceAttribute in source.Attributes)
                {
                    eventFormatting.AppendLine(sourceAttribute.FormatCSharpAttributeSignatureSyntax());
                }
            }

            if (includeSecurity)
            {
                eventFormatting.Append($"{source.Security.FormatCSharpSyntax()} ");
            }

            if (includeKeywords)
            {
                if (source.IsStatic) eventFormatting.Append($"{Keywords.Static} ");
                if (source.IsSealed) eventFormatting.Append($"{Keywords.Sealed} ");
                if (includeAbstractKeyword & source.IsAbstract) eventFormatting.Append($"{Keywords.Abstract} ");
                if (source.IsOverride) eventFormatting.Append($"{Keywords.Override} ");
                if (source.IsVirtual) eventFormatting.Append($"{Keywords.Virtual} ");
            }

            eventFormatting.Append($"{source.EventType.FormatCSharpFullTypeName()} {source.Name}");

            return eventFormatting.ToString();

        }

        /// <summary>
        /// Gets the hash code for a formatted event signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="IDotNetEvent"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords are included in the definition. By default this is false.</param>
        /// <returns>The hash code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the  model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this IDotNetEvent source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords).GetHashCode();
        }

        /// <summary>
        /// Generates the syntax definition of an method in c# syntax. 
        /// </summary>
        /// <param name="source">The source <see cref="IDotNetMethod"/> model to generate.</param>
        /// <param name="includeSecurity">Includes the security scope which was defined in the model.</param>
        /// <param name="includeAttributes">Includes definition of the attributes assigned to the model.</param>
        /// <param name="includeKeywords">Includes all keywords assigned to the source model.</param>
        /// <param name="includeAbstractKeyword">Will include the definition for the abstract keyword in the definition if it is defined. default is false.</param>
        /// <returns>Fully formatted event definition or null if the event data could not be generated.</returns>
        public static string FormatCSharpDeclarationSyntax(this IDotNetMethod source, bool includeSecurity = true,
            bool includeAttributes = true, bool includeKeywords = true ,bool includeAbstractKeyword = false)
        {
            if (source == null) return null;

            StringBuilder methodFormatting = new StringBuilder();

            if (includeAttributes & source.HasAttributes)
            {
                foreach (var sourceAttribute in source.Attributes)
                {
                    methodFormatting.AppendLine(sourceAttribute.FormatCSharpAttributeSignatureSyntax());
                }
            }

            if (includeSecurity)
            {
                methodFormatting.Append($"{source.Security.FormatCSharpSyntax()} ");
            }

            if (includeKeywords)
            {
                if (source.IsStatic) methodFormatting.Append($"{Keywords.Static} ");
                if (source.IsSealed) methodFormatting.Append($"{Keywords.Sealed} ");
                if (includeAbstractKeyword & source.IsAbstract) methodFormatting.Append($"{Keywords.Abstract} ");
                if (source.IsOverride) methodFormatting.Append($"{Keywords.Override} ");
                if (source.IsVirtual) methodFormatting.Append($"{Keywords.Virtual} ");
            }
            
            methodFormatting.Append(source.IsVoid ? $"{Keywords.Void} {source.Name}" : $"{source.ReturnType.FormatCSharpFullTypeName()} {source.Name}");
            if (source.IsGeneric)
                methodFormatting.Append($"{source.GenericParameters.FormatCSharpGenericSignatureSyntax()}");

            methodFormatting.Append(source.HasParameters
                ? source.Parameters.FormatCSharpParametersSignatureSyntax()
                : $"{Symbols.ParametersDefinitionStart}{Symbols.ParametersDefinitionEnd}");

            if (source.IsGeneric)
            {
                foreach (var sourceGenericParameter in source.GenericParameters)
                {
                    var whereClause = sourceGenericParameter.FormatCSharpGenericWhereClauseSyntax();

                    if (!string.IsNullOrEmpty(whereClause)) methodFormatting.Append($" {whereClause}");
                }

            }

            return methodFormatting.ToString();

        }

        /// <summary>
        /// Gets the hash code for a formatted method signature using the C# format.
        /// </summary>
        /// <param name="source">The sources <see cref="IDotNetMethod"/> model.</param>
        /// <param name="includeSecurity">Optional parameter that determines to generate security in the definition. By default this is false.</param>
        /// <param name="includeAttributes">Optional parameter that determines if the attributes should be included in the definition. By default this is false.</param>
        /// <param name="includeKeywords">Optional parameter that determines if all keywords are included in the definition. By default this is false.</param>
        /// <returns>The hash code of the formatted model.</returns>
        /// <exception cref="ArgumentNullException">This is thrown if the  model is null.</exception>
        public static int FormatCSharpComparisonHashCode(this IDotNetMethod source, bool includeSecurity = false,
            bool includeAttributes = false, bool includeKeywords = false)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return source.FormatCSharpDeclarationSyntax(includeSecurity, includeAttributes, includeKeywords).GetHashCode();
        }

    }
}
