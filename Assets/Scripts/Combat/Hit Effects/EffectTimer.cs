using System;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public class EffectTimer
	{
		public Action<EffectTimer> OnTimerEnd;

		private LastingEffect effect;

		private float timer;

		private bool isTickEffect = false;

		private float nextTickTime = 0;

		private GameObject target;

		public EffectTimer(LastingEffect effect, GameObject target)
		{
			this.effect = effect;

			this.target = target;

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

		public void RemoveEffect(GameObject target)
		{
			effect.Remove(target);
		}

		private void TryTick()
		{
			TickEffect tickEffect = effect as TickEffect;

			if(timer >= nextTickTime)
			{
				tickEffect.Tick(target);
				nextTickTime += tickEffect.TickDelay;
			}
		}
	}
}