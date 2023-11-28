using System.Threading;
using SRS.Stats;
using UnityEngine;

namespace SRS.Combat.StatusEffects
{
    public class TickDamageEffect : IEffect
    {
		[SerializeField] private float intensity;

		[SerializeField] private float tickRate;
		private float tickDelay;

        [SerializeField] private DamageType damageType;

		private HitHandler targetHitHandler;

        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public void Apply(StatContainer targetStats)
        {
			tickDelay = 1/tickRate;
            TickTask(tokenSource.Token);
        }

        public void Remove(StatContainer targetStats)
        {
            tokenSource.Cancel();
        }

        private async void TickTask(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                await Awaitable.WaitForSecondsAsync(tickDelay);
                targetHitHandler.Hit(intensity, damageType);
            }
        }
    }
}