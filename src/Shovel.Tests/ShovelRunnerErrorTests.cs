using System;
using NUnit.Framework;

namespace ShovelPack.Tests
{
	[TestFixture]
	public class ShovelRunnerErrorTests : ShovelAcceptanceTestsBase
	{
		private Exception _theException;

		[SetUp]
		public void Given_an_exception_is_thrown_while_executing_a_task()
		{
			_theException = new Exception("Retreat! Retreat!");
			"errorTask".Do(() => { throw _theException; });
		}

		[Test]
		public void Then_no_exception_is_bubbled_up()
		{
			// Because Shovel executes during the Terminate() step of the script pack,
			// any exceptions here will hide possible exceptions in the script itself, which is undesirable

			Assert.That(() => RunTaskUnchecked("errorTask"), Throws.Nothing);
		}

		[Test]
		public void Then_the_exception_detail_is_written_to_stderr()
		{
			RunTaskUnchecked("errorTask");
			var errorOutput = GetErrorOutput();
			Assert.That(errorOutput, Is.StringContaining(_theException.Message));
		}
	}
}