using System;

namespace ScrapePack
{
	public class Task
	{
		private readonly Action<Task> _taskPreExecutor;
		private Action _action;

		internal Task(string taskName, Action<Task> taskPreExecutor)
		{
			_taskPreExecutor = taskPreExecutor;
			Name = taskName;
			PrecedingTasks = new string[]{};
		}

		public string[] PrecedingTasks { get; private set; }

		public string Name { get; private set; }

		public Task Action(Action action)
		{
			_action = action;
			return this;
		}

		public Task DependsOn(string[] precedingTasks)
		{
			PrecedingTasks = precedingTasks;
			return this;
		}

		public void Do()
		{
			_taskPreExecutor(this);
			_action();
		}
	}
}