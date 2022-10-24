using System.Collections.Generic;
using UnityEngine;

namespace SRS.RandomOutcomeGenerator
{
	public static class RandomNumberGenerator
	{
		private static System.Random randomGenerator = new System.Random();

		public static float Random(List<float> probabilities)
		{
			int maxRange = DetermineRandomRange(probabilities);

			return randomGenerator.Next(maxRange)*100.0f/maxRange;
		}

		public static void Seed(int seed)
		{
			randomGenerator = new System.Random(seed);
		}

		private static int DetermineRandomRange(List<float> probabilities)
		{
			int maxDecimalPlaces = 0;
			foreach(float probability in probabilities)
			{
				int decimalPlaces = CountDecimalPlaces(probability);

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