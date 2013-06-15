var msbuilder = Require<MsBuild>();

msbuilder
	.Project(@"..\Scrape\Scrape.sln")
	.Build();
