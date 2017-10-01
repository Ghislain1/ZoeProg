# ZoeProg
This is an Interface to install program from your local PC.

Next steps: we want to follow Style guideline of google: https://material.io/guidelines/components/buttons.html#



## Cross Cutting
* Prism Libraries such as Prism.Unity
* MaterialDesignThemes for themes and control.
* FodyWeavers for automatic Notify property changed.
* System.Management.Automation for using PowerShell inside C# File.


## To learn Pattern 
* Application Controller Pattern
* Command Pattern
* Dependency Injection Pattern
* Event Aggregator Pattern
* Façade Pattern
* Inversion of Control Pattern
* Observer Pattern
* Registry Pattern
* Repository Pattern
* Plug-In
* Service Locator Pattern

Ref:  https://msdn.microsoft.com/en-us/library/ff921146(v=pandp.40).aspx


## Experience
* How to use CancellationTokenSource class? --> https://blogs.msdn.microsoft.com/dotnet/2012/06/06/async-in-4-5-enabling-progress-and-cancellation-in-async-apis/
* How to use SemaphoreSlim class  ?
* How to use System.Management.Automation.PowerShell class?
* How to use Regex in C# see https://regexone.com/lesson/whitespaces



## Learned Core Scenarios
* Detecting when a module has already been loaded
* Downloading remote modules in the background
* Loading Modules on DemanD
* Registering Modules
* Discovering Modules
* Specifying Module Dependencies( in Code; in XAML;  in Configuration)

## Rules:
### Partition into Modules
  * Discrete modules.
  * Modules are  organized around vertical layers.
  * A single assembly per module.
  * Use dependency injection
  * Use a unique <b> bootstrapping </b> process
  * Each module has an <b>implicit dependency </b> on  container
  
  
  ## Notes:
  . http://antidupl.sourceforge.net/english/index.html?page=download.html
  
  
