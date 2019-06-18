Clear-Host

# Variables

$SolutionDir = "./src";
$ScriptsDir = "./scripts";


 

# Importing the PowerShell functions
Get-ChildItem $ScriptsDir | Where-Object { $_.Name -like "*.ps1" } | ForEach-Object {
    Write-Verbose "[Including $_]"
    . .\scripts\$_
}

# Change to most recent location
Pop-Location 

# Set to location where solution.sln is located
Write-StageInformation -Text 'Current location Solution folder'
Set-Location $SolutionDir

Write-StageInformation -Text 'Package Restoring...'
dotnet restore

Write-StageInformation -Text 'Solution building...'
dotnet build

