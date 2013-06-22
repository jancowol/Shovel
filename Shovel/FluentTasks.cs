using System;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.Tasks;

namespace ShovelPack
{
	public static class FluentTasks
	{
		public static ITask Do(this string taskName, Action action)
		{
			return TaskManagerContext.TaskManager
				.NewTask(taskName, t => t.Do(action));
		}

		public static ITask DependsOn(this string taskName, params string[] dependencies)
		{
			return TaskManagerContext.TaskManager
				.NewTask(taskName, t => t.DependsOn(dependencies));
		}

		public static ITask MsBuild(this string taskName, Action<MsBuildActionConfigurator> actionConfigurator)
		{
			return TaskManagerContext.TaskManager
				.NewTask(taskName, t => t.MsBuild(actionConfigurator));
		}

		public static void Run(this string taskName)
		{
			TaskManagerContext.TaskManager
				.FindTask(taskName)
				.Run();
		}
	}
}