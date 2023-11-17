using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
    public class StatusEffect : IOnHitEffect
    {
		[SerializeField] private List<IEffect> effects;

		[SerializeField] private float duration;

		[SerializeField] private string ProcStat;

        public void Trigger(StatContainer targetStats)
        {
            Apply(targetStats);
        }

		public void Apply(StatContainer targetStats)
		{
			foreach(IEffect effect in effects)
			{
				effect.Apply(targetStats);
			}
		}

		public void Remove(StatContainer targetStats)
		{
			foreach(IEffect effect in effects)
			{
				effect.Remove(targetStats);
			}
		}
    }
}