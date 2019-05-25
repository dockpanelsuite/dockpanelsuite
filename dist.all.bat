CALL vswhere.bat
CALL clean.bat
CALL release.bat
CALL clean.bat
CALL release.net35.bat
powershell -file sign.ps1
