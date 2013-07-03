using System.Collections.Generic;
using NUnit.Framework;
using ShovelPack.Tasks;

namespace Shovel.Tests.Tasks
{
	[TestFixture]
	public class TaskManagerTests
	{
		[Test]
		public void CanRunSpecifiedTasks()
		{
			var taskManager = new TaskManager();
			var executedTasks = new List<string>();

			taskManager.NewTask("task1").Do(() => executedTasks.Add("task1"));
			taskManager.NewTask("taskXXX").Do(() => executedTasks.Add("taskXXX"));
			taskManager.NewTask("task3").Do(() => executedTasks.Add("task3"));

			taskManager.RunTasks("task1", "task3");
			Assert.That(executedTasks, Is.EquivalentTo(new[] {"task1", "task3"}));
		}
	}
}