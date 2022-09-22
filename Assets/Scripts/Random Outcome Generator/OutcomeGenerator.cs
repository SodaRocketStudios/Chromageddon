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

		private static int DetermineRandomRange(Distribution distribution)
		{
			int maxDecimalPlaces = 0;
			foreach(Outcome outcome in distribution.outcomes)
			{
				int decimalPlaces = CountDecimalPlaces(outcome.Probability);

				if(decimalPlaces > maxDecimalPlaces)
				{
					maxDecimalPlaces = decimalPlaces;
				}
			}

			return 100 * (int)Mathf.Pow(10, maxDecimalPlaces);
		}

		private static int CountDecimalPlaces(float value)
		{
			string[] digits = value.ToString().Split('.');

			if(digits.Length < 2)
			{
				return 0;
			}
			
			return digits[1].Length;
		}
	}
}