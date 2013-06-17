using System;
using System.Runtime.Serialization;

namespace ScrapePack
{
	[Serializable]
	public class UndefinedTaskException : Exception
	{
		public UndefinedTaskException()
		{
		}

		public UndefinedTaskException(string message)
			: base(message)
		{
		}

		public UndefinedTaskException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected UndefinedTaskException(
			SerializationInfo info,
			StreamingContext context)
			: base(info, context)
		{
		}
	}
}