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
			Dependencies = new string[]{};
		}

		public string[] Dependencies { get; private set; }

		public string Name { get; private set; }

		public Task Action(Action action)
		{
			_action = action;
			return this;
		}

		public Task DependsOn(string[] dependencies)
		{
			Dependencies = dependencies;
			return this;
		}

		public void Do()
		{
			_taskPreExecutor(this);
			_action();
		}
	}
}