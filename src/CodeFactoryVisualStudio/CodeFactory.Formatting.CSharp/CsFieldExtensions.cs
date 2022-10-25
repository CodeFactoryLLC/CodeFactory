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
    /// Extensions class that manage extensions that support CodeFactory models that implement the <see cref="CsField"/> model.
    /// </summary>
    public static class CsFieldExtensions
    {
        /// <summary>
        /// Generates the syntax definition of field in c# syntax. The default definition with all options turned off will return the filed signature and constants if defined and the default values.
        /// </summary>
        /// <example>
        /// With Keywords [Security] [Keywords] [FieldType] [Name];
        /// With Keywords and a constant [Security] [Keywords] [FieldType] [Name] = [Constant Value];
        /// Without Keywords [Security] [FieldType] [Name];
        /// Without Keywords and a constant [Security] [FieldType] [Name] = [Constant Value];
        /// </example>
        /// <param name="source">The source <see cref="CsField"/> model to generate.</param>
        /// <param name="manager">Namespace manager used to format type names.This is an optional parameter.</param>
        /// <param name="includeKeywords">Optional parameter that will include all keywords assigned to the field from the source model. This is true by default.</param>
        /// <param name="fieldSecurity">Optional parameter to set the target security for the field.</param>
        /// <returns>Fully formatted field definition or null if the field data could not be generated.</returns>
        public static string CSharpFormatFieldDeclaration(this CsField source,NamespaceManager manager = null,
            bool includeKeywords = true, CsSecurity fieldSecurity = CsSecurity.Unknown)

        {
            if (source == null) return null;

            StringBuilder fieldFormatting = new StringBuilder();


            CsSecurity security = fieldSecurity == CsSecurity.Unknown ? source.Security : fieldSecurity;

            fieldFormatting.Append($"{security.CSharpFormatKeyword()} ");
            
            if (includeKeywords)
            {
                if (source.IsStatic) fieldFormatting.Append($"{Keywords.Static} ");
                if (source.IsReadOnly) fieldFormatting.Append($"{Keywords.Readonly} ");
            }

            if (source.IsConstant) fieldFormatting.Append($"{Keywords.Constant} ");
            fieldFormatting.Append($"{source.DataType.CSharpFormatTypeName(manager)} ");
            fieldFormatting.Append($"{source.Name}");
            if (source.IsConstant) fieldFormatting.Append($" = {source.DataType.CSharpFormatValueSyntax(source.ConstantValue)}");
            fieldFormatting.Append(";");

            return fieldFormatting.ToString();
        }
    }
}
