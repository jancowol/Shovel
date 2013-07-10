using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.Utils;

namespace Shovel.Tests
{
	[TestFixture]
	public class MsBuildRunnerTests
	{
		private IProcessRunner _processRunner;
		private MsBuildRunner _msBuildRunner;

		[SetUp]
		public void Setup()
		{
			_processRunner = Substitute.For<IProcessRunner>();
			_msBuildRunner = new MsBuildRunner(_processRunner);
		}

		[Test]
		public void ProjectNameShoudBeLastArgumentToMsBuild()
		{
			var properties = new MsBuildProperties
				{
					Project = "the-project-name.csproj",
					ArbitraryArguments = new[] { "/arbArgument1", "/argArgument2" }
				};

			_msBuildRunner.Run(properties);

			_processRunner.Received()
				.RunProcess(Arg.Is<ProcessProperties>(pp => pp.Arguments.Last().Equals("the-project-name.csproj")));
		}

		[Test]
		public void AllArbitraryArgumentsArePassedToMsbuildAsIs()
		{
			var arbitraryArguments = new[] { "/arbArg1", "-arbArg2", "/arbArg3:someValue" };
			var properties = new MsBuildProperties { ArbitraryArguments = arbitraryArguments };

			_msBuildRunner.Run(properties);

			_processRunner.Received()
				.RunProcess(Arg.Is<ProcessProperties>(pp => arbitraryArguments.IsSubsetOf(pp.Arguments)));
		}

		[Test]
		public void AllTargetsArePassedToMsBuildInCorrectFormat()
		{
			var properties = new MsBuildProperties { Targets = new[] { "Clean", "Compile" } };

			_msBuildRunner.Run(properties);

			_processRunner.Received()
				.RunProcess(Arg.Is<ProcessProperties>(pp => new[] { "/target:Clean", "/target:Compile" }.IsSubsetOf(pp.Arguments)));
		}

		[Test]
		public void WhenNoLogoSpecifiedTheSwitchIsPassedToMsBuild()
		{
			var properties = new MsBuildProperties { NoLogo = true };

			_msBuildRunner.Run(properties);

			_processRunner.Received()
				.RunProcess(Arg.Is<ProcessProperties>(pp => pp.Arguments.Contains("/nologo")));
		}
	}
}