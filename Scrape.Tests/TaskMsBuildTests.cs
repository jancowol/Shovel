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

			var serviceLocator = Substitute.For<IDynamicServiceLocator>();
			serviceLocator
				.Resolve<IMsBuilder>()
				.Returns(msbuilder);

			var task = new Task("TestMsBuildTask", t => { }, serviceLocator);
			task.MsBuild(prop =>
				{
					prop.Project = "the-project-file.csproj";
				});

			task.Run();

			msbuilder
				.Received()
				.Build(
					Arg.Is<MsBuildProperties>(p => p.Project == "the-project-file.csproj"));
		}
	}
}