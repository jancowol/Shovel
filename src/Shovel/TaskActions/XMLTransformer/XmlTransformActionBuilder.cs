using System;
using ShovelPack.TaskActionConfig;

namespace ShovelPack.TaskActions.XMLTransformer
{
	public class XmlTransformActionBuilder : IActionBuilder<XmlTransformConfigurator>
	{
		public Action ConfigureAction(Action<XmlTransformConfigurator> configure)
		{
			var configurator = new XmlTransformConfigurator();
			configure(configurator);
			return () =>
				{
					var transformer = new XmlTransformer();
					transformer.Transform(configurator.Source, configurator.Transform, configurator.Destination);
				};
		}
	}
}