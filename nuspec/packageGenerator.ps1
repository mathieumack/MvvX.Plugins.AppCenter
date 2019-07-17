params(
	# Product version
	[string]$ProductVersion
)

write-host "**************************" -foreground "Cyan"
write-host "*   Packaging to nuget   *" -foreground "Cyan"
write-host "**************************" -foreground "Cyan"

#$location  = "C:\Sources\NoSqlRepositories";
$location  = $env:APPVEYOR_BUILD_FOLDER

$locationNuspec = $location + "\nuspec"
$locationNuspec
	
Set-Location -Path $locationNuspec

write-host "Update the nuget.exe file" -foreground "DarkGray"
.\NuGet update -self

write-host "Product version : " $ProductVersion -foreground "Green"

write-host "Packaging to nuget..." -foreground "Magenta"

#write-host "Update nuspec versions" -foreground "Green"

#write-host "Update nuspec versions MvvX.Plugins.AppCenter.nuspec" -foreground "DarkGray"
#$nuSpecFile =  $locationNuspec + '\MvvX.Plugins.AppCenter.nuspec'
#(Get-Content $nuSpecFile) | 
#Foreach-Object {$_ -replace "{BuildNumberVersion}", "$ProductVersion" } | 
#Set-Content $nuSpecFile

write-host "Generate nuget packages" -foreground "Green"

write-host "Generate nuget package for MvvX.Plugins.AppCenter.nuspec" -foreground "DarkGray"
.\NuGet.exe pack MvvX.Plugins.AppCenter.nuspec -Version $ProductVersion

$apiKey = $env:NuGetApiKey
	
write-host "Publish nuget packages" -foreground "Green"

write-host MvvX.Plugins.AppCenter.$ProductVersion.nupkg -foreground "DarkGray"
.\NuGet push MvvX.Plugins.AppCenter.$ProductVersion.nupkg -Source https://www.nuget.org/api/v2/package -ApiKey $apiKey