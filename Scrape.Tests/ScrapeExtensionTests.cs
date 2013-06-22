using System;
using NSubstitute;
using NUnit.Framework;
using ScrapePack;
using ScrapePack.TaskActions.MsBuild;
using ScrapePack.Tasks;

namespace Scrape.Tests
{
	[TestFixture]
	public class ScrapeExtensionTests
	{
		private ITaskManager _originalTaskManager;
		private ITaskManager _fakeTaskManager;

		[SetUp]
		public void Setup()
		{
			_originalTaskManager = Context.TaskManager;
			_fakeTaskManager = Substitute.For<ITaskManager>();
			Context.TaskManager = _fakeTaskManager;
		}

		[Test]
		public void MsBuildInitializesTaskCorrectly()
		{
			var task = Substitute.For<ITask>();
			_fakeTaskManager.NewTask(Arg.Any<string>(), Arg.Any<Action<ITask>>()).Returns(task);
			Context.TaskManager = _fakeTaskManager;
			Action<MsBuildActionConfigurator> msBuildPropertyConfigurator = msb => msb.Project = "the-project-to-build";
			"SomeMsBuildTask".MsBuild(msBuildPropertyConfigurator);
			_fakeTaskManager.Received().NewTask("SomeMsBuildTask", Arg.Any<Action<ITask>>());
		}

		[TearDown]
		public void Cleanup()
		{
			Context.TaskManager = _originalTaskManager;
		}
	}
}