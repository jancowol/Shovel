namespace ScrapePack
{
	public class MsBuildProperties
	{
		private string[] _arbitraryArgs = new string[0];
		private string[] _targets = new string[0];
		private string _project = "";

		public string Project
		{
			get { return _project; }
			set { _project = value; }
		}

		public string[] ArbitraryArguments
		{
			get { return _arbitraryArgs; }
			set { _arbitraryArgs = value; }
		}

		public string[] Targets
		{
			get { return _targets; }
			set { _targets = value; }
		}
	}
}