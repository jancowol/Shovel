using NUnit.Framework;
using ShovelPack;

namespace Shovel.Tests
{
	[TestFixture]
	public class ShovelRunnerUndefinedTaskExceptionHandlingTests : ShovelAcceptanceTestsBase
	{
		[Test]
		public void Given_an_undefined_task_exception_is_thrown_during_execution_Then_only_the_message_is_displayed()
		{
			var undefinedTaskException = new UndefinedTaskException("UndefinedTask");
			RunTaskUnchecked("UndefinedTask");
			Assert.That(GetErrorOutput(), Is.EqualTo(string.Format("SHOVEL_ERROR: {0}\r\n", undefinedTaskException.Message)));
		}
	}
}