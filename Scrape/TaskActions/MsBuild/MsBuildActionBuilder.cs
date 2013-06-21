using System;

namespace ScrapePack.TaskActions.MsBuild
{
	public interface IActionBuilder<out TConfigurationBuilder>
	{
		Action ConfigureAction(Action<TConfigurationBuilder> configureMsBuild);
	}

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

		public Action ConfigureAction(Action<MsBuildActionConfigurator> configureMsBuild)
		{
			var msBuildProperties = new MsBuildProperties();
			var actionConfigurator = new MsBuildActionConfigurator(msBuildProperties);

			configureMsBuild(actionConfigurator);

			return
				() => _msBuildRunner.Run(msBuildProperties);
		}
	}
}