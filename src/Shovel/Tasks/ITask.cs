using System;
using System.Collections.Generic;
using ShovelPack.ScriptExtensions;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.TaskActions.NuGet;
using ShovelPack.TaskActions.RunProgram;

namespace ShovelPack.Tasks
{
	public interface ITask
	{
		IEnumerable<string> Dependencies { get; }
		string Name { get; }
		INuGetCommands NuGet { get; }
		ITask Do(Action action);
		ITask DependsOn(params string[] dependencies);
		void Run();
		ITask MsBuild(Action<MsBuildActionConfigurator> actionConfigurator);
		ITask RunProgram(Action<RunProgramConfigurator> programConfigurator);
	}
}