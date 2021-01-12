//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using CodeFactory.SourceCode;


namespace CodeFactory.DotNet
{
    /// <summary>
    /// Base implementation all dot net models must implement.
    /// </summary>
    public interface IDotNetModel:IModelStatus
    {
        /// <summary>
        /// Flag that determines if this model was loaded from source code or was loaded through reflects or symbol libraries.
        /// </summary>
        bool LoadedFromSource { get; }

        /// <summary>
        /// The target language this model was loaded from.
        /// </summary>
        SourceCodeType Language { get; }

        /// <summary>
        /// The type of dot net model that was loaded.
        /// </summary>
        DotNetModelType ModelType { get; }

        /// <summary>
        /// The fully qualified path to the document that was used to load the model from source. This will be populated if the model was loaded from source.
        /// </summary>
        string SourceDocument { get; }
    }
}
