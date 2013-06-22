using NUnit.Framework;
using ShovelPack;

namespace Shovel.Tests
{
	public abstract class ShovelAcceptanceTestsBase
	{
		[SetUp]
		public void Setup()
		{
			TaskManagerContext.Initialize();
		}
	}
}