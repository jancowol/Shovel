using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using ShovelPack.TaskActions.NuGet;

namespace ShovelPack.Tests.TaskActions.NuGet
{
	[TestFixture]
	public class NuGetPackageBuilderTests
	{
		[Test]
		public void CanBuildNuGetPackage()
		{
			DeleteAllNuGetPackageFiles();

			var builder = new NuGetPackageBuilder();
			builder.BuildNuGetPackage(new NuGetPackSpecification(@"Acceptance\NuGet\test-nuget-pack.nuspec", "."));

			Assert.IsTrue(GetPackageFileList().Any(), "No NuGet package files found");
		}

		private static void DeleteAllNuGetPackageFiles()
		{
			GetPackageFileList()
				.ToList()
				.ForEach(File.Delete);
		}

		private static IEnumerable<string> GetPackageFileList()
		{
			return Directory.EnumerateFiles(".", "*.nupkg");
		}
	}
}