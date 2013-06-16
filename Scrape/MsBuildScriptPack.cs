using System;
using ScriptCs.Contracts;

namespace Scrape
{
	public class MsBuilder
	{
		private readonly string _project;
		private string _verbosity = "normal";

		public MsBuilder(string project)
		{
			_project = project;
		}

		public void Build()
		{
			var process = new System.Diagnostics.Process();
			process.StartInfo = new System.Diagnostics.ProcessStartInfo()
				{
					FileName = "MSBuild.exe",
					Arguments = _project + " /verbosity:" + _verbosity,
					UseShellExecute = false,
					RedirectStandardOutput = true
				};
			process.OutputDataReceived += (sender, eventArgs) => Console.WriteLine(eventArgs.Data);
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		public MsBuilder Verbosity
		{
			get
			{
				_verbosity = "minimal";
				return this;
			}
		}
	}

	public class MsBuild : IScriptPackContext
	{
		public MsBuilder Project(string project)
		{
			return new MsBuilder(project);
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
