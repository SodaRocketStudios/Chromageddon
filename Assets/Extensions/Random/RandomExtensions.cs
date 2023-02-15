namespace SRS.Extensions.Random
{
	public static class RandomExtensions
	{
		public static float NextFloat(this System.Random random)
		{
			return (float)random.NextDouble();
		}
	}
}