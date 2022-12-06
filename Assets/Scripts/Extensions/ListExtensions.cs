using System;
using System.Collections.Generic;

namespace SRS.Extensions
{
	public static class ListExtensions
	{
		private static Random random = new Random(Guid.NewGuid().GetHashCode());

		public static T GetRandom<T>(this List<T> list)
		{
			if(list.Count < 1)
			{
				return default;
			}

			return list[random.Next(0, list.Count)];
		}
	}
}