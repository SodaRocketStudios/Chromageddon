using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;
using SRS.Extensions;

namespace SRS.StatusEffects
{
	public class StatusEffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeEffects;

		private System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);

		public void TryApplyEffect<effectType>(Dictionary<string, Stat> attackStats)
		where effectType : StatusEffect, new()
		{
			StatusEffect effect = new effectType();
			float procChance = attackStats[effect.procStat].Value;

			if(randomGenerator.Next(DetermineRandomRange(procChance)) < procChance)
			{
				effect.Apply(gameObject);
				return;
			}
		}

		public void RemoveEffect(StatusEffect effect)
		{
			activeEffects.Remove(effect);
		}

		private static int DetermineRandomRange(float probability)
		{
			return 100 * (int)Mathf.Pow(10, probability.DecimalPlaces());
		}
	}
}