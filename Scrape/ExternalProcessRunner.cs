using System;
using System.Diagnostics;

namespace ScrapePack
{
	public class ExternalProcessRunner
	{
		public static void RunProcess(string processExecutable, string[] processArguments)
		{
			var process = new Process();
			process.StartInfo = new ProcessStartInfo()
				{
					FileName = processExecutable,
					Arguments = String.Join(" ", processArguments),
					UseShellExecute = false,
					RedirectStandardOutput = true
				};
			process.OutputDataReceived += (sender, eventArgs) => Console.WriteLine(eventArgs.Data);
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}
	}
}