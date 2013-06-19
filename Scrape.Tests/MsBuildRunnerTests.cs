﻿using System;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using ScrapePack;

namespace Scrape.Tests
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
			var properties = new MsBuildPropertyBuilder();
			properties.Project = "the-project-name.csproj";
			properties.ArbitraryArgs("/arbArgument1", "/argArgument2");

			_msBuildRunner.Run(properties);

			_processRunner.Received()
				.RunProcess(
					Arg.Any<string>(),
					Arg.Is<string[]>(args => args.Last().Equals("the-project-name.csproj")));
		}

		[Test]
		public void AllArbitraryArgumentsArePassedToMsbuildAsIs()
		{
			var arbitraryArguments = new[] { "/arbArg1", "-arbArg2", "/arbArg3:someValue" };
			var properties = new MsBuildPropertyBuilder();
			properties.ArbitraryArgs(arbitraryArguments);

			_msBuildRunner.Run(properties);

			_processRunner.Received()
				.RunProcess(
					Arg.Any<string>(),
					Arg.Is<string[]>(args => arbitraryArguments.IsSubsetOf(args)));
		}

		[Test]
		public void AllTargetsArePassedToMsBuildInCorrectFormat()
		{
			var properties = new MsBuildPropertyBuilder();
			properties.Targets("Clean", "Compile");

			_msBuildRunner.Run(properties);

			_processRunner.Received()
				.RunProcess(
					Arg.Any<string>(),
					Arg.Is<string[]>(args => new[] { "/target:Clean", "/target:Compile" }.IsSubsetOf(args)));
		}
	}
}