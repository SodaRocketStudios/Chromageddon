using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class TickEffect : ScriptableObject
	{
		[SerializeField] private float ticksPerSecond;
		private float tickDelay;

		protected float nextTickTime;

		public void Initialize()
		{
			tickDelay = 1.0f/ticksPerSecond;
			nextTickTime = Time.time + tickDelay;
		}

		public void Tick()
		{
			if(Time.time > nextTickTime)
			{
				HandleTick();
				nextTickTime = Time.time + tickDelay;
			}
		}

		protected abstract void HandleTick();
	}
}