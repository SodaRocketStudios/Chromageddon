using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class StatusEffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeStatusEffects = new List<StatusEffect>();

		private void OnDisable()
		{
			foreach(StatusEffect effect in activeStatusEffects)
			{
				effect.Cancel();
			}
			
			activeStatusEffects.Clear();
		}

		public void AddEffect(StatusEffect effect)
		{
			activeStatusEffects.Add(effect);
		}

		public void RemoveEffect(StatusEffect effect)
		{
			activeStatusEffects.Remove(effect);
		}

		public void CancelEffect(StatusEffect effect)
		{
			effect.Cancel();
		}

		public void CancelAllEffects()
		{
			foreach(StatusEffect effect in activeStatusEffects)
			{
				effect.Cancel();
			}

			activeStatusEffects.Clear();
		}
	}
}