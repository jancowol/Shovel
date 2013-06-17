Require<Scrape>();

// Can create new task
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

// "Clean".Task()
// 	.DependsOn("AnotherTask")
// 	.Do(() =>
// 	{
// 		// do some cleaning stuff here
// 	});

// Task("Clean")
// 	.Do(() =>
// 	{
// 		// Clean bin folders
// 		// Run another defined task
// 		DoTask["AnotherTask"];
// 	});

// Task("Compile")
// 	.DependsOn("Clean")
// 	.Do(() =>
// 	{
// 		MsBuild
// 			.Project(@"..\Scrape\Scrape.sln")
// 			.Verbosity
// 			.Build();
// 	})

// Task("Build")
// 	.DependsOn("Clean", "Compile");

// Task("Test")
// 	.DependsOn("Build")
// 	.Do(() =>
// 	{
// 		// Invoke the test runner here
// 	});

// Task("Deploy")
// 	.DependsOn("Build")
// 	.Do(() =>
// 	{
// 		// Copy some files to who knows where
// 	});