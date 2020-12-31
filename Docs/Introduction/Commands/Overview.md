# CodeFactory Commands
When working with CodeFactory you always start with commands. 
Commands are the trigger point where all CodeFactory functionality starts from. 
As of this release of CodeFactory all commands are triggered from context menus on individual nodes within solution explorer. As per the name a command following a command exection pattern. 
This is made up of two methods that are raised from internal events that occur within Visual Studio itself. These events are trigged when a selected solution explorers item content menu is opened. 
The following explain the two methods their goal and the different type of commands that are supported in CodeFactory.

## Command Result
Whenever a command is executed a real time data model is generated based on the type of Visual Studio object that has been selected. The data model is regenerated each time the target command is executed. 

## Enable Command
When a command is first loaded it sends the command result to the enable method on the command.
This method is called to allow the author of the command to determine if the command should be enabled to be used. 
This was added to allow the author to control execution of automation. 
You may only want automation to be enabled based on a target condition.
This is controlled by simply returning a true or false value to determine if the command should be accessible.
If enabled is true the command will show up in the context menu. 
The developer in Visual Studio will then trigger the command to execute by selecting the context menu item.

## Execute Command
Once the developer selects a command to be executed Visual Studio will trigger the execute method of the command itself. 
Like before a real time data model is passed to the execute method. 
This is where the automation process starts and whatever functionality has been assigned will executed at this time.

## Solution Explore Commands
CodeFactory current supports the trigger of commands from the solution explorer window in Visual Studio.
The following are the supported Solution Explorer nodes that will CodeFactory Automation.

 - Solution Command - Generates a Solutiuon data model
 - SolutionFolder Command - Generates a Solution Folder data model
 - SolutionDocument Command - Generates a Document data model
 - Project Command - Generates a Project data model
 - Project Folder - Generates a Project Folder data model
 - Document Command - Generates a Document data model
 - C# Document Command - Generates a CSharpSource data model
