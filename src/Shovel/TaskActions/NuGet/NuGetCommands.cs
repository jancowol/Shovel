using System;
using ShovelPack.TaskActions.RunProgram;
using ShovelPack.Tasks;

namespace ShovelPack.TaskActions.NuGet
{
	public class NuGetCommands : INuGetCommands
	{
		private const string NuGetExePath = "bin\\Nuget.exe";
		private readonly ITask _task;

		public NuGetCommands(ITask task)
		{
			_task = task;
		}

		public ITask Pack(Action<NuGetPackCmdConfigurator> packConfigurator)
		{
			_task.Do(
				BuildNugetPackAction(packConfigurator));

			return _task;
		}

		private static Action BuildNugetPackAction(Action<NuGetPackCmdConfigurator> packConfigurator)
		{
			var packConfiguration = ConfigureNugetPackAction(packConfigurator);
			return BuildNugetPackRunner(packConfiguration);
		}

		private static Action BuildNugetPackRunner(NuGetPackCmdConfigurator packConfiguration)
		{
			var runProgramBuilder = new RunProgramActionBuilder();
			return runProgramBuilder.ConfigureAction(c =>
				{
					c.Executable = NuGetExePath;
					c.Arguments("pack", packConfiguration.NuSpec, "-OutputDirectory", packConfiguration.OutputDirectory);
				});
		}

		private static NuGetPackCmdConfigurator ConfigureNugetPackAction(Action<NuGetPackCmdConfigurator> packConfigurator)
		{
			var configurator = new NuGetPackCmdConfigurator();
			packConfigurator(configurator);
			return configurator;
		}
	}
}