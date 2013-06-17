﻿using ScriptCs.Contracts;

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
			session.ImportNamespace("ScrapePack");
			Context.TaskManager = new TaskManager();
		}

		public void Terminate()
		{
		}
	}
}