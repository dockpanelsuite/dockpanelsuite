mkdir .nuget
cd .nuget
nuget update /self
nuget push *.nupkg -Source https://www.nuget.org/api/v2/package
cd ..