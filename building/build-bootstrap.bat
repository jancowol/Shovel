@echo off
echo Building using MSBuild...
msbuild /nologo /verbosity:minimal ..\Shovel\Shovel.sln
rmdir /S /Q .\bin
mkdir .\bin
echo Copying built binaries...
copy ..\Shovel\bin\Debug\*.* .\bin
