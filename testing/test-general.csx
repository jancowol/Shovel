Require<Shovel>();

"TheTask".Do()
	.Do(() =>
	{
		Console.WriteLine("Testing empty task definition with subsequent action...");
	});