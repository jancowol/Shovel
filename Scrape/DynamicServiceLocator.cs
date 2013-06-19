using System;

namespace ScrapePack
{
	public class DynamicServiceLocator : IDynamicServiceLocator
	{
		public TService Resolve<TService>() where TService : class
		{
			// TODO: Implement proper service locator
			if (typeof(TService) == typeof(IMsBuildRunner))
			{
				return (new MsBuildRunner()) as TService;
			}

			throw new Exception(string.Format("The requested type {0} has not been registered with the service locator", typeof(TService).Name));
		}
	}
}