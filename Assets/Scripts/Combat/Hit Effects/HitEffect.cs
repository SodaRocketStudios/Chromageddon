using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.Combat.HitEffects
{

	[CreateAssetMenu(fileName = "New Hit Effect", menuName = "Combat/Hit Effects/Hit Effect")]
	public class HitEffect : ScriptableObject
	{
		[SerializeField] private new string name;

		[SerializeField] private string description;

		[SerializeField] private string procStat;

		[SerializeField] private List<Effect> effects = new();

		public void Trigger(GameObject target)
		{
			foreach(Effect effect in effects)
			{
				effect.Apply(target);
			}
		}

		public float GetProcChance(StatContainer stats)
		{
			return stats[procStat].Value;
		}
	}
}