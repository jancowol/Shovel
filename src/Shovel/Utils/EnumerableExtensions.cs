using System.Collections.Generic;
using System.Linq;

namespace ShovelPack.Utils
{
	public static class EnumerableExtensions
	{
		public static bool IsSubsetOf<T>(this IEnumerable<T> subset, IEnumerable<T> superset)
		{
			return !subset.Except(superset).Any();
		}
	}
}