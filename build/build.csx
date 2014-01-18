Require<Shovel>();

"Full"
	.DependsOn("Build", "Package");
	
"Build"
	.MsBuild(msb =>
		{
			msb.Targets("Rebuild");
			msb.ArbitraryArgs("/detailedsummary", @"/property:OutDir=..\..\build\bin-built-with-shovel", "/verbosity:minimal");
			msb.Project = @"..\src\Shovel.sln";
			msb.NoLogo();
		});

"Package".Do()
	.NuGet().Pack(p =>
	{
		p.NuSpec = "Shovel.nuspec";
		p.OutputDirectory = "nuget-package";
	});
