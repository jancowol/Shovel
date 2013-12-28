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
					var packSpecification = BuildPackSpecification(packConfigurator);
					_nuGetPackageBuilder.BuildNuGetPackage(packSpecification);
				};
		}

		private static NuGetPackSpecification BuildPackSpecification(Action<NuGetPackCmdConfigurator> packConfigurator)
		{
			var configurator = new NuGetPackCmdConfigurator();
			packConfigurator(configurator);
			return configurator.BuildSpecification();
		}
	}
}