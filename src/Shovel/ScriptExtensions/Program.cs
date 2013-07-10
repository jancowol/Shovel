using System;
using ShovelPack.Utils;

namespace ShovelPack.ScriptExtensions
{
	public static class Program
	{
		public static void Run(Action<ProgramConfigurator> programBuilderAction)
		{
			var processProperties = ConfigureProcessProperties(programBuilderAction);
			RunProcess(processProperties);
		}

		private static ProcessProperties ConfigureProcessProperties(Action<ProgramConfigurator> programBuilderAction)
		{
			var processProperties = new ProcessProperties();
			var programBuilder = new ProgramConfigurator(processProperties);

			programBuilderAction(programBuilder);

			return processProperties;
		}

		private static void RunProcess(ProcessProperties processProperties)
		{
			var processRunner = new ProcessRunner();
			processRunner.RunProcess(processProperties);
		}

		public class ProgramConfigurator
		{
			private readonly ProcessProperties _properties;

			public ProgramConfigurator(ProcessProperties properties)
			{
				_properties = properties;
			}

			public string Executable
			{
				set { _properties.Executable = value; }
			}

			public void Arguments(params string[] arguments)
			{
				_properties.Arguments = arguments;
			}
		}
	}
}