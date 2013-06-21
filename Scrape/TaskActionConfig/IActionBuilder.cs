using System;

namespace ScrapePack.TaskActionConfig
{
	public interface IActionBuilder<out TActionConfigurator>
	{
		Action ConfigureAction(Action<TActionConfigurator> configure);
	}
}