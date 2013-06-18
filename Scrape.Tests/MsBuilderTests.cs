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
			_msBuilder.Build(new MsBuildProperties()
			{
				Project = "the-project-name.csproj",
				ArbitraryArguments = new[] { "/arbArgument1", "/argArgument2" }
			});

			_msBuildRunner.Received().Run(Arg.Is<string[]>(a => a.Last().Equals("the-project-name.csproj")));
		}

		[Test]
		public void AllArbitraryArgumentsArePassedToMsbuildAsIs()
		{
			var arbitraryArguments = new[] {"/arbArg1", "-arbArg2", "/arbArg3:someValue"};

			_msBuilder.Build(new MsBuildProperties()
				{
					ArbitraryArguments = arbitraryArguments
				});

			// How to check arguments with NSubstitute?
			_msBuildRunner.Received().Run(Arg.Is<string[]>(a => ());
			var actualArguments = GetActualRunnerArguments();
			Assert.That(arbitraryArguments, Is.SubsetOf(actualArguments));
		}

		private object[] GetActualRunnerArguments()
		{
			return _msBuildRunner.ReceivedCalls().First(c => c.GetMethodInfo().Name == "Run").GetArguments();
		}
	}
}