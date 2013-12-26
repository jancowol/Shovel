using System;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.TaskActions.RunProgram;
using ShovelPack.TaskActions.XMLTransformer;

namespace ShovelPack.TaskActionConfig
{
	public class TaskActionFactory
	{
		public Action BuildAction<TActionConfigurator>(Action<TActionConfigurator> actionConfigurator)
		{
			if (actionConfigurator is Action<MsBuildActionConfigurator>)
			{
				var builder = new MsBuildActionBuilder();
				return builder.ConfigureAction(actionConfigurator as Action<MsBuildActionConfigurator>);
			}

			if (actionConfigurator is Action<RunProgramConfigurator>)
			{
				var builder = new RunProgramActionBuilder();
				return builder.ConfigureAction(actionConfigurator as Action<RunProgramConfigurator>);
			}

			if (actionConfigurator is Action<XmlTransformConfigurator>)
			{
				var builder = new XmlTransformActionBuilder();
				return builder.ConfigureAction(actionConfigurator as Action<XmlTransformConfigurator>);
			}

			// TODO: Implement with proper exception
			throw new Exception("Unknown builder!");
		}
	}
}