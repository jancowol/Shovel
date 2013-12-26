@echo off

echo Running unit tests...
echo.
nunit-console.exe /stoponerror ..\build\bin-built-with-shovel\Shovel.Tests.dll