@echo off

echo Bootstrapping Shovel binaries...
call build-bootstrap.bat
echo Bootstrapping completed.

echo Rebuilding Shovel with itself... Pretty nifty huh?
echo Note: ScriptCS must be available in the path for this to work.
scriptcs build.csx

echo Done building Shovel with itself.