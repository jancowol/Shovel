@echo off
if exist bin\Shovel.dll (goto buildwithshovel)

:bootstrap
echo No existing binaries found to build with, initiating bootstrap build...
call build-bootstrap.bat

:buildwithshovel
echo *** Building Shovel with itself. How cool is that? ***
scriptcs build.csx

echo *** Copying latest binaries ***
rmdir /S /Q .\bin
mkdir .\bin
copy ..\Shovel\bin\Debug\*.* bin
