using NUnit.Framework;
using ShovelPack;
using ShovelPack.Tasks;

namespace Shovel.Tests
{
	public abstract class ShovelAcceptanceTestsBase
	{
		[SetUp]
		public void Setup()
		{
			ShovelStaticContext.Initialize(new TaskManager());
		}
	}
}