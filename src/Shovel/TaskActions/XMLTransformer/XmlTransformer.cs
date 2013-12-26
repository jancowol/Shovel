using System.Xml;
using Microsoft.Web.XmlTransform;

namespace ShovelPack.TaskActions.XMLTransformer
{
	public class XmlTransformer
	{
		public void Transform(string fileToTransform, string transformFile, string outputFile)
		{
			var source = LoadSourceFile(fileToTransform);
			Transform(source, transformFile);
			source.Save(outputFile);
		}

		private static void Transform(XmlDocument source, string transformFile)
		{
			var transformer = new XmlTransformation(transformFile);
			transformer.Apply(source);
		}

		private static XmlTransformableDocument LoadSourceFile(string fileToTransform)
		{
			var source = new XmlTransformableDocument {PreserveWhitespace = false};
			source.Load(fileToTransform);
			return source;
		}
	}
}