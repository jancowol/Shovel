using NUnit.Framework;
using ShovelPack.TaskActionConfig;
using ShovelPack.Tasks;

namespace Shovel.Tests
{
	[TestFixture]
	public class TaskTests
	{
		[Test]
		public void TaskWithNoPreExecutorDefinedDoesNotFailWhenRun()
		{
			var task = new Task("task-with-no-action", null, new TaskActionFactory());
			task.Do(() => { });
			Assert.That(() => task.Run(), Throws.Nothing);
		}

		[Test]
		public void TaskWithNoActionDefinedDoesNotFailWhenRun()
		{
			var task = new Task("task-with-no-action", t => { }, new TaskActionFactory());
			Assert.That(() => task.Run(), Throws.Nothing);
		}
	}
}