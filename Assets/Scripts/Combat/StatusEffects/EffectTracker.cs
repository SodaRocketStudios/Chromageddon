using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat.StatusEffects
{
	public class EffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeEffects;

		public void Add(StatusEffect effect)
		{
			activeEffects.Add(effect);
		}

		public void Remove(StatusEffect effect)
		{
			activeEffects.Remove(effect);
		}

		// TODO -- cancel specific types of effects

		public void CancelAll()
		{
			foreach(StatusEffect effect in activeEffects)
			{
				effect.Cancel();
			}

			activeEffects.Clear();
		}
	}
}