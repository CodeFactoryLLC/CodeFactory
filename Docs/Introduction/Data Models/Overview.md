# CodeFactory DataModels
The primary strength of CodeFactory is its ability to generate real time data models directly from the Visual Studio environment. 
This ability makes it possible to do design time automation when delivering software. In this section we will provide a brief overview of the data models that are generated dynamically by the CodeFactory platform. These data models are used throughout the automation process.

## Data Models
All data models are plain old CLR objects or POCO's for short. Each data model is implemented as an immutable data class. This approach is used since an change to the underlying data model requires a complete regeneration of the data model from the visual studio environment to make sure you have the latest version of all data.

Data model generation is either triggered during the trigger of a new automation process, or from various CodeFactory API calls that will request new copies of data models.


## Solution Explorer Models (Project System)
The following models are directly generated off the legacy and new project systems that are hosted by Visual Studio.
The overview of each data model is designed to provide an overview of capabilties. It will not list every single data element or function. See help docs for the full description if each data model.

### Solution
Data model that represents the loaded solution. This provides the location of the solution as well as access to the projects in the solution.

### Solution Folder
Data model that represents a virtual folder that is at scope of the solution level. This provides acess to the name of the folder and the children that are hosted in this folder.

### Project
Data model that represents a loaded project that is managed in the solution. this provides access to the project location and name, and access to all children objects hosted in the project.

### Project Reference
Data model that represents a reference to a project hosted in the solution. This provides the name of the reference and the target artifact that is being referenced.

### Project Folder
The project folder model represents a folder under a target project. This will contain the path and name of the folder and the list of child objects that are managed under this project folder.

### Document
Model that represents a file that is hosted in a project, project folder, or solution folder. This will contain the path and the name of the file. As well as access to the full contents in the document itself. 

### C# Source Document
The C# source document project system access as well as full access to the C# source code that is hosted in the document itself. 

## C# Language Models - (Source Code)
CodeFactory has access to the C# language compiler and can dynamically generate data models the represent the C# based source code. 
CodeFactory provides direct access all the way down to member and type level data. 
In addition, will give you direct access to the raw source code at the target object level. 
The following are the data models that are generated whenever either accessing from source code files, or from directly referenced assemblies. 
The overview of each data model is designed to provide an overview of capabilties. It will not list every single data element or function. See help docs for the full description if each data model.

### Soure Code
The source code data model provides access to all elements that were compiled from the source code document. This includes the following.
 - Namespaces
 - Using Statements
 - Classes
 - Interfaces
 - Structures

### Using Statement
Using statement provides information on target namespaces to use in the code base. This includes the following.
 - Namespace
 - Alias

### Namespace Statement
Namespace model provides the target namespace that other c# code elements are contained in. 

### Attribute
Attribute provides a data model of the type of the attribute and the parameters that have been assigned to the attribute. This includes the following
 - Name
 - Namespace
 - Named Parameters
 - Constructor Parameters

### Attribute Parameter
Data model that provides the data for a target parameter on an attribute. This includes the following.
 - Name (Optional)
 - Parameter values

### Attribute Parameter Value
Data model that provides a target value that is assigned to an attribute parameter.

### Enum
Enum data model provides the definition of an enumeration and the target values of the enumeration.

### Class
The Class data model provides data on a target class hosted in source code. This will include the following.
 - Attributes
 - Name
 - Namespace
 - Security Scope
 - Keywords
 - Inheritence (Base class and Interfaces)
 - Members (Events, Fields, Methods, Properties)
 
### Interface
The Interface data model provides data on the target interface definition in source code. This will include the following.
 - Attributes
 - Name
 - Namespace
 - Security Scope
 - Keywords
 - Inheritence (Interfaces)
 - Members (Events, Methods, Properties)
 

### Structure
The structure data model provides data on the target structure definition in source code. This will include the following.
 - Attributes
 - Name
 - Namespace
 - Security Scope
 - Keywords
 - Inheritence (Interfaces)
 - Members (Events, Fields, Methods, Properties)
 
### Delegate
The delegate model provides data on the definition of a delegate in source code. This will include the following.
- Name
- Namespace
- Parameters
- Return type

### Event 
The event data model provides data on the definition of an event in source code. This will include the following.
 - Attributes
 - Name
 - Type
 - Security Scope
 - Keywords
 - EventHandlerMethod Definition
 
### Field
The field data model provides data on the definition of a field in source code. This will include the following.

 - Attributes
 - Name
 - Type
 - Security Scope
 - Keywords
 - Assigned value
 
### Method
The method data model provides data on the definition of a method in source code. This will include the following.
 - Attributes
 - Name
 - Security Scope
 - Keywords
 - Parameters
 - Return Type
 - Method Type

### Property
The property data model provides data on the definition of a property in source code. This will include the following.
 - Attributes
 - Name
 - Type
 - Propery Security
 - Keywords
 - Has Get
 - Get Security
 - Has Set
 - Set Security

### Parameter
The Parameter data model provides data on the definition of a parameter in a method or a delegate. This will include the following.
 - Attributes
 - Name
 - Keywords
 - Default value
 
### Type
 The type datamodel provides information about a type that is used in all the above source code definition. This will include the following.
 - Name
 - Namespace
 - IsValueType
 - IsTuple
 - IsEnum
 - IsArray
 - IsClass
 - IsInterface
 - IsStructure

[Link Here] - Return to Overview


