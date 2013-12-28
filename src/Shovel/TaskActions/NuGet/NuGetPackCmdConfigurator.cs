namespace ShovelPack.TaskActions.NuGet
{
	// Represents the fluent interface used to create the pack command specification
	public class NuGetPackCmdConfigurator
	{
		public string NuSpec { get; set; }
		public string OutputDirectory { get; set; }

		public NuGetPackSpecification BuildSpecification()
		{
			return new NuGetPackSpecification(NuSpec, OutputDirectory);
		}
	}

	// Represents the immutable pack command specification as built by the configurator
	public class NuGetPackSpecification
	{
		public string NuSpec { get; private set; }
		public string OutputDirectory { get; private set; }

		public NuGetPackSpecification(string nuSpec, string outputDirectory)
		{
			NuSpec = nuSpec;
			OutputDirectory = outputDirectory;
		}
	}
}