namespace ScrapePack.TaskActions.MsBuild
{
	public class MsBuildActionConfigurator
	{
		private readonly MsBuildProperties _msBuildProperties;

		public MsBuildActionConfigurator(MsBuildProperties properties)
		{
			_msBuildProperties = properties;
		}

		public MsBuildProperties MsBuildProperties
		{
			get { return _msBuildProperties; }
		}

		public string Project
		{
			get { return _msBuildProperties.Project; }
			set { _msBuildProperties.Project = value; }
		}

		public void ArbitraryArgs(params string[] args)
		{
			MsBuildProperties.ArbitraryArguments = args;
		}

		public void Targets(params string[] targets)
		{
			MsBuildProperties.Targets = targets;
		}
	}
}