using System;

namespace ScrapePack
{
	public static class ScrapeExtensions
	{
		public static Task Do(this string taskName, Action action)
		{
			return Context.TaskManager
				.NewTask(taskName, t => t.Do(action));
		}

		public static Task DependsOn(this string taskName, params string[] dependencies)
		{
			return Context.TaskManager
				.NewTask(taskName, t => t.DependsOn(dependencies));
		}

		public static Task MsBuild(this string taskName, Action<MsBuildPropertyBuilder> msBuildPropertyConfigurator)
		{
			return Context.TaskManager
				.NewTask(taskName, t => { });
		}

		public static void Run(this string taskName)
		{
			Context.TaskManager
				.FindTask(taskName)
				.Run();
		}
	}
}