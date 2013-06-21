using System;
using ScrapePack.TaskActions.MsBuild;

namespace ScrapePack
{
	public static class ScrapeExtensions
	{
		public static ITask Do(this string taskName, Action action)
		{
			return Context.TaskManager
				.NewTask(taskName, t => t.Do(action));
		}

		public static ITask DependsOn(this string taskName, params string[] dependencies)
		{
			return Context.TaskManager
				.NewTask(taskName, t => t.DependsOn(dependencies));
		}

		public static ITask MsBuild(this string taskName, Action<MsBuildActionConfigurator> actionConfigurator)
		{
			return Context.TaskManager
				.NewTask(taskName, t => t.MsBuild(actionConfigurator));
		}

		public static void Run(this string taskName)
		{
			Context.TaskManager
				.FindTask(taskName)
				.Run();
		}
	}
}