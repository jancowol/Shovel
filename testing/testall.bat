@echo off
cd %~dp0

cls

echo Rebuilding Shovel...
pushd ..\build
call build.bat
popd

echo Copying latest build artifacts...
if exist bin\. rmdir /S /Q .\bin
mkdir bin
copy ..\build\bin-built-with-shovel\*.* .\bin > NUL

echo Running test scripts...
echo.

echo *** Test building with MSBuild...
scriptcs test-msbuild.csx -loglevel Error -- -tasks:Build
echo *** Done ***
echo.

echo *** Test basic task running...
scriptcs test-shovel.csx -loglevel Error -- -tasks:Simple
echo *** Done ***
echo.

echo *** General tests...
scriptcs test-general.csx -loglevel Error -- -tasks:TheTask
echo *** Done ***
echo.
