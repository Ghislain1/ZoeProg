## Build Status
[![Build Status](https://dev.azure.com/ZEUSXY/ZoeApp/_apis/build/status/Ghislain1.ZoeProg?branchName=master)](https://dev.azure.com/ZEUSXY/ZoeApp/_build/latest?definitionId=1&branchName=master) |  [![Release445](https://img.shields.io/github/release/firstfloorsoftware/mui.svg)](https://github.com/Ghislain1/ZoeProg/releases/tag/v0.2-alpha)

# Table of Contents
  - [Description](https://github.com/Ghislain1/ZoeProg/wiki)
  - [Features](#Features)
  - [Requirements](#Requirements)
  - [Dependencies](#dependencies)
  - [KnowHow](#knowhow)
  - [Road map](https://github.com/Ghislain1/ZoeProg/milestones)
  - [Issues](https://github.com/Ghislain1/ZoeProg/issues)
  - [Scrum Board](https://github.com/Ghislain1/ZoeProg/projects/1)
  - [Documentation](https://ghislain1.github.io/ZoeProg/api/index.html)
  - [References](#references)
  - [Theory](#theory)
  - [Next topics](#next-topics)

# Look & Feel
![alt text](https://github.com/Ghislain1/ZoeProg/blob/master/docDev/imgs/1.JPG)
![alt text](https://github.com/Ghislain1/ZoeProg/blob/master/docDev/imgs/2.JPG)

# Requirements
- Windows  10 (32, 64 bits)
- .Net5.0 or later
- Visual Studio 2019 or later

# Features
- <b>Cleanup Plugin</b> can clean:
  + User and Windows Temporary Directories
  + Windows Installer Cache
  + Windows Update Cache
  + Windows Logs Directory
  + Prefetch Cache
  + Crash Dump Directory
  + Google Chrome Cache
  + Steam Redistributable Packages
  + Temp Directory
  + Local Directory 
  
# References
1. [Controls](https://mahapps.com/docs/controls/HamburgerMenu)
2. [Prism WPF](https://github.com/PrismLibrary/Prism) - [His Doc](https://prismlibrary.com/docs/commanding.html) explaining
3. [Style and Design](https://uidesignsystem.com/desktop.html)

# Dependencies
- [Prism repositories](https://github.com/PrismLibrary/Prism)
- [Prism-Samples](https://github.com/PrismLibrary/Prism-Samples-Wpf) , 
- [Prism](http://prismlibrary.github.io/docs/)
- [Prism-Test](https://dev.azure.com/prismlibrary/Prism/_build/results?buildId=1923&view=results)
- [UI Design - Materila design XAML](http://materialdesigninxaml.net/)
- Powershell
- [DocFX](https://dotnet.github.io/docfx/tutorial/intro_template.html)

# KnowHow
- [Markdown](https://daringfireball.net/projects/markdown/) - To write text for the sofware document while developing
- [Visual Studio](https://docs.microsoft.com/de-de/visualstudio/get-started/visual-studio-ide?view=vs-2019) - IDE
- [Visual Studio code](https://code.visualstudio.com/) - Nice IDE
- Github
- [Git](https://git-scm.com/) - Version control system
- [WPF](https://docs.microsoft.com/de-de/dotnet/desktop/wpf/?view=netdesktop-5.0)
- [C-Sharp](https://docs.microsoft.com/en-us/dotnet/fundamentals/)
- [Prism](http://prismlibrary.github.io/docs/)

# Contributions
- Dev:
     + Install Git
     + Clone the project ()
     + Build the project from VS2017
     + Start Coding!!
 - Donation
     + Paypal(soon)
     + Amazon eGift Cards

# Theory

As mentioned previously this application consists of `Client` - Front End and `Server` - Back End. 

Both Front and Back end are then layered individually into sublayers such as `Core`, `Infrastructure`, `Persistance` which share common purpose.

### Core Layer

Represents combination of *Domain* and *Application* layers. 

*Domain layer* - Contains all entities, enums, exceptions, types and logic specific to the domain.

*Application layer* - contains all application/business logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

### Infrastructure Layer

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes are based on interfaces defined within the [Core](#core-layer) layer.

### Persistance Layer

Represents implementation of interfaces from the [Core](#core-layer) layer related to Database. 
In this case it represents classes related to Entity Framework like DbContext, Migrations, Fluent API Configurations, Database Initialization (Seed) method, etc.


### Presentation Layer

Holds logic related to GUI, which in this case is WPF Desktop Application. It depends on all of the other layers but none of them depend on Presentation layer. Purpose of clean architecture is to abstract this layer as much as possible so that it can be easily switchable.

---

## Design Patterns

In software engineering, a design pattern is a general repeatable solution to a commonly occurring problem in software design. A design pattern isn't a finished design that can be transformed directly into code. It is a description or template for how to solve a problem that can be used in many different situations.

### Repository and Unit of Work

*Repository* - Mediates between the domain and data mapping layers using a collection-like interface for accessing domain objects.

*Unit of Work* - Maintains a list of objects affected by a business transaction and coordinates the writing out of changes and the resolution of concurrency problems.

![Repository And Uow](doc/repository-and-uow.png)

### Decorator

Decorator pattern allows a user to add new functionality to an existing object without altering its structure. This type of design pattern comes under structural pattern as this pattern acts as a wrapper to existing class.

This pattern creates a decorator class which wraps the original class and provides additional functionality keeping class methods signature intact.

### Command

Command pattern is a data driven design pattern and falls under behavioral pattern category. A request is wrapped under an object as command and passed to invoker object. Invoker object looks for the appropriate object which can handle this command and passes the command to the corresponding object which executes the command.

### Factory Method

In class-based programming, the factory method pattern is a creational pattern that uses factory methods to deal with the problem of creating objects without having to specify the exact class of the object that will be created. This is done by creating objects by calling a factory method—either specified in an interface and implemented by child classes, or implemented in a base class and optionally overridden by derived classes—rather than by calling a constructor.

### Facade

Facade pattern hides the complexities of the system and provides an interface to the client using which the client can access the system. This type of design pattern comes under structural pattern as this pattern adds an interface to existing system to hide its complexities.

This pattern involves a single class which provides simplified methods required by client and delegates calls to methods of existing system classes.

### Template Method

Template method pattern is a behavioral design pattern that defines the program skeleton of an algorithm in an operation, deferring some steps to subclasses. It lets one redefine certain steps of an algorithm without changing the algorithm's structure.

### Prototype

The prototype pattern is a creational design pattern in software development. It is used when the type of objects to create is determined by a prototypical instance, which is cloned to produce new objects.

  # Next topics
  * Docker: https://docs.docker.com/engine/reference/commandline/dockerd/#options-per-storage-driver
           what is that?
  * Language: https://www.tiobe.com/tiobe-index//  here we can sse the best language for programming.
  * Raspberry Pi:  https://www.raspberrypi.org
       what can do with Raspberry Pi?( Camero control, Sensor control)
       Can i use C# with Raspberry Pi? Yes--> https://github.com/ZiCog/HomeSpun
  * [example scrum](https://github.com/bbougot/Popcorn/projects/1)
  * [parent](https://github.com/Zeeex/XTR-Toolbox/edit/master/README.md)
           
  
  

