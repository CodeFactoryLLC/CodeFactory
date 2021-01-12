//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.DotNet
{
    /// <summary>
    /// A namespace that is being referenced by dot net source code. This will determine which external library resources will be available in the source control document.
    /// </summary>
    public interface IDotNetNamespaceReference:IDotNetModel,IParent,ILookup
    {
        /// <summary>
        /// The target namespace that is being imported into the sources scope.
        /// </summary>
        string ReferenceNamespace { get; }

        /// <summary>
        /// Flag that determines if the namespace reference has an alias.
        /// </summary>
        bool HasAlias { get; }

        /// <summary>
        /// The alias assigned to the namespace being imported. This will be null if the <see cref="HasAlias"/> is false. 
        /// </summary>
        string Alias { get; }

    }
}
