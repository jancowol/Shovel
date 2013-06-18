rmdir /S /Q .\bin
mkdir .\bin
copy ..\Scrape\bin\Debug\*.* bin
scriptcs test-msbuild.csx
