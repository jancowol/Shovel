@echo off

echo Cleaning any binary artifacts...
if exist bin\. rmdir /S /Q .\bin
if exist bin-build-with-shovel\. rmdir /S /Q .\bin-build-with-shovel
if exist nuget-package\. rmdir /S /Q .\nuget-package

echo Bootstrapping Shovel binaries...
msbuild /nologo /verbosity:quiet /target:Rebuild /property:OutDir=..\..\build\bin ..\src\Shovel\Shovel.csproj

echo Creating required directories...
mkdir nuget-package

echo Rebuilding Shovel with itself... Pretty nifty huh?
echo Note: ScriptCS must be available in the path for this to work.
scriptcs build.csx -loglevel Error -- -tasks:Build,Package

echo Done building Shovel with itself.