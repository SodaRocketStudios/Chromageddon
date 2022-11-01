using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class StatusEffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeEffects;

		public void ApplyEffect(StatusEffect effect)
		{
			activeEffects.Add(effect);
			effect.Apply(gameObject);
		}

		public void RemoveEffect(StatusEffect effect)
		{
			effect.End();
			activeEffects.Remove(effect);
		}
	}
}