using System;

namespace SRS.Combat.HitEffects
{
	public class EffectTimer
	{
		public Action<EffectTimer> OnTimerEnd;

		private LastingEffect effect;

		private float timer;

		private bool isTickEffect = false;

		private float nextTickTime = 0;

		public EffectTimer(LastingEffect effect)
		{
			this.effect = effect;

			TickEffect tickEffect = effect as TickEffect;

			if(tickEffect != null)
			{
				isTickEffect = true;
				nextTickTime += tickEffect.TickDelay;
			}

			timer = 0;
		}

		public void Update(float deltaTime)
		{
			if(timer >= effect.Duration)
			{
				OnTimerEnd?.Invoke(this);
			}

			if(isTickEffect)
			{
				TryTick();
			}

			timer += deltaTime;
		}

		private void TryTick()
		{
			TickEffect tickEffect = effect as TickEffect;

			if(timer >= nextTickTime)
			{
				tickEffect.Tick();
				nextTickTime += tickEffect.TickDelay;
			}
		}
	}
}