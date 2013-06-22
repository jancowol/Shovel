namespace ScrapePack.TaskActions.MsBuild
{
	public class MsBuildActionConfigurator
	{
		private readonly MsBuildProperties _msBuildProperties;

		public MsBuildActionConfigurator(MsBuildProperties properties)
		{
			_msBuildProperties = properties;
		}

		public string Project
		{
			set { _msBuildProperties.Project = value; }
		}

		public void ArbitraryArgs(params string[] args)
		{
			_msBuildProperties.ArbitraryArguments = args;
		}

		public void Targets(params string[] targets)
		{
			_msBuildProperties.Targets = targets;
		}

		public void NoLogo()
		{
			_msBuildProperties.NoLogo = true;
		}
	}
}