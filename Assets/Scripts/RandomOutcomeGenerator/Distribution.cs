using UnityEngine;
using System.Collections.Generic;

namespace SRS.RandomOutcomeGenerator
{
	[System.Serializable]
	public class Distribution<T>
	{
		[SerializeField]private List<Outcome<T>> outcomes;

		private float dropRateSum;

		public void Add(Outcome<T> outcome)
		{
			outcomes.Add(outcome);

			dropRateSum += outcome.DropRate;
		}

		public void Add(T result, float dropRate)
		{
			dropRateSum += dropRate;

			outcomes.Add(new Outcome<T>(result, dropRate));
		}

		public T GetRandom()
		{ 
			return outcomes[0].Result;
		}
	}
}