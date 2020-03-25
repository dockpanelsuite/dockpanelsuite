$foundCert = Test-Certificate -Cert Cert:\CurrentUser\my\43eb601ecc35ed5263141d4dc4aff9c77858451c -User
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
