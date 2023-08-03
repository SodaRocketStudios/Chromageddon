using UnityEngine;

namespace SRS.Extensions.Random
{
	public static class RandomExtensions
	{
		public static float NextFloat(this System.Random random)
		{
			return (float)random.NextDouble();
		}

		public static Vector3 WithinUnitSphere(this System.Random random)
		{
			return new Vector3(random.NextFloat()*2 - 1, random.NextFloat()*2 - 1, random.NextFloat()*2 - 1);
		}

		public static Vector2 WithinUnitCircle(this System.Random random)
		{
			return new Vector2(random.NextFloat()*2 - 1, random.NextFloat()*2 - 1);
		}
	}
}