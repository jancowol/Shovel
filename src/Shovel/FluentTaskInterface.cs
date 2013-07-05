using System;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.Tasks;

namespace ShovelPack
{
	public static class FluentTaskInterface
	{
		public static ITask Do(this string taskName, Action action)
		{
			return ShovelStaticContext.TaskManager
				.NewTask(taskName, t => t.Do(action));
		}

		public static ITask DependsOn(this string taskName, params string[] dependencies)
		{
			return ShovelStaticContext.TaskManager
				.NewTask(taskName, t => t.DependsOn(dependencies));
		}

		public static ITask MsBuild(this string taskName, Action<MsBuildActionConfigurator> actionConfigurator)
		{
			return ShovelStaticContext.TaskManager
				.NewTask(taskName, t => t.MsBuild(actionConfigurator));
		}

		public static void Run(this string taskName)
		{
			ShovelStaticContext.TaskManager
				.FindTask(taskName)
				.Run();
		}
	}
}