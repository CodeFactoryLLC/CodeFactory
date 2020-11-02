# CodeFactory™

# What is CodeFactory?

In the simplest terms, CodeFactory is a real time software factory that is triggered from inside Visual Studio during the design and construction of software.
CodeFactory allows for development staff to automate repetitive development tasks that take up developer’s time. 

## What is a Real Time Software Factory?
A real time software factory is automation that can be triggered when ever requested and replace only target content within the solution. 
By not requiring complete regeneration of the entire file or process, you can do continuous real time management through automation. 

## What Can I Automate?
Anything you base on a set of demonstrated repeatable steps can be turned into an automation. 
The following are the basic criteria for automation.

### Data Sources
How information is collected and provided to the automation process to execute. 
The following are common data sources used in automation:

#### CodeFactory Data Models 
CodeFactory provided data about the Visual Studio environment. The following are the common types of models CodeFactory provides:
 - Solution Data
 - Project Data
 - Project Folder Data
 - Project File Data
 - Full C# Source Code Models from Code Files
 
#### Collection of Information from the Developer
A number of times we may need to get information directly from the developer in order for the automation to execute correctly. 
CodeFactory provides direct access to creating custom user interface screens that display information as if they were Visual Studio dialogs. 

#### Usage of 3rd Party Libraries

CodeFactory allows direct access to the entire .NET framework, this allows for automation to use other third-party libraries to gather information. 
The following are some common examples of usage scenarios for collecting data:
 - Third party library to parse HTML files
 - Third party library to read in a target file format (markdown, yaml, json)
 - ADO.NET calls to a database to read out information used in the automation process

### Automation Logic
CodeFactory uses an event driven model for processing automation requests from Visual Studio. 
These events are called "commands" and once commands are executed the automation logic is managed directly in the native .NET framework C# programming language.
Your logic is directly executed to run the expected functionality to build the output identified from the data you provided.

Part of the automation process is providing common helper-based functionality to handle common automation Tasks. 
CodeFactory has a number of helpers built into the SDK to help with common activities found inside code automation.

### Automation Formatting
A key part of any software factory automation is formatting the final data into a target format expected to be added back into your project or solution in Visual Studio.
CodeFactory provides direct access to the T4 templating engine hosted inside Visual Studio. This allows you to build up formatted output regardless of the target language or format needed.

### Automation Output
The final step in any automation process is output of the process itself. The following are common outputs from CodeFactory:

#### Document Creation with Content
CodeFactory allows for the creation of a new document either at the project level or the solution level. During the creation of the document the content is directly added at time of creation.

#### Positional Based Content Management
CodeFactory provides access to solution and project documents and allows you to update the content of documents based on the position within the document. This includes the following scenarios:
 - Remove content by position
 - Replace content by position
 - Add content before position
 - Add content after position

#### C# Artifact Based Content Management
CodeFactory give you direct access to update content within C# code files. This includes the following scenarios:
 - Add content in the beginning of a class, structure, or interface definition
 - Add content at the end of a class, structure, or interface definition. 
 - Add a class, structure, or interface to a code file
 - Remove a class, structure, or interface to a code file
 - Remove a member (field, property, event, or method)
 - Replace a member (field, property, event, or method) with updated content.
 - Add content before a member (field, property, event, or method)
 - Add content after a member (field, property, event, or method)
