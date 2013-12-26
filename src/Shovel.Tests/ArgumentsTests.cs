using NUnit.Framework;

namespace ShovelPack.Tests
{
	[TestFixture]
	public class ArgumentsTests
	{
		[Test]
		public void ParsesTasksToRunCorrectly()
		{
			new Arguments("arg1", "-arg2", "--", "-tasks:Build")
				.AssertIsParsedIntoTasksToRun("Build");

			new Arguments("arg1", "-arg2", "--", "-tasks:SomeTask")
				.AssertIsParsedIntoTasksToRun("SomeTask");

			new Arguments("arg1", "-arg2", "--", "-tasks:", "SomeTask")
				.AssertIsParsedIntoTasksToRun("SomeTask");

			new Arguments("arg1", "-arg2", "--", "-tasks:", "SomeTask", "-anotherArg")
				.AssertIsParsedIntoTasksToRun("SomeTask");

			new Arguments("arg1", "-arg2", "--", "-tasks:", "SomeTask,TheSecondTask", "-anotherArg")
				.AssertIsParsedIntoTasksToRun("SomeTask", "TheSecondTask");

			new Arguments("arg1", "-arg2", "--", "-tasks:", "SomeTask", ",TheSecondTask", "-anotherArg")
				.AssertIsParsedIntoTasksToRun("SomeTask", "TheSecondTask");

			new Arguments("arg1", "-arg2", "--", "-tasks:", "SomeTask", ",", "TheSecondTask", "-anotherArg")
				.AssertIsParsedIntoTasksToRun("SomeTask", "TheSecondTask");

			new Arguments("arg1", "-arg2", "--", "-tasks:", "SomeTask,TheSecondTask,TheThirdTask", "-anotherArg")
				.AssertIsParsedIntoTasksToRun("SomeTask", "TheSecondTask", "TheThirdTask");
		}
	}

	public static class ArgumentsTestExtensions
	{
		public static void AssertIsParsedIntoTasksToRun(this Arguments arguments, params string[] expectedTasksToRun)
		{
			Assert.That(arguments.TasksToRun, Is.EqualTo(expectedTasksToRun));
		}
	}
}