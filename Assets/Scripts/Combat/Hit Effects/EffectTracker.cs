using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public class EffectTracker : MonoBehaviour
	{
		private List<EffectTimer> activeEffectTimers = new();

		private void Update()
		{
			foreach(EffectTimer timer in activeEffectTimers)
			{
				timer.Update(Time.deltaTime);
			}
		}

		public void AddEffect(LastingEffect effect)
		{
			activeEffectTimers.Add(new EffectTimer(effect));
		}

		public void RemoveEffectTimer(EffectTimer timer)
		{
			activeEffectTimers.Remove(timer);
		}
	}
}