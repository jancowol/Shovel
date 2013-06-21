Require<Scrape>();

// Demonstrate MSBuild wrapper

"Build"
	.DependsOn("Dependency")
	.MsBuild(msb =>
		{
			msb.ArbitraryArgs("/nologo", "/detailedsummary");
			msb.Project = @"test-msbuild\test-msbuild.csproj";
			msb.Targets("Clean", "Compile");
		});

"Dependency"
	.Do(() =>
		{
			Console.WriteLine("Do some stuff here...");
		});

"Build".Run();