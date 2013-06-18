namespace ScrapePack
{
	public interface IDynamicServiceLocator
	{
		TService Resolve<TService>() where TService : class;
	}
}