@echo off
if exist bin\Scrape.dll (goto buildwithscrape)

:bootstrap
echo No existing binaries found to build with, initiating bootstrap build...
call build-bootstrap.bat

:buildwithscrape
echo *** Building Scrape with itself. How cool is that? ***
scriptcs build.csx

echo *** Copying latest binaries ***
rmdir /S /Q .\bin
mkdir .\bin
copy ..\Scrape\bin\Debug\*.* bin
