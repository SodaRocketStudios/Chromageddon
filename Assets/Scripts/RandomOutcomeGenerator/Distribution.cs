using UnityEngine;
using System.Collections.Generic;

namespace SRS.RandomOutcomeGenerator
{
	public class Distribution : ScriptableObject
	{
		public List<Outcome> outcomes;

		public void populateOutcomes(List<Outcome> _outcomes)
		{
			outcomes = new List<Outcome>(_outcomes);
			outcomes.Sort((o1, o2) => o1.Probability.CompareTo(o2.Probability));
		}
	}
}