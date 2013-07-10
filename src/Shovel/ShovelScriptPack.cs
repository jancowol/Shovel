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
			session.ImportNamespace("ShovelPack.ScriptExtensions");
			ShovelStaticContext.Initialize();
		}

		public void Terminate()
		{
			// NOTE: The Terminate() method is currently the only hook we have into after any scripts have been run by scriptcs.
			RunShovel();
		}

		private static void RunShovel()
		{
			var executor = new ShovelRunner(ShovelStaticContext.TaskManager);
			executor.Execute();
		}
	}

	public class Shovel : IScriptPackContext
	{
	}
}
