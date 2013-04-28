CALL clean.bat
CALL release.bat
CALL clean.bat
CALL release.net40.bat
CD .nuget
CALL nuget.exe pack
CD ..