Require<Shovel>();

"Build"
	.MsBuild(msb =>
		{
			msb.Targets("Rebuild");
			msb.ArbitraryArgs("/detailedsummary", @"/property:OutDir=..\..\build\bin-built-with-shovel", "/verbosity:minimal");
			msb.Project = @"..\src\Shovel\Shovel.csproj";
			msb.NoLogo();
		});

"Package"
	.RunProgram(p =>
		{
			p.Executable = @"..\src\packages\NuGet.CommandLine.2.6.1\tools\NuGet.exe";
			p.Arguments("pack", @"Shovel.nuspec", "-OutputDirectory nuget-package");
		});