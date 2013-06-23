@echo off

echo Cleaning any binary artifacts...
if exist bin\. rmdir /S /Q .\bin
if exist bin-build-with-shovel\. rmdir /S /Q .\bin-build-with-shovel

echo Bootstrapping Shovel binaries...
msbuild /nologo /verbosity:minimal /target:Rebuild /property:OutDir=..\..\building\bin ..\src\Shovel\Shovel.csproj
echo Bootstrapping completed.

echo Rebuilding Shovel with itself... Pretty nifty huh?
echo Note: ScriptCS must be available in the path for this to work.
scriptcs build.csx

echo Done building Shovel with itself.