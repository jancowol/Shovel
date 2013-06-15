using System;
using ScriptCs.Contracts;

namespace Scrape
{
	public class MsBuild : IScriptPackContext
	{
		public void Build(string project)
		{
			var process = new System.Diagnostics.Process();
			process.StartInfo = new System.Diagnostics.ProcessStartInfo()
			{
				FileName = "MSBuild.exe",
				Arguments = project,
				UseShellExecute = false,
				RedirectStandardOutput = true
			};
			process.OutputDataReceived += (sender, eventArgs) => Console.WriteLine(eventArgs.Data);
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}
	}

    public class MsBuildScriptPack : IScriptPack
    {
	    public IScriptPackContext GetContext()
	    {
			return new MsBuild();
	    }

	    public void Initialize(IScriptPackSession session)
	    {
	    }

	    public void Terminate()
	    {
	    }
    }
}
