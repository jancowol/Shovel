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
			DeleteAllNuGetPackages();

			var builder = new NuGetPackageBuilder(@"..\..\..\..\tools\NuGet\NuGet.exe");
			builder.BuildNuGetPackage(new NuGetPackCmdConfigurator() { NuSpec = @"Acceptance\NuGet\test-nuget-pack.nuspec", OutputDirectory = "." });

			Assert.IsTrue(GetPackageFileList().Any(), "No NuGet package files found");
		}

		private static void DeleteAllNuGetPackages()
		{
			GetPackageFileList()
				.ForEach(File.Delete);
		}

		private static List<string> GetPackageFileList()
		{
			return
				Directory.EnumerateFiles(".", "*.nupkg")
				.ToList();
		}
	}
}