using UnityEngine;
using System;

namespace SRS.RandomOutcomeGenerator
{
	public static class OutcomeGenerator
	{
		private static System.Random randomGenerator = new System.Random();

		public static Outcome GetOutcome(Distribution distribution)
		{
			int maxRange = DetermineRandomRange(distribution);

			float randomNumber = randomGenerator.Next(maxRange)*100.0f/maxRange;

			float probability = 0;

			foreach(Outcome outcome in distribution.outcomes)
			{
				probability += outcome.Probability;

				if(randomNumber <= probability)
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

		private static int DetermineRandomRange(Distribution distribution)
		{
			int maxDecimalPlaces = 0;
			foreach(Outcome outcome in distribution.outcomes)
			{
				int decimalsPlaces = CountDecimalPlaces(outcome.Probability);

				if(decimalsPlaces > maxDecimalPlaces)
				{
					maxDecimalPlaces = decimalsPlaces;
				}
			}

			return 100 * (int)Mathf.Pow(10, maxDecimalPlaces);
		}

		private static int CountDecimalPlaces(float value)
		{
			return (value % 1).ToString().Length;
		}
	}
}