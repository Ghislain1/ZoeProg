function Write-StageInformation {
  param (
    [Parameter(mandatory = $true)]
    [string]$Text
  )
  
  $Frame = ""
  $Text = "Build Stage: $Text"
  for ($i = 0; $i -lt $Text.length; $i++){ $Frame += '=' }
  Write-Host $Frame
  Write-Host "$Text"
  Write-Host $Frame
}
