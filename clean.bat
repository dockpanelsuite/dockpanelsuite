set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %MSBuildDir%\msbuild src\WinFormsUI.Docking.sln /t:clean
call %MSBuildDir%\msbuild src\WinFormsUI.Docking.sln /t:clean /p:Configuration=Release
@IF %ERRORLEVEL% NEQ 0 PAUSE