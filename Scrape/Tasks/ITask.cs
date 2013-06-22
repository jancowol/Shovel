using System;
using System.Collections.Generic;
using ScrapePack.TaskActions.MsBuild;

namespace ScrapePack.Tasks
{
	public interface ITask
	{
		IEnumerable<string> Dependencies { get; }
		string Name { get; }
		ITask Do(Action action);
		ITask DependsOn(params string[] dependencies);
		void Run();
		ITask MsBuild(Action<MsBuildActionConfigurator> actionConfigurator);
	}
}