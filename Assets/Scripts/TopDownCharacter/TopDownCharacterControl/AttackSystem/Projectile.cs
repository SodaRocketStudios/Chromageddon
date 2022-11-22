using UnityEngine;
using System.Collections.Generic;
using SRS.StatSystem;
using SRS.Extensions;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class Projectile : MonoBehaviour
	{
		private Dictionary<string, Stat> attackStats;
		private LayerMask mask;

		private float speed;
		private float lifetime;
		private float despawnTime;

		private static System.Random randomGenerator = new System.Random(System.DateTime.Now.Millisecond);

		public void Initialize(Dictionary<string, Stat> stats, LayerMask collisionMask)
		{
			attackStats = new Dictionary<string, Stat>(stats);
			mask = collisionMask;

			speed = attackStats["Speed"].Value;
			lifetime = attackStats["Lifetime"].Value;

			despawnTime = Time.time + lifetime;
		}

		void Update()
		{
			if(Time.time > despawnTime)
			{
				Despawn();
			}

			transform.Translate(transform.right*Time.deltaTime*speed, Space.World);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if((mask.value & (1 << other.gameObject.layer)) > 0)
			{
				HitHandler hitHandler;
				if(other.gameObject.TryGetComponent<HitHandler>(out hitHandler))
				{
					hitHandler.HandleHit(attackStats);
				}

				Despawn();
			}
		}

		private void Despawn()
		{
			// TODO -- Switch to an object pooling solution for projectiles.
			Destroy(gameObject);
		}
	}
}