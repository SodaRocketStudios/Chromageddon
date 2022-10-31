namespace SRS.RandomOutcomeGenerator
{
	public static class OutcomeGenerator
	{
		private static System.Random randomGenerator = new System.Random();

		public static Outcome GetOutcome(Distribution distribution)
		{
			float randomNumber = (float)randomGenerator.NextDouble()*100;

			float probability = 0;

			foreach(Outcome outcome in distribution.outcomes)
			{
				probability += outcome.Probability;

				if(randomNumber < probability)
				{
					return outcome; 
				}
			}

			return null;
		}

		public static void Seed(int seed)
		{
			randomGenerator = new System.Random(seed);
		}
	}
}