using System;
using System.Collections.Generic;

namespace ScrapePack
{
	public class TaskManager
	{
		private readonly Dictionary<string, Task> _tasks = new Dictionary<string, Task>();

		public Task FindTask(string taskName)
		{
			var taskKey = taskName.ToLower();
			Task task;

			if (_tasks.TryGetValue(taskKey, out task))
				return task;

			throw new UndefinedTaskException(String.Format("Could not find the task named '{0}'.", taskName));
		}

		public void AddTask(string taskName, Task task)
		{
			_tasks.Add(taskName.ToLower(), task);
		}

		public Task NewTask(string taskName, Action<Task> initializer)
		{
			var task = new Task(taskName, RunDependencies, new MsBuilder());
			initializer(task);
			AddTask(taskName, task);
			return task;
		}

		private void RunDependencies(Task task)
		{
			foreach (var dependency in task.Dependencies)
				dependency.Do();
		}
	}
}