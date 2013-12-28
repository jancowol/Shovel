using System.IO;
using NuGet;

namespace ShovelPack.TaskActions.NuGet
{
	public class NuGetPackageBuilder
	{
		public void BuildNuGetPackage(NuGetPackSpecification packConfiguration)
		{
			var packageBuilder = new PackageBuilder(packConfiguration.NuSpec, NullPropertyProvider.Instance, true);
			var packagePath = Path.Combine(packConfiguration.OutputDirectory, GetDefaultPackagePath(packageBuilder));
			var packageStream = File.Create(packagePath);
			packageBuilder.Save(packageStream);
		}

		private static string GetDefaultPackagePath(PackageBuilder builder)
		{
			var version = builder.Version.ToString();
			return builder.Id + "." + version + Constants.PackageExtension;
		}
	}
}