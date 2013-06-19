using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ScrapePack;

namespace Scrape.Tests
{
	[TestFixture]
	public class MsBuilderTests
	{
		private IMsBuildRunner _msBuildRunner;
		private MsBuilder _msBuilder;

		[SetUp]
		public void Setup()
		{
			_msBuildRunner = Substitute.For<IMsBuildRunner>();
			_msBuilder = new MsBuilder(_msBuildRunner);
		}

		[Test]
		public void ProjectNameShoudBeLastArgumentToMsBuild()
		{
			var properties = new MsBuildProperties();
			properties.Project = "the-project-name.csproj";
			properties.ArbitraryArgs("/arbArgument1", "/argArgument2");

			_msBuilder.Build(properties);

			_msBuildRunner.Received()
				.Run(
					Arg.Is<string[]>(args => args.Last().Equals("the-project-name.csproj")));
		}

		[Test]
		public void AllArbitraryArgumentsArePassedToMsbuildAsIs()
		{
			var arbitraryArguments = new[] { "/arbArg1", "-arbArg2", "/arbArg3:someValue" };

			var properties = new MsBuildProperties();
			properties.ArbitraryArgs(arbitraryArguments);

			_msBuilder.Build(properties);

			_msBuildRunner.Received()
				.Run(
					Arg.Is<string[]>(args => arbitraryArguments.IsSubsetOf(args)));
		}
	}
}