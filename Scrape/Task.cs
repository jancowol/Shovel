using System;
using System.Collections.Generic;
using ScrapePack.TaskActions.MsBuild;

namespace ScrapePack
{
	public interface ITask
	{
		string[] Dependencies { get; }
		string Name { get; }
		ITask Do(Action action);
		ITask DependsOn(string[] dependencies);
		void Run();
		ITask MsBuild(Action<MsBuildActionConfigurator> actionConfigurator);
	}

	public class Task : ITask
	{
		private readonly List<Action> _actions = new List<Action>();
		private readonly TaskActionFactory _taskActionFactory;

		public Task(string taskName, Action<ITask> taskPreExecutor, MsBuildActionBuilder msBuildActionBuilder)
		{
			Name = taskName;
			Dependencies = new string[] { };

			_taskActionFactory = new TaskActionFactory(msBuildActionBuilder);
			if (taskPreExecutor != null)
				_actions.Add(() => taskPreExecutor(this));
		}

		public string[] Dependencies { get; private set; }

		public string Name { get; private set; }

		public void Run()
		{
			foreach (var action in _actions)
				action();
		}

		public ITask Do(Action action)
		{
			_actions.Add(action);
			return this;
		}

		public ITask DependsOn(string[] dependencies)
		{
			Dependencies = dependencies;
			return this;
		}

		public ITask MsBuild(Action<MsBuildActionConfigurator> actionConfigurator)
		{
			AddNewAction(actionConfigurator);
			return this;
		}

		private void AddNewAction<TActionConfigurator>(Action<TActionConfigurator> actionConfigurator)
		{
			_actions.Add(
				_taskActionFactory.ConfigureAction(actionConfigurator));
		}
	}
}