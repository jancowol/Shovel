using System;
using System.Collections.Generic;
using ScrapePack.TaskActionConfig;
using ScrapePack.TaskActions.MsBuild;

namespace ScrapePack.Tasks
{
	public class Task : ITask
	{
		private readonly List<Action> _actions = new List<Action>();
		private readonly TaskActionFactory _taskActionFactory;

		public Task(string taskName, Action<ITask> taskPreExecutor, TaskActionFactory taskActionFactory)
		{
			Name = taskName;
			Dependencies = new string[] { };
			_taskActionFactory = taskActionFactory;

			if (taskPreExecutor != null)
				_actions.Add(() => taskPreExecutor(this));
		}

		public IEnumerable<string> Dependencies { get; private set; }

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
			AddNewAction(typeof (MsBuildActionBuilder), actionConfigurator);
			return this;
		}

		private void AddNewAction<TActionConfigurator>(Type actionBuilderType, Action<TActionConfigurator> actionConfigurator)
		{
			_actions.Add(
				_taskActionFactory.BuildAction(actionBuilderType, actionConfigurator));
		}
	}
}