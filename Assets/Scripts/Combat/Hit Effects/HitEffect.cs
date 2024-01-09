using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.Combat.HitEffects
{

	[CreateAssetMenu(fileName = "New Hit Effect", menuName = "Combat/Hit Effect")]
	public class HitEffect : ScriptableObject
	{
		[SerializeField] private new string name;

		[SerializeField] private string description;

		[SerializeField] private string procStat;

		[SerializeField] private List<Effect> effects = new();

		public void Trigger(EffectTracker tracker)
		{
			foreach(Effect effect in effects)
			{
				tracker.ApplyEffect(effect);
			}
		}

		public float GetProcChance(StatContainer stats)
		{
			return stats[procStat].Value;
		}
	}
}