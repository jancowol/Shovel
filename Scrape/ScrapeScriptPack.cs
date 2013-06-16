using System;
using System.Collections.Generic;
using ScriptCs.Contracts;

namespace ScrapePack
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

	public class Scrape : IScriptPackContext
	{
		public MsBuilder Project(string project)
		{
			return new MsBuilder(project);
		}
	}

	public class ScrapeScriptPack : IScriptPack
	{
		public IScriptPackContext GetContext()
		{
			return new Scrape();
		}

		public void Initialize(IScriptPackSession session)
		{
		}

		public void Terminate()
		{
		}
	}

	public static class ScrapeExtensions
	{
		private static readonly Dictionary<string, Task> Tasks = new Dictionary<string, Task>();

		public static Task Action(this string taskName, Action action)
		{
			var task = new Task(action);
			Tasks.Add(taskName, task);
			return task;
		}

		public static Task DependsOn(this string taskName, string precedingTask)
		{
			var task = new Task();
			task.DependsOn(precedingTask);
			Tasks.Add(taskName, task);
			return task;
		}

		public static void Do(this string taskName)
		{
			var task = Tasks[taskName];
			var precedingTask = task.PrecedingTask;
			if (precedingTask != null)
				precedingTask.Do();
			task.Do();
		}
	}

	public class Task
	{
		private Action _action;
		private string _precedingTask;

		public Task(Action action)
		{
			_action = action;
		}

		public Task()
		{
		}

		public string PrecedingTask
		{
			get { return _precedingTask; }
		}

		public Task Action(Action action)
		{
			_action = action;
			return this;
		}

		public Task DependsOn(string precedingTask)
		{
			_precedingTask = precedingTask;
			return this;
		}

		public void Do()
		{
			_action();
		}
	}
}
