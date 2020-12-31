# Actions
Actions are a series of API calls that perform IDE specific functionality. CodeFactory is reponsible for the heavy lifting of all integration with the IDE. These calls are used during the automation process as well as the final output back into the IDE itself. 

## Visual Studio Actions
The core actions within CodeFactory today directly interop with Visual Studio itself. Visual Studio actions are accessible at two different levels within the SDK. CodeFactory data models have direct links to Visual Studio actions that directly impact the target data model. At the command level there is direct access to all Visual Studio actions by calling the property VisualStudioActions.
The following provides a high level summary of the actions that are avaliable at diffrent levels of the CodeFactory platform.

### Project System Actions
The following are the target actions that are avaliable at the project system level of Visual Studio.

#### Solution Actions
These actions are directly executed at the solution level.
 - GetSolutionAsync - Loads the current solution data model
 - CreateSolutionFolderAsync - Creates a new solution folder
 - GetChildrenAsync - Gets all Visual Studio models hosted under the solution
 - GetProjectsAsync - Gets all project data models hosted by the solution

#### Solution Folder Actions
These actions are directly executed at the solution folder level.

 - AddDocumentAsync - Creates a new document data model and assigns it to the solution folder
 - AddExitingDocumentAsync - Adds an existing document to the target solution folder
 - AddSolutionFolder - Adds a solution folder under the current solution folder
 - GetChildrenAsync - Gets all Visul Studio models that are children of this solution folder
 - GetParentAsync - Gets the parent Visual Studio model for this solution folder
 - Remove - Removes the solution folder from the solution

#### Project Actions
These actions are directly executed at the project level.

 - AddDocumentAsync - Creates a new document and assigns it to the root of the project
 - AddExistingDocumentAsync - Adds an executing document to the root of the project
 - AddProjectFolderAsync - Creates a new project folder under the root of the project
 - GetChildrenAsync - Gets the Visual Studio models that are children of the project
 - GetParentAsync - Gets the Visual Studio model that is the parent to this project
 - GetReferencedProjects - Gets the project data models that are referenced by this project
 - GetReferencesAsync - Genereates the full list of Project Reference data models that support this project

#### Project Reference Actions
These actions are directly executed at the project reference level.

 - GetReferencedProjectAsync - Loads the Project data model the project reference is from
 
#### Project Folder Actions
These actions are directly executed at the project folder level.

 - AddDocumentAsync - Creates a new document and adds it to the project folder
 - AddExistingDocumentAsync - Adds an existing document already in the project folder
 - AddProjectFolderAsync - Adds a new project folder that is a child of the current project folder
 - DeleteAsync - Deletes the project folder and all files under the project folder
 - GetCSharpNamespaceAsync - Generates the namespace definition from the project root to the project folder location
 - GetChildrenAsync - Gets all Visual Studio models that are children of this project folder
 - GetParentAsync - Get the parent Visual Studio model of this project folder
 - RemoveAsync - Removes the project folder from the project but does not remove it from the file system

#### Document Actions
These actions are directly exected at the document level.

 - AddContentAsync - Adds content to a document starting at a target line number and character position
 - AddContentToBeginningAsync - Adds content at the beginning of the document
 - AddContentToEndAsync - Adds content at the end of the document
 - DeleteAsync - Deletes the document from the hosting solution or project and from the file system
 - GetCSharpSourceModelAsync - If the document is a C# document will load the C# sourcecode model from the document
 - GetChildrenAsync - Builds document models for all documents that are children of this document
 - GetDocumentContentAsContentAsync - Will return the content of the document as a content data model
 - GetDocumentContentAsStringAsync - Will return the content of the document as a string
 - GetParentAsync - Will get the parent Visual Studio model for this document
 - RemoveAsync - Will remove the document from the hosting solution or project but will keep it on the file system
 - RemoveContentAsync - Will remove all content from the document

#### Source Actions
These actions are directly executed at the C# document level
 - LoadDocumentFromSourceAsync - Loads a document model from the c# source document

#### User model Actions
These actions are directly related to creating and executed customer user models that are hosted in Visual Studio.

 - CreateVsUserControlAsync - Generic method that creates a new instance of a visual studio user control
 - ShowDialogWindowAsync - Displays the target user control in the Visual Studio IDE

## C# Actions
The following actions are directly tied to the C# data models. The implementation of these actions are specific to IDE, but do not change from one IDE to another.

### Container Actions
Container actions focus on actions that occur at the model, model, and structure model levels.

#### Class Actions
The following actions occur at the class model level.

 - AddAfterAsync - Add code syntax after the model definition
 - AddBeforeAsync - Add code syntax before the model definition
 - AddToBeginningAsync - Add code syntax to beginning of the body of the model definition
 - AddToEndAsync - Add code syntax to the end of the body of the model definition
 - DeleteAsync - Delete the model definition
 - GetBodySourceLocationAsync - Get the document coordinates where the body starts and ends
 - GetBodySyntaxAsync - Get the raw syntax within the body
 - GetSourceLocationAsync - Get the full model definitions document coordiants where it starts and ends
 - ReplaceAsync - Replaces the entire definition of the model with the provided syntax

#### Interface Actions
The following actions occur at the interface model level.

 - AddAfterAsync - Add code syntax after the model definition
 - AddBeforeAsync - Add code syntax before the model definition
 - AddToBeginningAsync - Add code syntax to beginning of the body of the model definition
 - AddToEndAsync - Add code syntax to the end of the body of the model definition
 - DeleteAsync - Delete the model definition
 - GetBodySourceLocationAsync - Get the document coordinates where the body starts and ends
 - GetBodySyntaxAsync - Get the raw syntax within the body
 - GetSourceLocationAsync - Get the full model definitions document coordiants where it starts and ends
 - ReplaceAsync - Replaces the entire definition of the model with the provided syntax

#### Structure Actions
The following actions occur at the structure model level.

 - AddAfterAsync - Add code syntax after the model definition
 - AddBeforeAsync - Add code syntax before the model definition
 - AddToBeginningAsync - Add code syntax to beginning of the body of the model definition
 - AddToEndAsync - Add code syntax to the end of the body of the model definition
 - DeleteAsync - Delete the model definition
 - GetBodySourceLocationAsync - Get the document coordinates where the body starts and ends
 - GetBodySyntaxAsync - Get the raw syntax within the body
 - GetSourceLocationAsync - Get the full model definitions document coordiants where it starts and ends
 - ReplaceAsync - Replaces the entire definition of the model with the provided syntax

### Member Actions
Member actions focus on actions that occur at the event, field, method, property levels.

#### Event Actions
The following actions occur at the event model level.

 - AddAfterAsync - Adds the syntax after the model definition
 - AddBeforeAsync - Adds the syntax before the model defintion
 - DeleteAsync - Deletes the model
 - GetSourceLocationAsync - Gets the document coordinates where the model starts and ends
 - ReplaceAsync - Replaces the model with the provided syntax

#### Field Actions
The following actions occur at the field model level.

 - AddAfterAsync - Adds the syntax after the model definition
 - AddBeforeAsync - Adds the syntax before the model defintion
 - DeleteAsync - Deletes the model
 - GetSourceLocationAsync - Gets the document coordinates where the model starts and ends
 - ReplaceAsync - Replaces the model with the provided syntax

#### Method Actions
The following actions occur at the method model level.
 
 - AddAfterAsync - Adds the syntax after the model definition
 - AddBeforeAsync - Adds the syntax before the model defintion
 - DeleteAsync - Deletes the model
 - GetBodySyntaxAsync - Gets the syntax from the body of the model. 
 - GetSourceLocationAsync - Gets the document coordinates where the model starts and ends
 - ReplaceAsync - Replaces the model with the provided syntax

#### Property Actions
The following actions occur at the property model level.

 - AddAfterAsync - Adds the syntax after the model definition
 - AddBeforeAsync - Adds the syntax before the model defintion
 - DeleteAsync - Deletes the model
 - GetSourceLocationAsync - Gets the document coordinates where the model starts and ends
 - LoadGetBodySyntaxAsync - Gets the body syntax from the properties get statement
 - LoadSetBodySyntaxAsync - Gets the body syntax from the properties set statement
 - ReplaceAsync - Replaces the model with the provided syntax

### Other C# Models with Actions
The following are other C# models that also have direct actions.

#### Using Statement Actions
The following actions apply to the using statement model level.

 - AddAfterAsync - Adds the syntax after the model definition
 - AddBeforeAsync - Adds the syntax before the model defintion
 - DeleteAsync - Deletes the model
 - GetSourceLocationAsync - Gets the document coordinates where the model starts and ends
 - ReplaceAsync - Replaces the model with the provided syntax

#### Attribute Actions
The following actions apply to the attribute model level.

 - AddAfterAsync - Adds the syntax after the model definition
 - AddBeforeAsync - Adds the syntax before the model defintion
 - DeleteAsync - Deletes the model
 - GetSourceLocationAsync - Gets the document coordinates where the model starts and ends
 - ReplaceAsync - Replaces the model with the provided syntax
