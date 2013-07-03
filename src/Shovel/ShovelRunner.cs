using ShovelPack.Tasks;

namespace ShovelPack
{
	public class ShovelRunner
	{
		private readonly ITaskManager _taskManager;
		private readonly Arguments _arguments;

		public ShovelRunner(ITaskManager taskManager, Arguments arguments)
		{
			_taskManager = taskManager;
			_arguments = arguments;
		}

		public void Execute()
		{
			if (_arguments.TasksToRun != null)
				_taskManager.RunTasks(_arguments.TasksToRun);
		}
	}
}