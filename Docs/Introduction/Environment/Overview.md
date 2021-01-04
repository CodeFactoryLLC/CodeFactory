# CodeFactory Ecosystem
CodeFactory is a collection of automation tools which are designed to be used in a native IDE(Integrated-Development-Environment). 
The decision to integrate into the IDE is based on the fact that CodeFactory is a design-time tool - meaning that no extraneous code artifacts, libraries or runtimes are required to be included with your final solution codebase.

In the future, CodeFactory will support more than one IDE, which is why CodeFactory products are named after the platform it's hosted on (i.e. CodeFactory for Visual Studio).

In this section we will focus on how CodeFactory integrates into the IDE.

## CodeFactory for Visual Studio
CodeFactory for Visual Studio is an extension of the Visual Studio IDE. 
CodeFactory was designed to run as an internal service inside Visual Studio, just like Razor, C#, or any number of other services that are part of Visual Studio. 
This means that once installed, CodeFactory is always 'on' and will automatically load automation commands for use whenever a solution is loaded.

## CFX - CodeFactory Extension
A CodeFactory automation project is saved as complete package within a single file called a CodeFactory Extension (*.cfx). 
This uses a similar approach as Word uses with DOCX or Excel with XSLX files. 
All it takes is to copy a CodeFactory Extension, or CFX, file into the root of the your solutions folder. 
Once the solution is opened in Visual Studio it will automatically load the automation and make it avaiable for use.

## CodeFactory SDK
All automation for CodeFactory was designed and delivered using the CodeFactory SDK. 
The SDK was designed to provide straightforward access to existing automation and authoring of custom automation.
The SDK uses targeted .NET Framework projects that hosts all the supporting libraries that make up the CodeFactory capabilities. 
The SDK is responsible for packaging the automation and generating the final CFX Files which are used with solutions.

[Link Here] - Back to Overview
