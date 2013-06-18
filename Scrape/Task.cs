using System;
using System.Collections.Generic;

namespace ScrapePack
{
	public class Task
	{
		private readonly IDynamicServiceLocator _serviceLocator;
		private readonly List<Action> _actions = new List<Action>();

		// TODO: Make internal
		public Task(string taskName, Action<Task> taskPreExecutor, IDynamicServiceLocator serviceLocator)
		{
			_serviceLocator = serviceLocator;
			Name = taskName;
			Dependencies = new string[] { };

			if (taskPreExecutor != null)
				_actions.Add(() => taskPreExecutor(this));
		}

		public string[] Dependencies { get; private set; }

		public string Name { get; private set; }

		public Task Do(Action action)
		{
			_actions.Add(action);
			return this;
		}

		public Task DependsOn(string[] dependencies)
		{
			Dependencies = dependencies;
			return this;
		}

		public void Run()
		{
			foreach (var action in _actions)
				action();
		}

		public Task MsBuild(Action<MsBuildProperties> msBuildConfigurator)
		{
			var buildProperties = new MsBuildProperties();
			msBuildConfigurator(buildProperties);

			var msbuilder = _serviceLocator.Resolve<IMsBuilder>();
			_actions.Add(() => msbuilder.Build(buildProperties));

			return this;
		}
	}
}