#This will be the root folder of all your solutions - we will search all children of this folder 
#This is where your NuGet.exe is located

function RestoreAllPackages {
    param (
        [Parameter(mandatory = $true)]
        [string]$SolutionDir,
		
        [Parameter(mandatory = $true)]
        [string]$NUGETLOCATION
		
    )
    Write-Host  "Nuget location = $NUGETLOCATION"
    Write-Host "Solution location = $SolutionDir"
    Write-Host "Starting Package Restore - This may take a few minutes ..."
    $PACKAGECONFIGS = Get-ChildItem -Recurse -Force $SolutionDir -ErrorAction SilentlyContinue | 
    Where-Object { ($_.PSIsContainer -eq $false) -and ( $_.Name -eq "packages.config") }
	
    ForEach ($PACKAGECONFIG in $PACKAGECONFIGS) {
        Write-Host $PACKAGECONFIG.FullName
        $NugetRestore = $NUGETLOCATION + " install " + " '" + $PACKAGECONFIG.FullName + "' -OutputDirectory '" + $PACKAGECONFIG.Directory.parent.FullName + "\packages'"
        Write-Host $NugetRestore
        Invoke-Expression $NugetRestore
    }
    $expression = "$NUGETLOCATION restore $SolutionDir"
    Write-Host $expression
    Invoke-Expression  $expression
}

# RestoreAllPackages $SOLUTIONROOT
# Write-Host "Press any key to continue ..."
# $x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")