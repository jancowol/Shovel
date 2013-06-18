using NSubstitute;
using NUnit.Framework;
using ScrapePack;

namespace Scrape.Tests
{
	[TestFixture]
	public class TaskMsBuildTests
	{
		[Test]
		public void TaskConfiguredWithMsBuildInvokesMsBuildWhenExecuted()
		{
			var msbuilder = Substitute.For<IMsBuilder>();
			var task = new Task("TestMsBuildTask", t => { }, msbuilder);
			task.MsBuild(prop =>
				{
					prop.Project = "the-project-file.csproj";
				});

			task.Do();

			msbuilder
				.Received()
				.Build(
					Arg.Is<MsBuildProperties>(p => p.Project == "the-project-file.csproj"));
		}
	}
}