using System;
using ScrapePack.TaskActions.MsBuild;

namespace ScrapePack
{
	public class TaskActionFactory
	{
		private readonly MsBuildActionBuilder _msBuildActionBuilder;

		public TaskActionFactory(MsBuildActionBuilder msBuildActionBuilder)
		{
			_msBuildActionBuilder = msBuildActionBuilder;
		}

		public Action ConfigureAction<TActionConfigurator>(Action<TActionConfigurator> actionConfigurator)
		{
			var actionBuilder = (IActionBuilder<TActionConfigurator>)_msBuildActionBuilder;
			var action = actionBuilder.ConfigureAction(actionConfigurator);

			return action;
		}
	}
}