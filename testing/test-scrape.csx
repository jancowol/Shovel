var builder = Require<MsBuild>();

builder
	.Project(@"..\Scrape\Scrape.sln")
	.Build();
