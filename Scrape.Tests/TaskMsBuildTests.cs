using System;
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
			// TODO: Suspect there's an MsBuild related class trying to get out of the Task class...
			throw new NotImplementedException();
			//var msBuildRunner = Substitute.For<IMsBuildRunner>();
			//var serviceLocator = Substitute.For<IDynamicServiceLocator>();
			//serviceLocator
			//	.Resolve<IMsBuildRunner>()
			//	.Returns(msBuildRunner);

			//var task = new Task("TestMsBuildTask", t => { }, serviceLocator);
			//MsBuildPropertyBuilder msbuildPropertyBuilder = null;
			//task.MsBuild(prop => msbuildPropertyBuilder = prop);

			//task.Run();

			//msBuildRunner
			//	.Received()
			//	.Run(msbuildPropertyBuilder);
		}
	}
}