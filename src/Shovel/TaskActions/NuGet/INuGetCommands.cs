using System;
using ShovelPack.Tasks;

namespace ShovelPack.TaskActions.NuGet
{
	public interface INuGetCommands
	{
		ITask Pack(Action<NuGetPackCmdConfigurator> packConfigurator);
	}
}