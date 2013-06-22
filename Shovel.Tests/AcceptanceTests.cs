using System.Collections.Generic;
using NUnit.Framework;
using ShovelPack;
using ShovelPack.Tasks;

namespace Shovel.Tests
{
	[TestFixture]
	public class AcceptanceTests : ShovelAcceptanceTestsBase
	{
		[Test]
		public void CanExecuteTaskByName()
		{
			var wasExecuted = false;
			"TheTaskName".Do(() => wasExecuted = true);
			"TheTaskName".Run();

			Assert.That(wasExecuted, Is.True);
		}

		[Test]
		public void TaskNamesAreCaseInsensitive()
		{
			var wasExecuted = false;
			"TheTaskName".Do(() => wasExecuted = true);
			"thetaskname".Run();

			Assert.That(wasExecuted, Is.True);
		}

		[Test]
		public void ExecutingNonExistentTaskThrowsUsefulException()
		{
			Assert.That(() => "UndefinedTask".Run(),
				Throws.InstanceOf<UndefinedTaskException>()
					.And.Message.EqualTo("Could not find the task named 'UndefinedTask'."));
		}

		[Test]
		public void ExecutingTaskRunsDependenciesFirst()
		{
			var taskExecutionOrder = new List<string>();

			"TheTask"
				.DependsOn("Dependency1", "Dependency2", "Dependency3")
				.Do(() => taskExecutionOrder.Add("TheTask"));

			"Dependency1"
				.Do(() => taskExecutionOrder.Add("Dependency1"));

			"Dependency2"
				.Do(() => taskExecutionOrder.Add("Dependency2"));

			"Dependency3"
				.Do(() => taskExecutionOrder.Add("Dependency3"));

			"TheTask".Run();

			Assert.That(taskExecutionOrder, Is.EqualTo(new[] { "Dependency1", "Dependency2", "Dependency3", "TheTask" }));
		}

		[Test]
		public void ExecutingTaskRunsDependencyHierarchy()
		{
			var taskExecutionOrder = new List<string>();

			"TheTask"
				.DependsOn("ParentA")
				.Do(() => taskExecutionOrder.Add("TheTask"));

			"ParentA"
				.DependsOn("ParentB")
				.Do(() => taskExecutionOrder.Add("ParentA"));

			"ParentB"
				.Do(() => taskExecutionOrder.Add("ParentB"));

			"TheTask".Run();

			Assert.That(taskExecutionOrder, Is.EqualTo(new[] { "ParentB", "ParentA", "TheTask" }));
		}
	}
}