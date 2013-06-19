using System.Collections.Generic;

namespace ScrapePack
{
	public class MsBuildPropertyBuilder
	{
		public MsBuildPropertyBuilder()
		{
			ArbitraryArguments = new string[0];
			Targs = new string[0];
		}

		public string Project { get; set; }
		public string[] ArbitraryArguments { get; private set; }
		public string[] Targs { get; private set; }

		public void ArbitraryArgs(params string[] args)
		{
			ArbitraryArguments = args;
		}

		public void Targets(params string[] targets)
		{
			Targs = targets;
		}
	}
}