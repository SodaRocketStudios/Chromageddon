namespace SRS.Extensions
{
	public static class RandomExtensions
	{
		public static float NextFloat(this System.Random random)
		{
			return (float)random.NextDouble();
		}
	}
}