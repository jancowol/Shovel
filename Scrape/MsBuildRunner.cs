using System.Collections.Generic;

namespace ScrapePack
{
	public class MsBuildRunner : IMsBuildRunner
	{
		private readonly IProcessRunner _processRunner;

		public MsBuildRunner() : this(new ProcessRunner())
		{
		}

		public MsBuildRunner(IProcessRunner processRunner)
		{
			_processRunner = processRunner;
		}

		public void Run(MsBuildPropertyBuilder msbuildPropertyBuilder)
		{
			_processRunner.RunProcess("MSBuild.exe", BuildArguments(msbuildPropertyBuilder));
		}

		private static string[] BuildArguments(MsBuildPropertyBuilder msBuildPropertyBuilder)
		{
			var args = new List<string>();

			args.AddRange(msBuildPropertyBuilder.ArbitraryArguments);

			foreach (var target in msBuildPropertyBuilder.Targs)
				args.Add("/target:" + target);

			args.Add(msBuildPropertyBuilder.Project);
			return args.ToArray();
		}
	}
}