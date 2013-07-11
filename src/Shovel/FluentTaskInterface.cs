using System;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.TaskActions.RunProgram;
using ShovelPack.Tasks;

namespace ShovelPack
{
	public static class FluentTaskInterface
	{
		public static ITask Do(this string taskName)
		{
			return Do(taskName, () => { });
		}

		public static ITask Do(this string taskName, Action action)
		{
			return NewTask(taskName, t => t.Do(action));
		}

		public static ITask DependsOn(this string taskName, params string[] dependencies)
		{
			return NewTask(taskName, t => t.DependsOn(dependencies));
		}

		public static ITask MsBuild(this string taskName, Action<MsBuildActionConfigurator> actionConfigurator)
		{
			return NewTask(taskName, t => t.MsBuild(actionConfigurator));
		}

		public static ITask RunProgram(this string taskName, Action<RunProgramConfigurator> programConfigurator)
		{
			return NewTask(taskName, t => t.RunProgram(programConfigurator));
		}

		public static void Run(this string taskName)
		{
			ShovelStaticContext.TaskManager
				.FindTask(taskName)
				.Run();
		}

		private static ITask NewTask(string taskName, Action<ITask> initializer)
		{
			return ShovelStaticContext.TaskManager.NewTask(taskName, initializer);
		}
	}
}