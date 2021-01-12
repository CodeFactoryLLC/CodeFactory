# CodeFactory Commands
When working with CodeFactory you always start with commands. 
Commands are the trigger point where all CodeFactory functionality originates. 
Currently all commands are triggered from context menus on individual nodes within Solution Explorer. Each command is comprised of two methods which are raised from internal events that occur within Visual Studio. These events are trigged when a selected Solution Explorer's item content menu is opened. 
The following describes each of the two methods, their purpose and the different types of commands that are supported in CodeFactory.

## Command Result
Whenever a command is executed, a real time data model is generated based on the type of Visual Studio object that has been selected. The data model is instantly regenerated behind-the-scenes each time the target command is executed. 

## Enable Command
When a command is first loaded, it sends the command result to the enable method on the command.
This method is called to allow the author of the command to determine whether the command should be visible or hidden to the automation user for use. 
This feature exists in order to allow automation authors to control execution of automation by hiding or showing commands on the context menu as they desire. 

This is controlled by simply returning a true or false value to determine if the command should be accessible.
If enabled is true, the command will appear inside the context menu. 
The developer in Visual Studio can then trigger the command to execute by selecting the context menu item.

## Execute Command
Once the developer selects a command to be executed, Visual Studio will run the execute method of the command itself. 
Like before, a real time data model is instantly passed to the execute method. 
This is when the automation process starts, and whatever functionality has been authored, will be executed at this time.

## Solution Explorer Commands
CodeFactory current supports the trigger of commands from the Solution Explorer window within Visual Studio.
The following are the supported Solution Explorer nodes that can interact with CodeFactory automation commands:

 - Solution Command - Generates a Solution data model
 - SolutionFolder Command - Generates a SolutionFolder data model
 - SolutionDocument Command - Generates a SolutionDocument data model
 - Project Command - Generates a Project data model
 - ProjectFolder - Generates a ProjectFolder data model
 - Document Command - Generates a Document data model
 - C# Document Command - Generates a CSharpSource data model
 
## Overview 
This link takes you back to the CodeFactory Overview

[CodeFactory Overview](../Overview.md)
