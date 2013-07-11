using System;
using ShovelPack.TaskActions.RunProgram;

namespace ShovelPack.ScriptExtensions
{
	public static class Program
	{
		public static void Run(Action<RunProgramConfigurator> programBuilderAction)
		{
			var runActionBuilder = new RunProgramActionBuilder();
			var action = runActionBuilder.ConfigureAction(programBuilderAction);
			action.Invoke();
		}
	}
}