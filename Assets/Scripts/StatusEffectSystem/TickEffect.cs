using UnityEngine;

namespace SRS.StatusEffects
{
	public abstract class TickEffect : Effect
	{
		[SerializeField, Min(0.1f)] private float ticksPerSecond;
		private float tickDelay;

		[SerializeField] protected float intensity;

		protected float nextTickTime;

		private bool isRunning = false;

		public override void Apply(GameObject target)
		{
			Initialize(target);

			tickDelay = 1.0f/ticksPerSecond;
			nextTickTime = Time.time + tickDelay;

			isRunning = true;
		}

		public override void Remove()
		{
			if(Time.time < nextTickTime)
			{
				HandleTick();
			}
			
			isRunning = false;
		}

		public override void Update()
		{
			if(isRunning)
			{
				TryTick();
			}
		}

		private void TryTick()
		{
			if(Time.time >= nextTickTime)
			{
				HandleTick();
				nextTickTime += tickDelay;
			}
		}

		protected abstract void Initialize(GameObject Target);

		protected abstract void HandleTick();
	}
}