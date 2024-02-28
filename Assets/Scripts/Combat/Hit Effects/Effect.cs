using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public abstract class Effect : ScriptableObject
	{
		[SerializeField] private string description;

		public abstract void Apply(GameObject source, GameObject target);
	}
}