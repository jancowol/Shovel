using System;
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
}