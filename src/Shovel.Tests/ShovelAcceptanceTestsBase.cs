using System;
using System.IO;
using NUnit.Framework;
using ShovelPack;
using ShovelPack.Tasks;

namespace Shovel.Tests
{
	public abstract class ShovelAcceptanceTestsBase
	{
		private TextWriter _originalStdErr;
		private StringWriter _errorOutput;

		[SetUp]
		public void Setup()
		{
			CaptureStdErr();
			ShovelStaticContext.Initialize(new TaskManager());
		}

		[TearDown]
		public void Cleanup()
		{
			RestoreOriginalStdErr();
		}

		protected void RunTaskUnchecked(string task)
		{
			RunWithArgumentsUnchecked(
				BuildValidCommandLineArgsForTask(task));
		}

		protected void RunTaskErrorChecked(string task)
		{
			RunWithArgumentsErrorChecked(
				BuildValidCommandLineArgsForTask(task));
		}

		protected void RunWithArgumentsErrorChecked(params string[] arguments)
		{
			RunWithArgumentsUnchecked(arguments);
			CheckErrorOutput();
		}

		protected void RunWithArgumentsUnchecked(params string[] arguments)
		{
			var args = new Arguments(arguments);
			var runner = new ShovelRunner(ShovelStaticContext.TaskManager, args);

			runner.Execute();
		}

		private void CheckErrorOutput()
		{
			var errorOutput = GetErrorOutput();
			if (!string.IsNullOrEmpty(errorOutput))
			{
				throw new ShovelTestException(string.Format("The following exception was thrown during test execution:\r\n{0}", errorOutput));
			}
		}

		private void CaptureStdErr()
		{
			_originalStdErr = Console.Error;
			_errorOutput = new StringWriter();
			Console.SetError(_errorOutput);
		}

		private void RestoreOriginalStdErr()
		{
			Console.SetError(_originalStdErr);
		}

		protected string GetErrorOutput()
		{
			return _errorOutput.ToString();
		}

		public class ShovelTestException : Exception
		{
			public ShovelTestException(string message) : base(message)
			{
			}
		}

		private static string[] BuildValidCommandLineArgsForTask(string task)
		{
			return new[] {"--", string.Format("-tasks:{0}", task)};
		}
	}
}