using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace SRS.Combat.StatusEffects
{
	[System.Serializable]
    public class StatusEffect : IOnHitEffect
    {
		[SerializeField] private string procStat;

		[SerializeField] private float duration;

		[SerializeField] private float tickRate;

		[SerializeField] private List<StatEffect> statEffects;

		[SerializeField] private List<TickDamageEffect> tickDamageEffects;

		public string ProcStat
		{
			get => procStat;
		}

		private GameObject target;

		private float timer;
		private float nextTickTime;

		private CancellationTokenSource tokenSource = new CancellationTokenSource();

		public StatusEffect(StatusEffect original)
		{
			procStat = original.procStat;
			duration = original.duration;
			tickRate = original.tickRate;
			statEffects = original.statEffects;
			tickDamageEffects = original.tickDamageEffects;
		}

        public void Trigger(GameObject target)
        {
			StatusEffect instance = new(this);
			target.GetComponent<EffectTracker>().Add(instance);
			instance.Apply(target);
        }

		private void Apply(GameObject target)
		{
			this.target = target;

			foreach(StatEffect effect in statEffects)
			{
				effect.Apply(target);
			}

			EffectRoutine(tokenSource.Token);
		}

		private void Remove()
		{
			foreach(StatEffect effect in statEffects)
			{
				effect.Remove(target);
			}

			target.GetComponent<EffectTracker>().Remove(this);
		}

		public void Cancel()
		{
			tokenSource.Cancel();
		}

		private async void EffectRoutine(CancellationToken token)
		{
			nextTickTime = 1/tickRate;
			
			while(!token.IsCancellationRequested)
			{
				if(timer >= duration)
				{
					tokenSource.Cancel();
				}

				if(timer >= nextTickTime)
				{
					foreach(TickDamageEffect effect in tickDamageEffects)
					{
						effect.Tick(target);
					}

					nextTickTime += 1/tickRate;
				}

				timer += Time.deltaTime;

				await Awaitable.EndOfFrameAsync();
			}

			Remove();
		}
    }
}