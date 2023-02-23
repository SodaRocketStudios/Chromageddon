using UnityEngine;
using SRS.Health;

namespace SRS.StatusEffects
{
	public abstract class TickEffect : ScriptableObject
	{
		[SerializeField] private float ticksPerSecond;
		private float tickDelay;

		[SerializeField] protected float intensity;

		protected HealthManager targetHealth;

		protected float nextTickTime;

		public void Initialize(GameObject target)
		{
			targetHealth = target.GetComponent<HealthManager>();

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