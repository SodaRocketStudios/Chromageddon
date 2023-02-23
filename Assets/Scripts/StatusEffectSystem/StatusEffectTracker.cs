using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class StatusEffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeEffects;

		private void Update()
		{
			activeEffects.RemoveAll(e => e.HasEnded);
		}

		private void OnDisable()
		{
			foreach(StatusEffect effect in activeEffects)
			{
				effect.Cancel();
			}
			
			activeEffects.Clear();
		}

		public void ApplyEffect(StatusEffect effect)
		{
			if(effect.Apply(gameObject))
			{
				activeEffects.Add(effect);
			}
		}

		public void RemoveEffect(StatusEffect effect)
		{
			effect.Cancel();
			activeEffects.Remove(effect);
		}
	}
}