using System.Collections.Generic;

namespace ScrapePack.TaskActions.MsBuild
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

		public void Run(MsBuildProperties msBuildProperties)
		{
			_processRunner.RunProcess("MSBuild.exe", BuildArguments(msBuildProperties));
		}

		private static string[] BuildArguments(MsBuildProperties msBuildPropertyBuilder)
		{
			var args = new List<string>();

			args.AddRange(msBuildPropertyBuilder.ArbitraryArguments);

			foreach (var target in msBuildPropertyBuilder.Targets)
				args.Add("/target:" + target);

			args.Add(msBuildPropertyBuilder.Project);
			return args.ToArray();
		}
	}
}