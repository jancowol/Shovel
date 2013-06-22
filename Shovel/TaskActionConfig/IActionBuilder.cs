using System;

namespace ShovelPack.TaskActionConfig
{
	public interface IActionBuilder<out TActionConfigurator>
	{
		Action ConfigureAction(Action<TActionConfigurator> configure);
	}
}