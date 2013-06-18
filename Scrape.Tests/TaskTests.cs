using NUnit.Framework;
using ScrapePack;

namespace Scrape.Tests
{
	[TestFixture]
	public class TaskTests
	{
		[Test]
		public void TaskWithNoPreExecutorDefinedDoesNotFail()
		{
			var task = new Task("task-with-no-action", null, null);
			task.Action(() => { });
			Assert.That(() => task.Do(), Throws.Nothing);
		}

		[Test]
		public void TaskWithNoActionDefinedDoesNotFail()
		{
			var task = new Task("task-with-no-action", t => { }, null);
			Assert.That(() => task.Do(), Throws.Nothing);
		}
	}
}