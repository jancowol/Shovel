@echo off
cd %~dp0

cls

echo Rebuilding Shovel...
pushd ..\build
call build.bat
if %errorlevel% neq 0 exit /b 1
popd

echo Running unit tests...
echo.

nunit-console.exe ..\build\bin-built-with-shovel\Shovel.Tests.dll