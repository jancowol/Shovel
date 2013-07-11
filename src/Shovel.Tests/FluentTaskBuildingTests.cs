using System;
using NUnit.Framework;
using ShovelPack;
using ShovelPack.Tasks;

namespace Shovel.Tests
{
	[TestFixture]
	public class FluentTaskBuildingTests : ShovelAcceptanceTestsBase
	{
		[Test]
		public void CanDefineNewTaskFromAction()
		{
			AssertValidTaskBuiltFromFluentExtension(
				taskName => taskName.Do(() => { }));
		}

		[Test]
		public void CanDefineNewTaskFromDependsOn()
		{
			AssertValidTaskBuiltFromFluentExtension(
				taskName => taskName.DependsOn("TaskItsDependentOn"));
		}

		[Test]
		public void CanDefineNewEmptyTask()
		{
			AssertValidTaskBuiltFromFluentExtension(
				taskName => taskName.Do());
		}

		[Test]
		public void CanDefineNewTaskFromMsBuild()
		{
			AssertValidTaskBuiltFromFluentExtension(
				taskName => taskName.MsBuild(msb => { }));
		}

		private static void AssertValidTaskBuiltFromFluentExtension(Func<string, ITask> builder)
		{
			const string taskName = "MyNewTask";

			var task = builder(taskName);

			Assert.That(task, Is.Not.Null);
			Assert.That(task.Name, Is.EqualTo(taskName));
		}
	}
}
