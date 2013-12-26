using System.IO;
using NUnit.Framework;

namespace ShovelPack.Tests.Acceptance.TransformXml
{
	[TestFixture]
	public class TransformXmlAcceptanceTests : ShovelAcceptanceTestsBase
	{
		private const string TransformResult = "transform-result.xml";
		private string _transformedFile;

		[SetUp]
		public void GivenSourceAndTransformFiles_WhenTheTransformTaskIsRun()
		{
			File.Delete(TransformResult);

			"TransformTask"
				.TransformXml(config =>
					{
						config.Source = @"Acceptance\TransformXml\transform-source.xml";
						config.Transform = @"Acceptance\TransformXml\transform-xdt.xml";
						config.Destination = TransformResult;
					})
				.Run();

			_transformedFile = File.ReadAllText(TransformResult);
		}

		[TearDown]
		public void CleanUp()
		{
			File.Delete(TransformResult);
		}

		[Test]
		public void ThenTheDestinationContainsUntransformedSourceContent()
		{
			Assert.That(_transformedFile, Contains.Substring("This section should remain untouched after transformation."));
		}

		[Test]
		public void ThenTheDestinationContainsCorrectTransformations()
		{
			Assert.That(_transformedFile, Contains.Substring("the-replaced-element-after-transformation"));
		}
	}
}