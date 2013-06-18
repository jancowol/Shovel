Require<Scrape>();

// Demonstrate MSBuild wrapper

"Build"
	.DependsOn("Dependency")
	.MsBuild(msb =>
		{
			msb.Project = @"test-msbuild\test-msbuild.csproj";
			// msb.Targets("Clean", "Compile");
		});

"Dependency"
	.Action(() =>
		{
			Console.WriteLine("Do some stuff here...");
		});

	// .Action(() =>
	// 	MsBuild.Run(msb =>
	// 	{
	// 		msb.Project = "test-msbuild.csproj";
	// 		msb.Targets = new[] {"Clean", "Compile"};
	// 	}));

	// .Action(() =>
	// 	MsBuild
	// 		.Project(@"test-msbuild\test-msbuild.csproj")
	// 		.Targets("Clean", "Compile")
	// 		.Build());

"Build".Do();