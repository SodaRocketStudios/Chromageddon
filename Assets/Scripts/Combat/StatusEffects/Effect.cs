using System.Threading;
using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
	[System.Serializable]
	public abstract class Effect : ScriptableObject
	{
		private CancellationTokenSource tokenSource = new CancellationTokenSource();

		private float timer = 0;

		private float duration;

		public Effect(Effect effect)
		{
			targetStats = effect.targetStats;
			duration = effect.duration;
		}

		protected StatContainer targetStats;

        public void Apply()
		{
			timer = 0;
			EffectTask(tokenSource.Token);
			OnApply();
		}

		private void Remove()
		{
			Destroy(this);
		}

		protected abstract void OnApply();

		public void Cancel()
		{
			tokenSource.Cancel();
		}

		public void Reapply()
		{
			timer = 0;

			if(tokenSource.Token.IsCancellationRequested)
			{
				tokenSource.Dispose();
				tokenSource = new CancellationTokenSource();
				EffectTask(tokenSource.Token);
			}
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