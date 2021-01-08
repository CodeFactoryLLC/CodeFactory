# Source Formatting
One of the core strengths of CodeFactory is how it manages injection of source code. CodeFactory focuses on taking advantage of the capabilities of the IDE that it integrates into. 
This allows for flexibility in managing the creation and formatting of source code. 
This section is focused on the goals for formatting and how to accomplish those goals.

## Language Agnostic Formatting
One of the core goals of CodeFactory is to allow for the usage of data models to define any type of output source code.
With this in mind, formatting is agnostic by design. 
You can read in data models and output any target language or markup of your choice. 
The SDK is designed to allow for this flexibility. 
Additionally, extension libraries have been created to assist in formatting and generation of alternate language outputs. 

## Document Driven Updates
The CodeFactory platform controls removal, replacement, and injection of source code changes through a document-driven approach. 
This provides for the greatest flexibility with source code management. Keep in mind that CodeFactory runs as part of Visual Studio itself.
If a delivery team does not like the provided source formatting tools, they are able to use any tooling they wish. 
If the tooling can be called as an external executable or accessed from c# in the .NET framework, it can be used with CodeFactory.


## Model Based Meta Data
CodeFactory focuses on the auto-generation of model based data to be used with software factories in the generation of additional logic. 
CodeFactory provides the following data model categories to be used with source formatting:


### Project Models
Project models build up meta data about the solution, project, folders and documents in Visual Studio. 
These models are directly accessed and in some cases used to drive source formatting.


### Source Code Models - (C# Language)
Source models generate full information from the source code file through all the elements down to the member level in C#. 
This model data allows developers to use that data and output into any target langauge or format that fits the need of the problem they are solving. 


## External Examples Used With Source Formatting
As mentioned above, since CodeFactory runs within the Visual Studio process. 
This allows users to access any framework or third party libraries that also provide model generation and utilize them within the scope of CodeFactory. 
The following are two examples we have already used to solve automation problems:


### HTML Agility Pack
As part of our WebForms to Blazor project we needed a way to load up HTML into a data model and build markup transformations based on the provided HTML data. 
We used the HTML Agility Pack to read in the HTML data as POCO data classes. 
From there, we were able to use an adapter pattern to read and transform into Blazor based markup. 
Using CodeFactories built-in tools to format the source code then inject back into documents.


### .Net Framework ADO.NET
We needed the ability to read database schemas from a database in order to generate and update entities as well as repositories and service classes. 
To do this we used the built-in functionality of ADO that is included in the .NET Framework to read the schema and auto-generate POCO models to be used within automation.


## CodeFactory Formatters
Included in CodeFactory are two different source code formatting tools. 
Both tools are designed to output the formatted source code to be used with the document driven placement approach used in CodeFactory. 
Both formatting solutions are not tied to any target language or markup format. 


### T4 Source Factory - Provided Formatter
The T4 formatting tool that is provided with Visual Studio is fully supported by CodeFactory. Target extended logic is included to allow you to inject any data you want into the T4 template. 
The T4 template itself is compiled and called in compiled form. 
Once data is passed into the T4 template the fully formatted output of the T4 is returned as a string.
This allows the author to control where the formatted source is injected into the target document. 

### Source Formatter - Provided Formatter
The CodeFactory SDK also has a SourceFormatter class. The source formatter provides extentions to the existing string builder object. 
This allows for the controlling of indentation within the content, as its added to the formatter. 
It also allows for indentation a target number of levels deep to full content that is provided to it. 
This will also be further extended over time to provide additional capabilities.

## Overview 
This link takes you back to the CodeFactory Overview

[CodeFactory Overview](../Overview.md)
