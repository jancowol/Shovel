namespace ShovelPack.TaskActions.NuGet
{
	public interface INuGetPackConfiguration
	{
		string NuSpec { get; }
		string OutputDirectory { get; }
	}

	public class NuGetPackCmdConfigurator : INuGetPackConfiguration
	{
		public string NuSpec { get; set; }
		public string OutputDirectory { get; set; }
	}
}