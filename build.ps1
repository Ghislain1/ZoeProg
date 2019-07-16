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
# Combining two Paths using Powershell Commands
# $CleanSolPath = Join-Path $SolutionDir "CleanSol.cmd"
$NugetExePath = ".\./tooling/.nuget/NuGet.exe"


 

# Importing the Custumonized PowerShell functions
Get-ChildItem $ScriptsDir | Where-Object { $_.Name -like "*.ps1" } | ForEach-Object {
    Write-Verbose "[Including $_]"
    . .\scripts\$_
}

# Set this location as Current location
Push-Location 


 

# Set to location where solution.sln is located
Set-Location $SolutionDir

# Clean Bin and Obj
Write-StageInformation -Text 'Bin and Objects Deleting... '
$binObj = Get-ChildItem  -include bin, obj -Recurse 
$binObj | ForEach-Object ($_) { 
    Write-Host $_.FullName
    Remove-Item $_.Fullname -Force -Recurse  
 
}

# Restore package using dotnet restore commands 
Write-StageInformation -Text 'Package Restoring...'
$projects = Get-ChildItem *.csproj -Recurse -Force
ForEach ( $pro in $projects) {
    dotnet restore $pro
}

# Build the whole solution using dotnet command
Write-StageInformation -Text 'Solution building...'
$BuildExpression = "dotnet msbuild /p:Configuration=Debug /p:Platform='Any CPU'"
Invoke-Expression  $BuildExpression

# Dotnet restore 
# TODO: RestoreAllPackages    -SolutionDir "./"  -NUGETLOCATION "$NugetExePath"

# Change to most recent location
Pop-Location



