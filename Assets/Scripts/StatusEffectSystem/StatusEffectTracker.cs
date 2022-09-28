using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;
using SRS.Extensions;

namespace SRS.StatusEffects
{
	public class StatusEffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeEffects;

		public void ApplyEffect(StatusEffect effect)
		{
			effect.Apply(gameObject);
			Debug.Log("Applied effect");
		}

		public void RemoveEffect(StatusEffect effect)
		{
			// activeEffects.Remove(effect);
		}
	}
}