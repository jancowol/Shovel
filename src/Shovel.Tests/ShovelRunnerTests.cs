using System.Collections.Generic;
using NUnit.Framework;
using ShovelPack;

namespace Shovel.Tests
{
	[TestFixture]
	public class ShovelRunnerTests : ShovelAcceptanceTestsBase
	{
		private List<string> _executedTasks;

		[SetUp]
		public void Given_tasks_have_been_defined()
		{
			_executedTasks = new List<string>();

			"task1".Do(() => _executedTasks.Add("task1"));
			"task2".Do(() => _executedTasks.Add("task2"));
			"task3".Do(() => _executedTasks.Add("task3"));
		}

		[Test]
		public void When_a_task_is_specified_as_an_argument_Then_it_is_run()
		{
			RunWithArgumentsErrorChecked("scriptcs", "the_script_name.csx", "-scriptcsArg1", "-scriptcsArg2", "--", "-tasks:task1");

			Assert.That(_executedTasks, Is.EquivalentTo(new[] { "task1" }));
		}

		[Test]
		public void When_multiple_task_arguments_are_specified_Then_the_tasks_are_run_in_order()
		{
			RunWithArgumentsErrorChecked("--", "-tasks:", "task1,", "task2,", "task3");

			Assert.That(_executedTasks, Is.EqualTo(new[] { "task1", "task2", "task3" }));
		}

		[Test]
		public void Given_no_tasks_to_run_were_specified_as_an_argument_When_executing_Then_it_should_not_fail()
		{
			Assert.That(() => RunWithArgumentsErrorChecked(), Throws.Nothing);
		}
	}
}