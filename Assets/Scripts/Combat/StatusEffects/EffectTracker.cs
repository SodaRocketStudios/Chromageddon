using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat.StatusEffects
{
	public class EffectTracker : MonoBehaviour
	{
		private List<Effect> activeEffects;

		public void Apply(Effect effect)
		{
			int index = activeEffects.IndexOf(effect);
			if(index >= 0)
			{
				activeEffects[index].Reapply();
				return;
			}

			Effect effectInstance = Instantiate(effect);
			activeEffects.Add(effectInstance);
			effectInstance.Apply();
		}

		public void Cancel(Effect effect)
		{
			int index = activeEffects.IndexOf(effect);
			
			if(index >= 0)
			{
				activeEffects[index].Cancel();
				activeEffects.RemoveAt(index);
			}
		}

		public void CancelAll()
		{
			foreach(Effect effect in activeEffects)
			{
				effect.Cancel();
			}

			activeEffects.Clear();
		}
	}
}