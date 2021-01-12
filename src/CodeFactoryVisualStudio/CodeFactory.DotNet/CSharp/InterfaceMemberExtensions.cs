//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

using System.Text;


namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Extensions class that provides helper methods for implementation of member functions.
    /// </summary>
    public static class InterfaceMemberExtensions
    {
        /// <summary>
        /// Create a fully formatted method signature that also supports implementation of Async Await formatting.
        ///  </summary>
        ///  <param name="methodData">The method data used to build the signature</param>
        /// <param name="supportAsyncKeyword">Optional parameter that determines if the async keyword will be added to the method signature. Default is true.</param>
        /// <returns>Fully formatted method signature for a method implementation from an interface assignment.</returns>
        public static string FormatInterfaceImplementationSignature(this CsMethod methodData, bool supportAsyncKeyword = true)
        {

            if (methodData == null) return null;

            bool isAsyncReturn = false;

            bool isVoid = methodData.IsVoid;
            if (!isVoid)
            {
                isAsyncReturn = methodData.IsAsync;
                if (!isAsyncReturn) isAsyncReturn = methodData.ReturnType.Name == "Task";
                if (!isAsyncReturn) isAsyncReturn = methodData.ReturnType.Name.StartsWith("Task<");
            }
            StringBuilder methodSignature = new StringBuilder($"{methodData.Security.FormatCSharpSyntax()} ");

            if (isVoid) methodSignature.Append($"{CodeFactory.DotNet.CSharp.FormattedSyntax.Keywords.Void} ");
            else
            {
                if (isAsyncReturn & supportAsyncKeyword) methodSignature.Append($"{CodeFactory.DotNet.CSharp.FormattedSyntax.CommonContextualKeywords.Async} ");
                methodSignature.Append($"{methodData.ReturnType.FormatCSharpFullTypeName()} ");
            }
            methodSignature.Append(methodData.Name);
            if (methodData.IsGeneric) methodSignature.Append(methodData.GenericParameters.FormatCSharpGenericSignatureSyntax());
            methodSignature.Append(methodData.HasParameters ? methodData.Parameters.FormatCSharpParametersSignatureSyntax() : "()");

            return methodSignature.ToString();
        }

    }
}
