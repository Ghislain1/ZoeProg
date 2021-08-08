###################################################################################
#
#                        		ChocolateyNuGet project @ Ghislain 
#
##					 Powershell Script to 
#:: 
#
#   Inspired:
#       * https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit/blob/master/Scripts/GenerateThemesWikiMarkdown.ps1
##################################################################################

Clear-Host

# Variables

$SolutionDir = "./src"
$ScriptsDir = "./scripts"
$SiteDir = "./src\ZoeProg.Documentation\_site"
# Where the site is.
$DocsDir = "./docs"
# Combining two Paths using Powershell Commands
# $CleanSolPath = Join-Path $SolutionDir "CleanSol.cmd" 

# Importing the Custumonized PowerShell functions
#Get-ChildItem $ScriptsDir | Where-Object { $_.Name -like "*.ps1" } | ForEach-Object {
  #  Write-Verbose "[Including $_]"
#. .\scripts\$_
#}

# Set this location as Current location
Push-Location  

# Set to location where solution.sln is located
Set-Location $SolutionDir

# Clean Bin and Obj
#Write-StageInformation -Text 'Bin and Objects Deleting... '
$binObj = Get-ChildItem .\ -Include bin, obj -Recurse 
$binObj | ForEach-Object ($_) { 
   # Write-CustomInformation -Text $_   
    if (Test-Path $_.FullName) {
        Remove-Item $_.Fullname -Recurse  -Force -ErrorAction Stop
    }  
    
 
}

# Restore package using dotnet restore commands 
#Write-StageInformation -Text 'Package Restoring...'
#$projects = Get-ChildItem *.csproj -Recurse -Force
#ForEach ( $pro in $projects) {
 #   dotnet restore $pro
#}

# Build the whole solution using dotnet command
#Write-StageInformation -Text 'Solution building...'
#$BuildExpression = "dotnet msbuild /p:Configuration=Debug /p:Platform='Any CPU'"
#Invoke-Expression  $BuildExpression
#Write-CustomInformation -Text "Best way to use Invoke-Expression Command in Powershell Script has been done"  

# Change to most recent location
#Pop-Location
#Write-StageInformation -Text 'Website for docs copying...'
#$SiteItems = Get-ChildItem $SiteDir  
#$SiteItems | Copy-Item -Destination $DocsDir -Force   -Verbose 


# Inform user that solution finisched successfully
dotnet build -v d
#Write-StageInformation -Text 'Solution Reading...'





