using System;
using System.Collections.Generic;
using ShovelPack.TaskActionConfig;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.TaskActions.NuGet;
using ShovelPack.TaskActions.RunProgram;
using ShovelPack.TaskActions.XMLTransformer;

namespace ShovelPack.Tasks
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

		public ITask MsBuild(Action<MsBuildActionConfigurator> configurator)
		{
			return AddNewAction(configurator);
		}

		public ITask RunProgram(Action<RunProgramConfigurator> configurator)
		{
			return AddNewAction(configurator);
		}

		public ITask TransformXml(Action<XmlTransformConfigurator> configurator)
		{
			return AddNewAction(configurator);
		}

		public INuGetCommands NuGet
		{
			get { return new NuGetCommands(this); }
		}

		private ITask AddNewAction<TActionConfigurator>(Action<TActionConfigurator> actionConfigurator)
		{
			_actions.Add(_taskActionFactory.BuildAction(actionConfigurator));
			return this;
		}
	}
}