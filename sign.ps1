$foundCert = Test-Certificate -Cert Cert:\CurrentUser\my\8ef9a86dfd4bd0b4db313d55c4be8b837efa7b77 -User
if(!$foundCert)
{
    Write-Host "Certificate doesn't exist. Exit."
    exit
}

Write-Host "Certificate found."

Remove-Item -Path .\*.nupkg
$nuget = ".\.nuget\nuget.exe"
& $nuget update /self | Write-Debug

Copy-Item .\WinFormsUI\bin\Release\*.nupkg -Destination .

Write-Host "Sign NuGet packages."
& $nuget sign *.nupkg -CertificateSubjectName "Yang Li" -Timestamper http://timestamp.digicert.com | Write-Debug
& $nuget verify -All *.nupkg | Write-Debug
if ($LASTEXITCODE -ne 0)
{
    Write-Host "NuGet package is not signed. Exit."
    exit $LASTEXITCODE
}

Write-Host "Verification finished."
