using System;
using ScriptCs.Contracts;

namespace ShovelPack
{
	public class ShovelScriptPack : IScriptPack
	{
		public IScriptPackContext GetContext()
		{
			return new Shovel();
		}

		public void Initialize(IScriptPackSession session)
		{
			session.ImportNamespace("ShovelPack");
			ShovelContext.Initialize();
		}

		public void Terminate()
		{
			RunShovel();
		}

		private static void RunShovel()
		{
			var arguments = new Arguments(Environment.GetCommandLineArgs());
			var executor = new ShovelRunner(ShovelContext.TaskManager, arguments);
			executor.Execute();
		}
	}

	public class Shovel : IScriptPackContext
	{
		public void SetArguments(string[] scriptArgs)
		{
			ShovelContext.SetArguments(scriptArgs);
		}
	}
}
