//*****************************************************************************
//* Code Factory SDK
//* Copyright (c) 2020 CodeFactory, LLC
//*****************************************************************************
using System.Threading.Tasks;

namespace CodeFactory.VisualStudio
{
    /// <summary>
    /// Extensions class that provides common automation tasks rolled up under standard extension methods that support the <see cref="VsCSharpSource"/> model.
    /// </summary>
    public static class VsCSharpSourceExtensions
    {
        /// <summary>
        /// Extension method that loads the hosting project for the <see cref="VsCSharpSource"/> document. 
        /// </summary>
        /// <param name="source">Target document to load the parent from.</param>
        /// <returns>The project model or null if the project could not be loaded.</returns>
        public static async Task<VsProject> GetHostingProjectAsync(this VsCSharpSource source)
        {
            //Bounds check if no instance of the model is provided returning null.
            if (source == null) return null;

            //Loading the project system version of the document.
            var document = await source.LoadDocumentModelAsync();

            //If the project system version of the document could not be loaded then return null.
            if (document == null) return null;

            //Models to store information about lookup results.
            VsProject result = null;
            VsModel currentModel = document;

            while (result == null)
            {
                //Confirming a model was returned otherwise there is no parent project to return, so break out of the while loop.
                if (currentModel == null) break;

                switch (currentModel.ModelType)
                {
                    //switching between each standard model types. loading model data.
                    case VisualStudioModelType.Project:
                        result = currentModel as VsProject;

                        break;

                    case VisualStudioModelType.ProjectFolder:

                        currentModel = currentModel is VsProjectFolder projectFolder ? await projectFolder.GetParentAsync() : null;
                        break;

                    case VisualStudioModelType.Document:

                        currentModel = currentModel is VsDocument documentModel ? await documentModel.GetParentAsync() : null;
                        break;

                    default:
                        currentModel = null;
                        break;

                }

            }

            return result;
        }

    }

}
