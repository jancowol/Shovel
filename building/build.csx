var msbuild = Require<MsBuild>();

msbuild
	.Project(@"..\Scrape\Scrape.sln");
