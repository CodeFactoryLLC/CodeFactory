//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************

namespace CodeFactory.VisualStudio
{
    public interface IVsModel:IModel<VisualStudioModelType>
    {
        /// <summary>
        /// The name of the visual studio model.
        /// </summary>
        string Name { get; }

    }
}
