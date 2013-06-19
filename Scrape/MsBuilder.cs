using System.Linq;

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
			var arguments = properties.ArbitraryArguments
				.Concat(new[] {properties.Project});

			_msBuildRunner.Run(arguments.ToArray());
		}
	}
}