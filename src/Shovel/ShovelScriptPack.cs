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
			// NOTE: The Terminate() method is currently the only hook we have into after any scripts have been run by scriptcs.
			RunShovel();
		}

		private static void RunShovel()
		{
			var executor = new ShovelRunner(ShovelContext.TaskManager);
			executor.Execute();
		}
	}

	public class Shovel : IScriptPackContext
	{
	}
}
