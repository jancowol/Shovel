using System;
using System.Text;
using ShovelPack.Tasks;

namespace ShovelPack
{
	public class ShovelRunner
	{
		private readonly ITaskManager _taskManager;
		private readonly Arguments _arguments;

		public ShovelRunner(ITaskManager taskManager) : this(taskManager, new Arguments(Environment.GetCommandLineArgs()))
		{
		}

		public ShovelRunner(ITaskManager taskManager, Arguments arguments)
		{
			_taskManager = taskManager;
			_arguments = arguments;
		}

		public void Execute()
		{
			var errorOutput = new StringBuilder();

			try
			{
				if (_arguments.TasksToRun != null)
					_taskManager.RunTasks(_arguments.TasksToRun);
			}
			catch (UndefinedTaskException e)
			{
				// Common error, keep the output clean (no call stack in output)
				errorOutput.AppendLine(e.Message);
			}
			catch (Exception e)
			{
				errorOutput.AppendLine(e.ToString());
			}

			if (errorOutput.Length != 0)
			{
				Console.Error.Write("SHOVEL_ERROR: ");
				Console.Error.Write(errorOutput);
			}
		}
	}
}