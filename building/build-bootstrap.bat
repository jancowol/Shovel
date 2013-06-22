@echo off
if exist bin\. rmdir /S /Q .\bin
msbuild /nologo /verbosity:minimal /target:Rebuild /property:OutDir=..\..\building\bin ..\src\Shovel\Shovel.csproj