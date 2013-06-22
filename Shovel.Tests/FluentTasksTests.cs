using System;
using NSubstitute;
using NUnit.Framework;
using ShovelPack;
using ShovelPack.TaskActions.MsBuild;
using ShovelPack.Tasks;

namespace Shovel.Tests
{
	[TestFixture]
	public class FluentTasksTests
	{
		private ITaskManager _originalTaskManager;
		private ITaskManager _fakeTaskManager;

		[SetUp]
		public void Setup()
		{
			_originalTaskManager = TaskManagerContext.TaskManager;
			_fakeTaskManager = Substitute.For<ITaskManager>();
			TaskManagerContext.TaskManager = _fakeTaskManager;
		}

		[Test]
		public void MsBuildInitializesTaskCorrectly()
		{
			var task = Substitute.For<ITask>();
			_fakeTaskManager.NewTask(Arg.Any<string>(), Arg.Any<Action<ITask>>()).Returns(task);
			TaskManagerContext.TaskManager = _fakeTaskManager;
			Action<MsBuildActionConfigurator> msBuildPropertyConfigurator = msb => msb.Project = "the-project-to-build";
			"SomeMsBuildTask".MsBuild(msBuildPropertyConfigurator);
			_fakeTaskManager.Received().NewTask("SomeMsBuildTask", Arg.Any<Action<ITask>>());
		}

		[TearDown]
		public void Cleanup()
		{
			TaskManagerContext.TaskManager = _originalTaskManager;
		}
	}
}