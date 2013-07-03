using System;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.Tasks;

namespace ShovelPack
{
	public static class FluentTaskInterface
	{
		public static ITask Do(this string taskName, Action action)
		{
			return ShovelContext.TaskManager
				.NewTask(taskName, t => t.Do(action));
		}

		public static ITask DependsOn(this string taskName, params string[] dependencies)
		{
			return ShovelContext.TaskManager
				.NewTask(taskName, t => t.DependsOn(dependencies));
		}

		public static ITask MsBuild(this string taskName, Action<MsBuildActionConfigurator> actionConfigurator)
		{
			return ShovelContext.TaskManager
				.NewTask(taskName, t => t.MsBuild(actionConfigurator));
		}

		public static void Run(this string taskName)
		{
			ShovelContext.TaskManager
				.FindTask(taskName)
				.Run();
		}
	}
}