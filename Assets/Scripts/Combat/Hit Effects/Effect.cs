using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public abstract class Effect : ScriptableObject
	{
		[SerializeField] private string description;

		public abstract void Apply(EffectTracker tracker);
	}
}