//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.Document;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeFactory.DotNet.CSharp
{
    /// <summary>
    /// Model definition of a method in c#.
    /// </summary>
    public interface ICsMethod:ICsMember,ICsGeneric,IDotNetMethod
    {
        /// <summary>
        /// Determines the type of method that was loaded into this model.
        /// </summary>
        new CsMethodType MethodType { get; }

        /// <summary>
        ///     The type information about the return type assigned to the method. if flag <see cref="IDotNetMethod.IsVoid"/> is true then the return type will be set to null.
        /// </summary>
        new CsType ReturnType { get; }

        /// <summary>
        ///     Enumeration of the parameters that have been assigned to the method. If HasParameters property is set to false this will be null.
        /// </summary>
        new IReadOnlyList<CsParameter> Parameters { get; }

        /// <summary>
        /// Adds the source code to the beginning of the method body. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the method body.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> AddToBeginningBodySyntaxAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code to the beginning of the method body. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the method body.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> AddToBeginningBodySyntaxAsync(string sourceCode);

        /// <summary>
        /// Adds the source code to the end of the method body. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be added to the method body.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> AddToEndBodySyntaxAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Adds the source code to the end of the method body. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be added to the method body.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> AddToEndBodySyntaxAsync(string sourceCode);

        /// <summary>
        /// Deletes the source syntax from the method body. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> DeleteBodySyntaxAsync(string sourceDocument);

        /// <summary>
        /// Deletes the source syntax from the method body. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> DeleteBodySyntaxAsync();

        /// <summary>
        /// Replaces the syntax in the body of the method. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the body of the method.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> ReplaceBodySyntaxAsync(string sourceDocument, string sourceCode);

        /// <summary>
        /// Replaces the syntax in the body of the method. The ContentSyntax must be set to Body or else an exception will be thrown.
        /// </summary>
        /// <param name="sourceCode">The source code that is to be used to replace the original definition in the document.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> ReplaceBodySyntaxAsync(string sourceCode);

        /// <summary>
        /// Replaces the expression assigned to the method with the provided source code. The ContentSyntax must be set to Expression or else an exception will be thrown. 
        /// </summary>
        /// <param name="sourceCode">The source code that will replace the original expression.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> ReplaceExpressionAsync(string sourceCode);

        /// <summary>
        /// Replaces the expression assigned to the method with the provided source code. The ContentSyntax must be set to Expression or else an exception will be thrown. 
        /// </summary>
        /// <param name="sourceCode">The source code that will replace the original expression.</param>
        /// <param name="sourceDocument">The fully qualified path to the source code document to be updated.</param>
        /// <returns>A newly loaded copy of the <see cref="ICsSource"/> model after the changes have been applied.</returns>
        /// <exception cref="DocumentException">Error is raised when errors occur updating the source document.</exception>
        /// <exception cref="CodeFactoryException">Error is raised if the incorrect ContentSyntax is present.</exception>
        Task<CsSource> ReplaceExpressionAsync(string sourceDocument, string sourceCode);
    }
}
