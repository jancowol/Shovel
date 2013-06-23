Require<Shovel>();

// Demonstrate MSBuild wrapper

"Build"
	.MsBuild(msb =>
		{
			msb.ArbitraryArgs("/verbosity:minimal");
			msb.Project = @"test-msbuild\test-msbuild.csproj";
			msb.Targets("Clean", "Compile");
			// msb.NoLogo();
		});

"Build".Run();