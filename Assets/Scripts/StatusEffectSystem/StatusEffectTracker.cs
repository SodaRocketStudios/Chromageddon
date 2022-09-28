using System.Collections.Generic;
using UnityEngine;

namespace SRS.StatusEffects
{
	public class StatusEffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeEffects;

		public void ApplyEffect<effectType>()
		where effectType : StatusEffect, new()
		{
			StatusEffect effect = new effectType();
			effect.Apply(gameObject);
			// activeEffects.Add(effect);
		}

		public void RemoveEffect(StatusEffect effect)
		{
			effect.Remove();
			activeEffects.Remove(effect);
		}
	}
}