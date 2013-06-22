using NUnit.Framework;
using ShovelPack;

namespace Shovel.Tests
{
	public class ShovelAcceptanceTestsBase
	{
		[SetUp]
		public void Setup()
		{
			TaskManagerContext.Initialize();
		}
	}
}