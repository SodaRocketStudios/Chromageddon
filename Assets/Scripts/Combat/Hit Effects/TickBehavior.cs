using UnityEngine;

namespace SRS.Combat.HitEffects
{
	public abstract class TickBehavior : ScriptableObject
	{
		public abstract void Tick(GameObject target);
	}
}