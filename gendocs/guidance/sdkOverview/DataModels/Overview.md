# CodeFactory Data Models
The primary strength of CodeFactory is its ability to generate real time data models directly from your project/solution artifacts within the Visual Studio IDE. 
This ability makes it possible to do design-time automation when delivering software. In this section we will provide a brief overview of the data models that are generated dynamically by the CodeFactory platform. These data models are used throughout the automation process.

## Data Models
All data models are "plain old CLR objects" or POCO's for short. Each data model is implemented as an immutable data class. This approach is used since a change to the underlying data model requires a complete regeneration of the data model from the Visual Studio environment to make sure you have the latest version of all data.  For example, making a change to a C# class object would force CodeFactory to regenerate a data model of that file/class object.

Data model generation is either triggered during the execution of a new automation process, or from various CodeFactory API calls that will request new copies of data models.

## Solution Explorer Models (Project System)
The following models are directly generated off the legacy and new project systems that are hosted by Visual Studio.
The overview of each data model is designed to provide an overview of capabilties. The examples here are not complete and only reflect partial functionality for the purpose of explanation.  Please see our help docs for the full description of each data model.

### Solution
Data model that represents the loaded solution. This provides the location of the solution as well as access to the projects within the solution.

### Solution Folder
Data model that represents a virtual folder that is at scope of the solution level. This provides acess to the name of the folder and the children objects which are hosted within this folder.

### Project
Data model that represents a loaded project that is managed in the solution. This provides access to the project location and name, and access to all children objects hosted in the project.

### Project Reference
Data model that represents a reference to a project hosted within the solution. This provides the name of the reference and the target artifact that is being referenced.

### Project Folder
Project folder model represents a folder under a target project. This will contain the path and name of the folder and the list of child objects which are managed under this project folder.

### Document
Document model represents a file which is hosted within a project, project folder, or solution folder. This will contain the path and the name of the file, as well as access to the full contents of the document itself. 

### C# Source Document
C# Source Document provides project system access, as well as full access to the C# source code which is hosted within the document itself. 

## C# Language Models - (Source Code)
CodeFactory has access to the C# language compiler and can dynamically generate data models that represent the C#-based source code. 
CodeFactory provides direct access all the way down to member and type level data. 
In addition, CodeFactory will provide direct access to the raw source code at the target object level. 
The following data models are auto-generated whenever accessing  source code files or directly referenced assemblies. 
The overview of each data model is designed to provide an example of capabilties and does not list every single data element or function. Please see our help docs for the full description of each data model.

### Source Code
The Source Code model provides access to all elements that were compiled from the source code document. This includes the following:
 - Namespaces
 - Using Statements
 - Classes
 - Interfaces
 - Structures

### Using Statement
Using Statement model provides information on targeted namespaces to use in the code base. This includes the following:
 - Namespace
 - Alias

### Namespace Statement
Namespace model provides the target namespace that other C# code elements are contained in. 

### Attribute
Attribute provides a data model of the type of attribute and parameters which have been assigned to the attribute. This includes the following:
 - Name
 - Namespace
 - Named Parameters
 - Constructor Parameters

### Attribute Parameter
Data model that provides the data for a target parameter on an attribute. This includes the following:
 - Name (Optional)
 - Parameter values

### Attribute Parameter Value
Data model that provides a target value that is assigned to an attribute parameter.

### Enum
Enum data model provides the definition of an enumeration and the target values of the enumeration.

### Class
The Class data model provides data on a target class hosted in source code. This will include the following:
 - Attributes
 - Name
 - Namespace
 - Security Scope
 - Keywords
 - Inheritence (Base class and Interfaces)
 - Members (Events, Fields, Methods, Properties)
 
### Interface
The Interface data model provides data on the target interface definition in source code. This will include the following:
 - Attributes
 - Name
 - Namespace
 - Security Scope
 - Keywords
 - Inheritence (Interfaces)
 - Members (Events, Methods, Properties)
 

### Structure
The Structure data model provides data on the target structure definition in source code. This will include the following:
 - Attributes
 - Name
 - Namespace
 - Security Scope
 - Keywords
 - Inheritence (Interfaces)
 - Members (Events, Fields, Methods, Properties)
 
### Delegate
The Delegate model provides data on the definition of a delegate in source code. This will include the following:
- Name
- Namespace
- Parameters
- Return type

### Event 
The Event data model provides data on the definition of an event in source code. This will include the following:
 - Attributes
 - Name
 - Type
 - Security Scope
 - Keywords
 - EventHandlerMethod Definition
 
### Field
The Field data model provides data on the definition of a field in source code. This will include the following:

 - Attributes
 - Name
 - Type
 - Security Scope
 - Keywords
 - Assigned value
 
### Method
The Method data model provides data on the definition of a method in source code. This will include the following:
 - Attributes
 - Name
 - Security Scope
 - Keywords
 - Parameters
 - Return Type
 - Method Type

### Property
The Property data model provides data on the definition of a property in source code. This will include the following:
 - Attributes
 - Name
 - Type
 - Property Security
 - Keywords
 - Has Get
 - Get Security
 - Has Set
 - Set Security

### Parameter
The Parameter data model provides data on the definition of a parameter in a method or a delegate. This will include the following:
 - Attributes
 - Name
 - Keywords
 - Default value
 
### Type
 The Type data model provides information about a type that is used in all the above source code definitions. This will include the following:
 - Name
 - Namespace
 - IsValueType
 - IsTuple
 - IsEnum
 - IsArray
 - IsClass
 - IsInterface
 - IsStructure

## Overview 
This link takes you back to the CodeFactory Overview

[CodeFactory Overview](../Overview.md)


