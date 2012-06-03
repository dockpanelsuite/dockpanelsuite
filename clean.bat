set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %MSBuildDir%\msbuild WinFormsUI.Docking.vs2010.sln /t:clean
call %MSBuildDir%\msbuild WinFormsUI.Docking.vs2010.sln /t:clean /p:Configuration=Release
@IF %ERRORLEVEL% NEQ 0 PAUSE