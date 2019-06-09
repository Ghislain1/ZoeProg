###################################################################################
#
#                        		ChocolateyNuGet project @ Ghislain 
#
##					 Powershell Script to 
#:: 
#
#
##################################################################################


# Variable
$DeleteBatPath = "./CleanSol.cmd"
$SolutionPath = "ZoeProg.sln"
$MsBuildPath = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
$NUGET_URL = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
$TOOLS_DIR = "Tools"
$NUGET_EXE = Join-Path $TOOLS_DIR "nuget.exe"

 

 




# Call Batch file 
Start-Process $DeleteBatPath

# Dotnet 
Clear-Host
Write-Host  "Dotnet CLI In action ... "
Start-Sleep -Seconds 10
dotnet restore $SolutionPath --verbosity d  --force
Start-Sleep -Seconds 10
# dotnet build
 

