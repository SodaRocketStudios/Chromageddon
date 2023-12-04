using System.Threading;
using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
    public class TickDamageEffect : Effect
    {
		[SerializeField] private float intensity;

		[SerializeField] private float tickRate;
		private float tickDelay;

        [SerializeField] private DamageType damageType;

		private HitHandler targetHitHandler;

        private CancellationTokenSource tokenSource = new CancellationTokenSource();

        public TickDamageEffect(Effect effect) : base(effect)
        {
        }

        protected override void OnApply()
        {
			tickDelay = 1/tickRate;
            TickTask(tokenSource.Token);
        }

        private void OnDestroy()
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