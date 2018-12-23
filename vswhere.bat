del vswhere.exe
copy "C:\Program Files (x86)\Microsoft Visual Studio\Installer\vswhere.exe" .
@IF %ERRORLEVEL% NEQ 0 exit /b 1