using System.Collections.Generic;
using UnityEngine;
using SRS.Stats;

namespace SRS.Combat.StatusEffects
{
	public class EffectTracker : MonoBehaviour
	{
		private List<StatusEffect> activeEffects;

		StatContainer stats;

		public void Apply(StatusEffect effect)
		{
			if(activeEffects.Contains(effect))
			{
				effect.Reapply();
				return;
			}

			activeEffects.Add(effect);
			effect.Apply(stats);
		}

		public void Cancel(StatusEffect effect)
		{
			int index = activeEffects.IndexOf(effect);
			
			if(index >= 0)
			{
				activeEffects[index].Remove();
				activeEffects.RemoveAt(index);
			}
		}

		private void CancelAll()
		{
			foreach(StatusEffect effect in activeEffects)
			{
				effect.Remove();
			}

			activeEffects.Clear();
		}
	}
}