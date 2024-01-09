using System.Collections.Generic;
using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public class EffectTracker : MonoBehaviour
	{
		private List<Effect> activeEffects = new();

		public void ApplyEffect(Effect effect)
		{
			activeEffects.Add(effect);
			effect.Apply(this);
		}
	}
}