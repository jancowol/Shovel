using System;
using System.Runtime.Serialization;

namespace ShovelPack
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

	[Serializable]
	public class DuplicateTaskException : Exception
	{
		public DuplicateTaskException()
		{
		}

		public DuplicateTaskException(string message)
			: base(message)
		{
		}

		public DuplicateTaskException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected DuplicateTaskException(
			SerializationInfo info,
			StreamingContext context)
			: base(info, context)
		{
		}
	}
}