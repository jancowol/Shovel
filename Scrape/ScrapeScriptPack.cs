using System;
using System.Collections.Generic;
using ScriptCs.Contracts;

namespace ScrapePack
{
	public class Scrape : IScriptPackContext
	{
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
			return NewTask(taskName, t => t.Action(action));
		}

		public static Task DependsOn(this string taskName, string precedingTask)
		{
			return NewTask(taskName, t => t.DependsOn(precedingTask));
		}

		public static void Do(this string taskName)
		{
			var task = Tasks[taskName];
			var precedingTask = task.PrecedingTask;
			if (precedingTask != null)
				precedingTask.Do();
			task.Do();
		}

		private static Task NewTask(string taskName, Action<Task> initializer)
		{
			var task = new Task();
			initializer(task);
			Tasks.Add(taskName, task);
			return task;
		}
	}

	public class Task
	{
		private Action _action;

		public string PrecedingTask { get; private set; }

		public Task Action(Action action)
		{
			_action = action;
			return this;
		}

		public Task DependsOn(string precedingTask)
		{
			PrecedingTask = precedingTask;
			return this;
		}

		public void Do()
		{
			_action();
		}
	}
}
