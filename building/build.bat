@echo off
if exist bin\Scrape.dll (goto build)

:bootstrap
echo No existing binaries found to build with, initiating bootstrap build...
call build-bootstrap.bat
rmdir /S /Q .\bin
mkdir .\bin
echo Copying built binaries...
copy ..\Scrape\bin\Debug\*.* .\bin

:build
echo Building with Scrape with itself. How cool is that?
scriptcs build.csx

:end
