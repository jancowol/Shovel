namespace ScrapePack
{
	public class MsBuildProperties
	{
		public MsBuildProperties()
		{
			ArbitraryArguments = new string[0];
		}

		public string Project { get; set; }
		public string[] ArbitraryArguments { get; private set; }

		public void ArbitraryArgs(params string[] args)
		{
			ArbitraryArguments = args;
		}
	}
}