using System;

namespace ScrapePack
{
	public class MsBuilder : IMsBuilder
	{
		private readonly IMsBuildRunner _msBuildRunner;

		public MsBuilder() : this(new MsBuildRunner())
		{
		}

		public MsBuilder(IMsBuildRunner msBuildRunner)
		{
			_msBuildRunner = msBuildRunner;
		}

		public void Build(MsBuildProperties properties)
		{
			var arguments = new[] {properties.Project};
			_msBuildRunner.Run(arguments);
		}
	}
}