@echo off

echo Cleaning any binary artifacts...
if exist bin\. rmdir /S /Q .\bin
if exist bin-built-with-shovel\. rmdir /S /Q .\bin-built-with-shovel
if exist nuget-package\. rmdir /S /Q .\nuget-package

echo Bootstrapping Shovel binaries...
msbuild /nologo /verbosity:quiet /target:Rebuild /property:OutDir=..\..\build\bin ..\src\Shovel\Shovel.csproj

echo Creating required directories...
mkdir nuget-package

echo Rebuilding Shovel with itself... Pretty nifty huh?
echo Note: ScriptCS must be available in the path for this to work.
scriptcs build.csx -loglevel Error -- -tasks:Full

echo Done building Shovel with itself.

echo *** Verifying build...

:testBuild
echo Checking existence of binary...
if exist bin-built-with-shovel\Shovel.dll goto :testPackage
echo ERROR: Could not find Shovel.dll, build failed.
exit /b 1

:testPackage
echo Checking existence of nuget package...
if exist nuget-package\ScriptCs.Shovel.0.1.0.0.nupkg goto :success
echo ERROR: Could not find the Shovel NuGet package, build failed.
exit /b 1

:success
echo *** Build succeeded ***