Require<Shovel>();

// Demonstrate task dependencies

"Simple"
	.DependsOn("Clean", "PrepareRocketLaunchers")
	.Do(() =>
	{
		Console.WriteLine("Simplifying...");
	});

"Clean"
	.DependsOn("WipeTheFloor")
	.Do(() =>
	{
		Console.WriteLine("Cleaning...");
	});

"WipeTheFloor"
	.Do(() =>
	{
		Console.WriteLine("Wiping the floor...");
	});

"PrepareRocketLaunchers"
	.Do(() =>
	{
		Console.WriteLine("Loading rocket launchers...");
	});

"Simple".Run();