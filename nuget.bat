mkdir .nuget
cd .nuget
del *.nupkg
nuget update /self
nuget pack DockPanelSuite.nuspec
nuget pack ThemeVS2003.nuspec
nuget pack ThemeVS2005Multithreading.nuspec
nuget pack ThemeVS2012.nuspec
nuget pack ThemeVS2013.nuspec
nuget pack ThemeVS2015.nuspec
cd ..