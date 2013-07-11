using System;
using ShovelPack.TaskActionConfig;
using ShovelPack.Utils;

namespace ShovelPack.TaskActions.RunProgram
{
	public class RunProgramActionBuilder : IActionBuilder<RunProgramConfigurator>
	{
		public Action ConfigureAction(Action<RunProgramConfigurator> configure)
		{
			var processProperties = ConfigureProcessProperties(configure);
			return () => RunProcess(processProperties);
		}

		private static ProcessProperties ConfigureProcessProperties(Action<RunProgramConfigurator> programBuilderAction)
		{
			var processProperties = new ProcessProperties();
			var programBuilder = new RunProgramConfigurator(processProperties);

			programBuilderAction(programBuilder);

			return processProperties;
		}

		private static void RunProcess(ProcessProperties processProperties)
		{
			var processRunner = new ProcessRunner();
			processRunner.RunProcess(processProperties);
		}
	}
}