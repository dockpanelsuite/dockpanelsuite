set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %MSBuildDir%\msbuild WinFormsUI.Docking.sln /t:build /p:Configuration=Release /p:TargetFrameworkVersion=v2.0 /p:OutputPath=..\bin\net20\
@IF %ERRORLEVEL% NEQ 0 PAUSE