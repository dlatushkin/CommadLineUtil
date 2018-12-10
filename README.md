# File structure
There are 3 projects in the solution
## CommadLineUtil
Represents entry point console .NET Core application.
[Program.cs](./CommadLineUtil/Program.cs) contains code to configure command line parser and run commands/show help.
Two commands are configured
* [CommandOne](./CommandLineUtil.Command/CommandOne.cs)
* [CommandTwo](./CommandLineUtil.Command/CommandTwo.cs)

## CommandLineUtil.Command
Represents .NET Core library for command implementation.
There are 2 commands here:
### [CommandOne](./CommandLineUtil.Command/CommandOne.cs)
prints out desired message ("hello world" if no message is explicitelly provided as argument)
### [CommandOneArguments](./CommandLineUtil.Command/CommandOneArguments.cs)
defines [CommandOne](./CommandLineUtil.Command/CommandOne.cs) command srguments
### [CommandTwo](./CommandLineUtil.Command/CommandTwo.cs)
lists the files/folders in the desired directory (current directory by default)
### [CommandTwoArguments](./CommandLineUtil.Command/CommandTwoArguments.cs)
defines [CommandTwo](./CommandLineUtil.Command/CommandTwo.cs) command srguments

## FluentCommandLineParserCore
Original [fluent-command-line-parser](https://github.com/fclp/fluent-command-line-parser) project ported to .NET Standard.
The project is used to
* parse command line arguments
* fill command argument structures
* execute commands
* show help

# How to compile
## Windows
* Install [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2) for Windows
* Download the source code from the repository.
* Navigate to local repository directory
* Run `dotnet build`

## Linux
* Follow the instructions [here](https://dotnet.microsoft.com/download/linux-package-manager/rhel/sdk-2.2.100) for appropriate linux distribution (The application has been tested on Ubuntu 18.0.4 LTS).
* Download the source code from the repository
  `sudo git clone https://github.com/dlatushkin/CommadLineUtil.git CommandLineUtil`
* Navigate to local repository directory
* Run `sudo dotnet publish -o "../CommandLineUtilPublish"`
* Navigate to CommandLineUtilPublish folder
* Try utility [(see samples)](#Usage-samples)

## Mac OS
Follow instruction [here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.100-macos-x64-installer).
* Download the source code from the repository.
* Navigate to local repository directory
* run `dotnet build`


# Usage samples
#### Show help
* `dotnet CommandLineUtil.dll -?` 
* `dotnet CommandLineUtil.dll --help`
#### Run commandone with default message
* `dotnet CommandLineUtil.dll commandone` 
#### Run commandone with message parameter
* `dotnet CommandLineUtil.dll commandone --message "TEZTMSG"`
* `dotnet CommandLineUtil.dll commandone -m "TEZTMSG"`
#### Run commandtwo with default parameters
* `dotnet CommandLineUtil.dll commandtwo
#### Run commandtwo with parameters specified
* `dotnet CommandLineUtil.dll commandtwo --path ".." --include-dir`
* `dotnet CommandLineUtil.dll commandtwo -p ".." -d`
  
