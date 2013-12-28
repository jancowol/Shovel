using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace ShovelPack.Tests.Acceptance.NuGet
{
	[TestFixture]
	public class NuGetPackAcceptanceTests : ShovelAcceptanceTestsBase
	{
		[Test]
		public void GivenAManifestFile_WhenThePackTaskIsRun_ThenANugetPackageIsCreated()
		{
			DeleteAllNuGetPackageFiles();

			"Pack"
				.Do()
				.NuGet.Pack(n =>
					{
						n.NuSpec = @"Acceptance\NuGet\test-nuget-pack.nuspec";
						n.OutputDirectory = @".";
					})
				.Run();

			Assert.That(GetPackageFileList().Any(), "No NuGet package files found");
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