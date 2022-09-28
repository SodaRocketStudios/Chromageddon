using System;
using UnityEngine;
using SRS.Stats;
using SRS.Extensions;

namespace SRS.StatusEffects
{
	public class EffectPrefab : ScriptableObject
	{
		public Type effectType;
		public Stat procStat;

		private System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);

		public void CheckApplication()
		{
			float probability = procStat.Value;
			int randomNumber = randomGenerator.Next(DetermineRandomRange(probability));

			if(randomNumber < probability)
			{
				// Create status effect
			}
		}

		private static int DetermineRandomRange(float probability)
		{
			return 100 * (int)Mathf.Pow(10, probability.DecimalPlaces());
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