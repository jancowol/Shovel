using System;
using System.Collections.Generic;
using ScrapePack.TaskActions.MsBuild;

namespace ScrapePack
{
	public interface ITaskManager
	{
		ITask FindTask(string taskName);
		void AddTask(string taskName, Task task);
		ITask NewTask(string taskName, Action<ITask> initializer);
	}

	public class TaskManager : ITaskManager
	{
		private readonly Dictionary<string, ITask> _tasks = new Dictionary<string, ITask>();

		public ITask FindTask(string taskName)
		{
			var taskKey = taskName.ToLower();
			ITask task;

			if (_tasks.TryGetValue(taskKey, out task))
				return task;

			throw new UndefinedTaskException(String.Format("Could not find the task named '{0}'.", taskName));
		}

		public void AddTask(string taskName, Task task)
		{
			_tasks.Add(taskName.ToLower(), task);
		}

		public ITask NewTask(string taskName, Action<ITask> initializer)
		{
			var task = new Task(taskName, RunDependencies, new MsBuildActionBuilder());
			initializer(task);
			AddTask(taskName, task);
			return task;
		}

		private void RunDependencies(ITask task)
		{
			foreach (var dependency in task.Dependencies)
				dependency.Run();
		}
	}
}