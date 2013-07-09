using System;
using System.Runtime.Serialization;

namespace ShovelPack
{
	[Serializable]
	public class UndefinedTaskException : Exception
	{
		const string message = "Could not find the task named '{0}'. Please check the output for possible script compilation errors.";

		public UndefinedTaskException(string taskName)
			: base(string.Format(message, taskName))
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