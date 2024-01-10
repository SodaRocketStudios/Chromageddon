using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public abstract class LastingEffect : Effect
	{
		[SerializeField] protected float duration;
		public float Duration
		{
			get => duration;
		}

		public abstract void Remove(GameObject target);
	}
}