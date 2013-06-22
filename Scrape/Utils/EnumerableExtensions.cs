using System.Collections.Generic;
using System.Linq;

namespace ScrapePack.Utils
{
	public static class EnumerableExtensions
	{
		public static bool IsSubsetOf<T>(this IEnumerable<T> subset, IEnumerable<T> superset)
		{
			return !subset.Except(superset).Any();
		}
	}
}