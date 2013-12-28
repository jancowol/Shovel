using System;
using ShovelPack.Tasks;

namespace ShovelPack.TaskActions.NuGet
{
	public class NuGetCommands : INuGetCommands
	{
		private readonly ITask _task;
		private readonly NuGetPackageBuilder _nuGetPackageBuilder;

		public NuGetCommands(ITask task)
		{
			_task = task;
			_nuGetPackageBuilder = new NuGetPackageBuilder();
		}

		public ITask Pack(Action<NuGetPackCmdConfigurator> packConfigurator)
		{
			_task.Do(
				BuildNugetPackAction(packConfigurator));

			return _task;
		}

		private Action BuildNugetPackAction(Action<NuGetPackCmdConfigurator> packConfigurator)
		{
			return () =>
			{
				var configurator = new NuGetPackCmdConfigurator();
				packConfigurator(configurator);
				_nuGetPackageBuilder.BuildNuGetPackage((INuGetPackConfiguration) configurator);
			};
		}
	}
}