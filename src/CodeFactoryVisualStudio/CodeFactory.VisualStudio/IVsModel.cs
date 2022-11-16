//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Base contract definition all Visual Studio Models are based on.
    /// </summary>
    public interface IVsModel:IModel<VisualStudioModelType>
    {
        /// <summary>
        /// The name of the visual studio model.
        /// </summary>
        string Name { get; }

    }
}
