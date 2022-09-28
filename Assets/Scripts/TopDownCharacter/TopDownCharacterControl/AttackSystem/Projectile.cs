using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public class Projectile : MonoBehaviour
	{
		private Dictionary<string, Stat> attackStats;
		private LayerMask mask;

		private float speed;
		private float lifetime;
		private float despawnTime;

		public void Initialize(Dictionary<string, Stat> stats, LayerMask collisionMask)
		{
			attackStats = new Dictionary<string, Stat>(stats);
			mask = collisionMask;

			speed = attackStats["Speed"].Value;
			lifetime = attackStats["Lifetime"].Value;

			despawnTime = Time.time + lifetime;
			Debug.Log(lifetime);
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
				// TO DO -- Perform on hit logic. This is where an IDamageable interface could be useful.
				Despawn();
			}
		}

		private void Despawn()
		{
			// TO DO -- Switch to an object pooling solution for projectiles.
			Destroy(gameObject);
		}
	}
}