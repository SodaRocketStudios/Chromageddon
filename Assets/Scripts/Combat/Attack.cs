using UnityEngine;
using SRS.Utils.ObjectPooling;
using SRS.Stats;

namespace SRS.Combat
{
	public class Attack : PooledObject
	{
		private AttackBehavior behavior;
		
		private StatContainer stats;

		private LayerMask collisionMask;

		private SpriteRenderer spriteRenderer;

		private float lifetime; // send back to pool when time is up.

		public void Initialize(AttackData data, GameObject attacker)
		{
			behavior = data.Behavior;
			
			spriteRenderer.sprite = data.Sprite;

			collisionMask = ~(1 << attacker.layer);
			
			stats = attacker.GetComponent<StatContainer>();

			behavior.OnStart(this);
		}

		private void Update()
		{
			behavior.OnUpdate(this);
		}

		private void FixedUpdate()
		{
			behavior.OnFixedUpdate(this);
		}
	}
}