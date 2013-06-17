using System;

namespace ScrapePack
{
	public static class ScrapeExtensions
	{
		public static Task Action(this string taskName, Action action)
		{
			return Context.TaskManager
				.NewTask(taskName, t => t.Action(action));
		}

		public static Task DependsOn(this string taskName, params string[] dependencies)
		{
			return Context.TaskManager
				.NewTask(taskName, t => t.DependsOn(dependencies));
		}

		public static void Do(this string taskName)
		{
			Context.TaskManager
				.FindTask(taskName)
				.Do();
		}
	}
}