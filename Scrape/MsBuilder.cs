using System;

namespace ScrapePack
{
	public class MsBuilder : IMsBuilder
	{
		public void Build(MsBuildProperties properties)
		{
			var process = new System.Diagnostics.Process();
			process.StartInfo = new System.Diagnostics.ProcessStartInfo()
				{
					FileName = "MSBuild.exe",
					Arguments = properties.Project,
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