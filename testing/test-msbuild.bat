rmdir /S /Q .\bin
mkdir .\bin
copy ..\Shovel\bin\Debug\*.* bin
scriptcs test-msbuild.csx
