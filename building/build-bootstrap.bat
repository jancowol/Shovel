@echo off
echo Building using MSBuild...
msbuild /nologo /verbosity:minimal ..\Scrape\Scrape.sln
rmdir /S /Q .\bin
mkdir .\bin
echo Copying built binaries...
copy ..\Scrape\bin\Debug\*.* .\bin
