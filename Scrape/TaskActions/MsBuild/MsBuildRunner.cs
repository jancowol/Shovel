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

		private static string[] BuildArguments(MsBuildProperties msBuildProperties)
		{
			var args = new List<string>();

			args.AddRange(msBuildProperties.ArbitraryArguments);

			if (msBuildProperties.NoLogo)
				args.Add("/nologo");

			foreach (var target in msBuildProperties.Targets)
				args.Add("/target:" + target);

			args.Add(msBuildProperties.Project);
			return args.ToArray();
		}
	}
}