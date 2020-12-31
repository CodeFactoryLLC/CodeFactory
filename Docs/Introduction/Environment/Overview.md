# CodeFactory Ecosystem
CodeFactory is a collection of automation tools that are designed to be used in a native IDE(Integrated-Development-Environment). 
The decision to integrate into the IDE is based on the fact that CodeFactory is a design time tool - meaning that no extra code artifacts or runtimes are required to be added to your final solution codebase.

Throughout the life of CodeFctory more then one IDE will be supported in future releases. Which is why CodeFactory is always named after the platform it is hosted on.

In this section we will focus on how CodeFactory integrates into the IDE.

## CodeFactory for Visual Studio
CodeFactory for Visual Studio is an extension of the Visual Studio IDE. 
CodeFactory was designed to run as an internal service inside Visual Studio just like Razor, C#, or any number of other services that are part of Visual Studio. 
This means that once installed CodeFactory is always 'on' and will automatically load automation commands for use when a solution is loaded.

## CFX - Code Factory Extension
A CodeFactory automation project is saved as complete package in a single file called a CodeFactory extension (*.cfx). 
This uses a similar approach as word with DOCX or Excel with XSLX files. 
All it takes is to copy a CodeFactory extension, or CFX, file into the root of the your solutions folder. 
Once the solution is opened in Visual Studio it will automatically load the automation and make it avaiable for use.

## CodeFactory SDK
All automation for CodeFactory was designed and delivered using the CodeFactory SDK. 
The SDK was designed to provide straight forward access to automation and authoring of custom automation.
The SDK uses targeted .net framework projects that hosts all the supporting libraries that make up the CodeFactory capabilities. 
The SDK is responsible for packaging the automation and making the final CFX Files that are used with solutions.

[Link Here] - Back to Overview
