using ShovelPack.Utils;

namespace ShovelPack.TaskActions.RunProgram
{
	public class RunProgramConfigurator
	{
		private readonly ProcessProperties _properties;

		public RunProgramConfigurator(ProcessProperties properties)
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