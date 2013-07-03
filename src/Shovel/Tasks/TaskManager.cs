using System;
using System.Collections.Generic;
using ShovelPack.TaskActionConfig;

namespace ShovelPack.Tasks
{
	public class TaskManager : ITaskManager
	{
		private readonly Dictionary<string, ITask> _tasks = new Dictionary<string, ITask>();

		public ITask NewTask(string taskName)
		{
			return NewTask(taskName, t => { });
		}

		public ITask NewTask(string taskName, Action<ITask> initializer)
		{
			GuardAgainstDuplicateTaskName(taskName);

			var task = new Task(taskName, RunDependencies, new TaskActionFactory());
			initializer(task);
			AddTask(taskName, task);

			return task;
		}

		public void RunTasks(params string[] taskNames)
		{
			foreach (var taskName in taskNames)
				FindTask(taskName).Run();
		}

		public ITask FindTask(string taskName)
		{
			var taskKey = MakeTaskKey(taskName);
			ITask task;

			if (_tasks.TryGetValue(taskKey, out task))
				return task;

			throw new UndefinedTaskException(String.Format("Could not find the task named '{0}'.", taskName));
		}

		private void AddTask(string taskName, ITask task)
		{
			_tasks.Add(taskName.ToLower(), task);
		}

		// TODO: Very simplistic way of running dependencies. Does not take into account the possibility of running the same dependency more than once. Fix.
		private void RunDependencies(ITask task)
		{
			foreach (var dependency in task.Dependencies)
				dependency.Run();
		}

		private void GuardAgainstDuplicateTaskName(string taskName)
		{
			if (_tasks.ContainsKey(MakeTaskKey(taskName)))
			{
				throw new DuplicateTaskException(string.Format("A task with the name '{0}' has alread been defined.", taskName));
			}
		}

		private static string MakeTaskKey(string taskName)
		{
			return taskName.ToLower();
		}
	}
}