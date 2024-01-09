using UnityEngine;

namespace SRS.Combat.StatusEffects
{
	public class EffectTimer : MonoBehaviour
	{
		private float duration;
		private float timer = 0;

		private LastingEffect effect;

		public void Begin(LastingEffect effect)
		{
			this.effect = effect;
		}

		public void End()
		{
		}
	}
}