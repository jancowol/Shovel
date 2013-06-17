using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using NUnit.Framework.Constraints;
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
		public void ExecutingTaskRunsPrecedingTaskFirst()
		{
			var taskExecutionOrder = new List<string>();

			"TheTask"
				.DependsOn("PrecedingTask1", "PrecedingTask2", "PrecedingTask3")
				.Action(() => taskExecutionOrder.Add("TheTask"));

			"PrecedingTask1"
				.Action(() => taskExecutionOrder.Add("PrecedingTask1"));

			"PrecedingTask2"
				.Action(() => taskExecutionOrder.Add("PrecedingTask2"));

			"PrecedingTask3"
				.Action(() => taskExecutionOrder.Add("PrecedingTask3"));

			"TheTask".Do();

			Assert.That(taskExecutionOrder, Is.EqualTo(new[] {"PrecedingTask1", "PrecedingTask2", "PrecedingTask3", "TheTask"}));
		}

		private static void AssertBuildValidTask(Func<string, Task> builder)
		{
			const string taskName = "MyNewTask";

			var task = builder(taskName);

			Assert.That(task, Is.Not.Null);
			Assert.That(task.Name, Is.EqualTo(taskName));
		}
	}
}
