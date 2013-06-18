using System;

namespace ScrapePack
{
	public class MsBuildRunner : IMsBuildRunner
	{
		public void Run(string[] arguments)
		{
			var process = new System.Diagnostics.Process();
			process.StartInfo = new System.Diagnostics.ProcessStartInfo()
				{
					FileName = "MSBuild.exe",
					Arguments = string.Join(" ", arguments),
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