using System.Diagnostics;

public static class MSBuild
{
	public static void Project(string project)
	{
		var process = new System.Diagnostics.Process();
		process.StartInfo = new System.Diagnostics.ProcessStartInfo()
		{
			FileName = "MSBuild.exe",
			UseShellExecute = false,
			RedirectStandardOutput = true
		};
		process.OutputDataReceived += (sender, eventArgs) => Console.WriteLine(eventArgs.Data);
		process.Start();
		process.BeginOutputReadLine();
		process.WaitForExit();
	}
}
