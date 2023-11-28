using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;
using System.Threading;

namespace SRS.Combat.StatusEffects
{
    public class StatusEffect : IOnHitEffect
    {
		[SerializeField] private List<IEffect> effects;

		[SerializeField] private float duration;

		[SerializeField] private string ProcStat;

		private StatContainer targetStats;

		private CancellationTokenSource tokenSource = new CancellationTokenSource();

		private float timer = 0;

        public void Trigger(StatContainer targetStats)
        {
            Apply(targetStats);
        }

		public void Apply(StatContainer targetStats)
		{
            this.targetStats = targetStats;

			foreach(IEffect effect in effects)
			{
				effect.Apply(targetStats);
			}

			EffectTask(tokenSource.Token);
		}

		public void Remove()
		{
			foreach(IEffect effect in effects)
			{
				effect.Remove(targetStats);
			}
		}

		public void Reapply()
		{
			timer = 0;
		}

		public void Cancel()
		{
			tokenSource.Cancel();
		}

		private async void EffectTask(CancellationToken token)
		{
			while(!token.IsCancellationRequested)
			{
				if(timer >= duration)
				{
					tokenSource.Cancel();
				}

				timer += Time.deltaTime;

				await Awaitable.EndOfFrameAsync();
			}

			Remove();
		}
    }
}