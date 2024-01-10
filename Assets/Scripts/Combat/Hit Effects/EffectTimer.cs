using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public class EffectTimer
	{
		private LastingEffect effect;

		private float timer;

		public EffectTimer(LastingEffect effect)
		{
			this.effect = effect;
			timer = 0;
		}

		public void Update(float deltaTime)
		{
			timer += deltaTime;
		}
	}
}