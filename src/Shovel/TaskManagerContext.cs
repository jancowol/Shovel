using ShovelPack.Tasks;

namespace ShovelPack
{
	internal static class TaskManagerContext
	{
		public static ITaskManager TaskManager { get; private set; }

		public static void Initialize()
		{
			Initialize(new TaskManager());
		}

		public static void Initialize(ITaskManager taskManager)
		{
			TaskManager = taskManager;
		}
	}
}