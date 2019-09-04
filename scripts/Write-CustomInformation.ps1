function Write-CustomInformation {
    param (
        [Parameter(mandatory = $true)]
        [string]$Text
    )
    $myLength = 10;
    $Frame = "Ghis-Msg ";

    for ($i = 0; $i -lt $myLength; $i++) { $Frame += '>' }
    $Text = "$Frame $Text";
 
    Write-Host "$Text"  -ForegroundColor Magenta        
    
}
