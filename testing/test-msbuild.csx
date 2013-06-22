Require<Shovel>();

// Demonstrate MSBuild wrapper

"Build"
	.DependsOn("Dependency")
	.MsBuild(msb =>
		{
			msb.ArbitraryArgs("/detailedsummary");
			msb.Project = @"test-msbuild\test-msbuild.csproj";
			msb.Targets("Clean", "Compile");
			msb.NoLogo();
		});

"Dependency"
	.Do(() =>
		{
			Console.WriteLine("Do some stuff here...");
		});

"Build".Run();