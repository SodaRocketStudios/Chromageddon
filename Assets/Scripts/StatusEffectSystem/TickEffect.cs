using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class TickEffect : ScriptableObject
	{
		public abstract void Tick();
	}
}