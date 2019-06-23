Clear-Host

# Variables

$SolutionDir = "./src"
$ScriptsDir = "./scripts"
$NugetExePath = ".\./tooling/.nuget/NuGet.exe"


 

# Importing the PowerShell functions
Get-ChildItem $ScriptsDir | Where-Object { $_.Name -like "*.ps1" } | ForEach-Object {
    Write-Verbose "[Including $_]"
    . .\scripts\$_
}

# Set this location as recent location
Push-Location 

# Set to location where solution.sln is located
Set-Location $SolutionDir

# restore package using dotnet restore commands 
Write-StageInformation -Text 'Package Restoring...'
$projects = Get-ChildItem *.csproj -Recurse -Force
ForEach ( $pro in $projects) {
    dotnet restore $pro
}

Write-StageInformation -Text 'Solution building...'
$BuildExpression = "dotnet msbuild   /p:Configuration=Debug /p:Platform='Any CPU'"
Invoke-Expression  $BuildExpression

# Dotnet restore 
# TODO: RestoreAllPackages    -SolutionDir "./"  -NUGETLOCATION "$NugetExePath"

# Change to most recent location
Pop-Location



