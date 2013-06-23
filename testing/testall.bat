@echo off
cd %~dp0

echo Rebuilding Shovel...
pushd ..\building
call build.bat
popd

echo Copying latest build artifacts...
if exist bin\. rmdir /S /Q .\bin
mkdir bin
copy ..\building\bin-built-with-shovel\*.* .\bin > NUL

echo Running test scripts...
echo.

echo *** Test building with MSBuild...
call test-msbuild.bat
echo *** Done ***
echo.

echo *** Test basic task running...
call test-shovel.bat
echo *** Done ***
echo.
