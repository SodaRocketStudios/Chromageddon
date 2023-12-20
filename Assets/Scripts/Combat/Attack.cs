using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Stats;

namespace SRS.Combat
{
	public class Attack : PooledObject
	{
		public AttackBehavior Behavior {get; private set;}
		
		public StatContainer Stats {get; private set;}

		public DamageType DamageType {get; private set;}

		public LayerMask collisionMask {get; private set;}

		private SpriteRenderer spriteRenderer;

		private float lifetime; // send back to pool when time is up.

		private float timer;

		public void Initialize(AttackData data, GameObject attacker)
		{
			Behavior = data.Behavior;
			
			spriteRenderer.sprite = data.Sprite;

			collisionMask = ~(1 << attacker.layer);
			
			Stats = attacker.GetComponent<StatContainer>();

			Behavior.OnStart(this);

			LifetimeTask();
		}

		private void Update()
		{
			Behavior.OnUpdate(this);
		}

		private void FixedUpdate()
		{
			Behavior.OnFixedUpdate(this);
		}

		private async void LifetimeTask()
		{
			while(timer < lifetime)
			{
				timer += Time.deltaTime;
				await Awaitable.NextFrameAsync();
			}

			Behavior.OnEnd(this);

			gameObject.SetActive(false);
		}
	}
}