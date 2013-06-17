Require<Scrape>();

// Demonstrate task dependencies

"Simple"
	.DependsOn("Clean", "PrepareRocketLaunchers")
	.Action(() =>
	{
		Console.WriteLine("Simplifying...");
	});

"Clean"
	.DependsOn("WipeTheFloor")
	.Action(() =>
	{
		Console.WriteLine("Cleaning...");
	});

"WipeTheFloor"
	.Action(() =>
	{
		Console.WriteLine("Wiping the floor...");
	});

"PrepareRocketLaunchers"
	.Action(() =>
	{
		Console.WriteLine("Loading rocket launchers...");
	});

"Simple".Do();