rem call ..\building\build-bootstrap.bat
rmdir /S /Q .\bin
mkdir .\bin
copy ..\building\bin\*.* bin
scriptcs test-scrape.csx
