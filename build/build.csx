Require<Shovel>();

"Build"
	.MsBuild(msb =>
		{
			msb.Targets("Rebuild");
			msb.ArbitraryArgs("/detailedsummary", @"/property:OutDir=..\..\build\bin-built-with-shovel", "/verbosity:minimal");
			msb.Project = @"..\src\Shovel\Shovel.csproj";
			msb.NoLogo();
		});