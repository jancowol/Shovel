using System;
using System.Text;

namespace ShovelPack
{
	public class Arguments
	{
		public Arguments(params string[] arguments)
		{
			var args = HackParseScriptArguments(arguments);
			ParseScriptArguments(args);
		}

		public string[] TasksToRun { get; set; }

		private void ParseScriptArguments(string[] arguments)
		{
			for (var i = 0; i < arguments.Length; i++)
			{
				var arg = arguments[i];
				if (arg.ToLower().StartsWith("-tasks:"))
					TasksToRun = ParseTasksToRun(arguments, i);
			}
		}

		private static string[] ParseTasksToRun(string[] arguments, int startArgumentIndex)
		{
			var tasksNameBuilder = new StringBuilder();
			var tasksStartArgument = arguments[startArgumentIndex];
			var taskArgEndIndex = tasksStartArgument.IndexOf(':') + 1;
			tasksNameBuilder.Append(tasksStartArgument.Substring(taskArgEndIndex));

			for (int i = startArgumentIndex + 1; i < arguments.Length; i++)
				if (arguments[i].ToLower().StartsWith("-"))
					break;
				else
					tasksNameBuilder.Append(arguments[i]);

			return tasksNameBuilder.ToString().Split(',');
		}

		private string[] HackParseScriptArguments(string[] args)
		{
			// This parsing code was copied from scriptcs, and is how it currently handles command line argument parsing.
			// As at the time of writing this, there was no officially supported way of passing script arguments to script packs,
			// which is why this hack was implemented.

			int separatorLocation = Array.IndexOf(args, "--");
			int scriptArgsCount = separatorLocation == -1 ? 0 : args.Length - separatorLocation - 1;
			var scriptArgs = new string[scriptArgsCount];
			Array.Copy(args, separatorLocation + 1, scriptArgs, 0, scriptArgsCount);
			return scriptArgs;
		}
	}
}