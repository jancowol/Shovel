using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using ScrapePack;
using ScriptCs.Contracts;

namespace Scrape.Tests
{
	[TestFixture]
	public class FluentInterfaceTests
	{
		[SetUp]
		public void Setup()
		{
			var scriptPack = new ScrapeScriptPack();
			var scriptPackSession = Substitute.For<IScriptPackSession>();
			scriptPack.Initialize(scriptPackSession);
		}

		[Test]
		public void CanDefineNewTaskFromAction()
		{
			AssertBuildValidTask(taskName =>
				taskName.Action(() => { }));
		}

		[Test]
		public void CanDefineNewTaskFromDependsOn()
		{
			AssertBuildValidTask(taskName =>
				taskName.DependsOn("TaskItsDependentOn"));
		}

		[Test]
		public void CanExecuteTaskByName()
		{
			var wasExecuted = false;
			"TheTaskName".Action(() => wasExecuted = true);
			"TheTaskName".Do();

			Assert.That(wasExecuted, Is.True);
		}

		[Test]
		public void TaskNamesAreCaseInsensitive()
		{
			var wasExecuted = false;
			"TheTaskName".Action(() => wasExecuted = true);
			"thetaskname".Do();

			Assert.That(wasExecuted, Is.True);
		}

		[Test]
		public void ExecutingNonExistentTaskThrowsUsefulException()
		{
			Assert.That(() => "UndefinedTask".Do(),
				Throws.InstanceOf<UndefinedTaskException>()
				.And.Message.EqualTo("Could not find the task named 'UndefinedTask'."));
		}

		[Test]
		public void ExecutingTaskRunsDependenciesFirst()
		{
			var taskExecutionOrder = new List<string>();

			"TheTask"
				.DependsOn("Dependency1", "Dependency2", "Dependency3")
				.Action(() => taskExecutionOrder.Add("TheTask"));

			"Dependency1"
				.Action(() => taskExecutionOrder.Add("Dependency1"));

			"Dependency2"
				.Action(() => taskExecutionOrder.Add("Dependency2"));

			"Dependency3"
				.Action(() => taskExecutionOrder.Add("Dependency3"));

			"TheTask".Do();

			Assert.That(taskExecutionOrder, Is.EqualTo(new[] {"Dependency1", "Dependency2", "Dependency3", "TheTask"}));
		}

		[Test]
		public void ExecutingTaskRunsDependencyHierarchy()
		{
			var taskExecutionOrder = new List<string>();

			"TheTask"
				.DependsOn("ParentA")
				.Action(() => taskExecutionOrder.Add("TheTask"));

			"ParentA"
				.DependsOn("ParentB")
				.Action(() => taskExecutionOrder.Add("ParentA"));

			"ParentB"
				.Action(() => taskExecutionOrder.Add("ParentB"));

			"TheTask".Do();

			Assert.That(taskExecutionOrder, Is.EqualTo(new[] {"ParentB", "ParentA", "TheTask"}));
		}

		//[Test]
		//public void CanDefineTaskWithMsBuildAction()
		//{
		//	var task = "TheMsBuildTask"
		//		.MsBuild(prop =>
		//			{
		//				prop.Project = "the-project-to-build.csproj";
		//			});

		//	Assert.That(task.MsBuild);
		//}

		private static void AssertBuildValidTask(Func<string, Task> builder)
		{
			const string taskName = "MyNewTask";

			var task = builder(taskName);

			Assert.That(task, Is.Not.Null);
			Assert.That(task.Name, Is.EqualTo(taskName));
		}
	}
}
