using System;
using System.Collections.Generic;

namespace ScrapePack
{
	public static class ScrapeExtensions
	{
		private static Dictionary<string, Task> _tasks = new Dictionary<string, Task>();

		internal static void Clear()
		{
			_tasks = new Dictionary<string, Task>();
		}

		public static Task Action(this string taskName, Action action)
		{
			return NewTask(taskName, t => t.Action(action));
		}

		public static Task DependsOn(this string taskName, params string[] precedingTasks)
		{
			return NewTask(taskName, t => t.DependsOn(precedingTasks));
		}

		public static void Do(this string taskName)
		{
			var task = FindTask(taskName);
			task.Do();
		}

		private static void DoPrecedingTaskFor(Task task)
		{
			foreach (var precedingTask in task.PrecedingTasks)
				precedingTask.Do();
		}

		private static Task FindTask(string taskName)
		{
			var taskKey = taskName.ToLower();
			Task task;

			if (_tasks.TryGetValue(taskKey, out task))
				return task;

			throw new UndefinedTaskException(string.Format("Could not find the task named '{0}'.", taskName));
		}

		private static Task NewTask(string taskName, Action<Task> initializer)
		{
			var task = new Task(taskName, DoPrecedingTaskFor);
			initializer(task);
			_tasks.Add(taskName.ToLower(), task);
			return task;
		}
	}
}