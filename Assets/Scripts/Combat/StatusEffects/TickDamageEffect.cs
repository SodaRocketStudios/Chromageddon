using SRS.Stats;
using UnityEngine;

namespace SRS.Combat.StatusEffects
{
    public class TickDamageEffect : IEffect
    {
		[SerializeField] private float intensity;

		[SerializeField] private float tickRate;
		private float tickDelay;

		private HitHandler targetHitHandler;

        public void Apply(StatContainer targetStats)
        {
			tickDelay = 1/tickRate;
			// TODO -- Start Effect coroutine;
        }

        public void Remove(StatContainer targetStats)
        {
			// TODO -- End Effect Coroutine;
        }
    }
}
