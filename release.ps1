$msBuild = "msbuild"
try
{
    & $msBuild /version
    Write-Host "Likely on Linux/macOS."
}
catch
{
    Write-Host "MSBuild doesn't exist. Use VSSetup instead."

    Install-Module VSSetup -Scope CurrentUser -Force
    $instance = Get-VSSetupInstance -All | Select-VSSetupInstance -Latest
    $installDir = $instance.installationPath
    $msBuild = $installDir + '\MSBuild\Current\Bin\MSBuild.exe'
    if (![System.IO.File]::Exists($msBuild))
    {
        Write-Host "MSBuild 16 doesn't exist."
        $msBuild = $installDir + '\MSBuild\15.0\Bin\MSBuild.exe'
        if (![System.IO.File]::Exists($msBuild))
        {
            Write-Host "MSBuild 15 doesn't exist. Exit."
            exit 1
        }
        else
        {
            Write-Host "Likely on Windows with VS2017."
        }
    }
    else
    {
        Write-Host "Likely on Windows with VS2019."
    }
}

Write-Host "MSBuild found. Compile the projects."

Remove-Item .\WinFormsUI\bin\Release\*.nupkg

& $msBuild WinFormsUI.Docking.sln /p:Configuration=Release /t:restore
& $msBuild WinFormsUI.Docking.sln /p:Configuration=Release /t:clean
& $msBuild WinFormsUI.Docking.sln /p:Configuration=Release

Write-Host "Compilation finished."
