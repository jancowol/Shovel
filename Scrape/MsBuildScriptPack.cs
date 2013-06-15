using System;
using ScriptCs.Contracts;

namespace Scrape
{
	public class MsBuild : IScriptPackContext
	{
		public void Build(string project)
		{
			Console.WriteLine("Building the project {0}", project);
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
