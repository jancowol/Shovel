using ShovelPack.Utils;

namespace ShovelPack.TaskActions.NuGet
{
	public class NuGetPackageBuilder
	{
		private const string NuGetExePath = "bin\\Nuget.exe";

		public void BuildNuGetPackage(INuGetPackConfiguration packConfiguration)
		{
			var processRunner = new ProcessRunner();
			processRunner.RunProcess(new ProcessProperties()
				{
					Arguments = new[] {"pack", packConfiguration.NuSpec, "-OutputDirectory", packConfiguration.OutputDirectory},
					Executable = NuGetExePath
				});
		}
	}
}