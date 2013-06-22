using System;
using ShovelPack.TaskActionConfig;

namespace ShovelPack.TaskActions.MsBuild
{
	public class MsBuildActionBuilder : IActionBuilder<MsBuildActionConfigurator>
	{
		private readonly IMsBuildRunner _msBuildRunner;

		public MsBuildActionBuilder()
			: this(new MsBuildRunner())
		{
		}

		public MsBuildActionBuilder(IMsBuildRunner msBuildRunner)
		{
			_msBuildRunner = msBuildRunner;
		}

		public Action ConfigureAction(Action<MsBuildActionConfigurator> configure)
		{
			var msBuildProperties = new MsBuildProperties();
			var actionConfigurator = new MsBuildActionConfigurator(msBuildProperties);

			configure(actionConfigurator);

			return
				() => _msBuildRunner.Run(msBuildProperties);
		}
	}
}