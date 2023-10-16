using System;
using UnityEngine;
using System.Collections.Generic;
using SRS.Extensions.Random;

namespace SRS.RandomOutcomeGenerator
{
	[System.Serializable]
	public class Distribution<T>
	{
		[SerializeField]private List<Outcome<T>> outcomes;

		private float dropRateTotal;

		private bool totalRateIsDirty = true;

		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		public void Add(Outcome<T> outcome)
		{
			outcomes.Add(outcome);

			totalRateIsDirty = true;
		}

		public void Add(T result, float dropRate)
		{
			outcomes.Add(new Outcome<T>(result, dropRate));
			
			totalRateIsDirty = true;
		}

		public T GetRandom()
		{
			CalculateTotalDropRate();

			float dropValue = random.NextFloat()*dropRateTotal;

			float dropComparisonValue = 0;

			foreach(Outcome<T> outcome in outcomes)
			{
				dropComparisonValue += outcome.DropRate;

				if(dropValue < dropComparisonValue)
				{
					return outcome.Result;
				}
			}

			return outcomes[0].Result;
		}

		private void CalculateTotalDropRate()
		{
			if(totalRateIsDirty)
			{
				dropRateTotal = 0;

				foreach(Outcome<T> outcome in outcomes)
				{
					dropRateTotal += outcome.DropRate;
				}
			}
		}
	}
}