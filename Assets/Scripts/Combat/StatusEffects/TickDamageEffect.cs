using System.Threading.Tasks;
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

        private bool isRunning = false;

        public void Apply(StatContainer targetStats)
        {
			tickDelay = 1/tickRate;
            isRunning = true;
            Tick();
			// TODO -- Start Effect coroutine;
        }

        public void Remove(StatContainer targetStats)
        {
			// TODO -- End Effect Coroutine;
        }

        private async Task Tick()
        {
            while()
            {
                Awaitable
                targetHitHandler.Hit(DamageType.Fire);
            }
        }
    }
}
