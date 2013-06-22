using ScriptCs.Contracts;
using ShovelPack.Tasks;

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
			TaskManagerContext.TaskManager = new TaskManager();
		}

		public void Terminate()
		{
		}
	}

	public class Shovel : IScriptPackContext
	{
	}
}
