:: http://stackoverflow.com/questions/328017/path-to-msbuild
:: http://www.csharp411.com/where-to-find-msbuild-exe/
:: http://timrayburn.net/blog/visual-studio-2013-and-msbuild/
:: http://blogs.msdn.com/b/visualstudio/archive/2013/07/24/msbuild-is-now-part-of-visual-studio.aspx
for %%v in (2.0, 3.5, 4.0, 12.0, 14.0) do (
  for /f "usebackq tokens=2* delims= " %%c in (`reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\%%v" /v MSBuildToolsPath`) do (
    set msBuildExe=%%dMSBuild.exe
  )
)

call .nuget\NuGet.exe update /self
call .nuget\NuGet.exe restore
call "%msBuildExe%" WinFormsUI.Docking.sln /t:build /p:Configuration=Release /p:TargetFrameworkVersion=v4.0 /p:OutputPath=..\bin\net40\
@IF %ERRORLEVEL% NEQ 0 PAUSE