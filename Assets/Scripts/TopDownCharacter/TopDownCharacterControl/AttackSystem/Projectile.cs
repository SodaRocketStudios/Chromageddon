using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using SRS.StatSystem;
using SRS.Extensions;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class Projectile : MonoBehaviour
	{
		private CharacterStats charcaterStats;
		private LayerMask mask;

		private float speed;

		private float lifetime;

		private Rigidbody2D rb;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		public void Initialize(CharacterStats charcaterStats, LayerMask collisionMask)
		{
			this.charcaterStats = charcaterStats;
			mask = collisionMask;

            speed = this.charcaterStats["ProjectileSpeed"];
            lifetime = this.charcaterStats["ProjectileLifetime"];

			StartCoroutine(DespawnTimer());
		}

		private IEnumerator DespawnTimer()
		{
			yield return new WaitForSeconds(lifetime);
			Despawn();
		}

		private void FixedUpdate()
		{
			rb.MovePosition(rb.position + (Vector2)transform.right*Time.deltaTime*speed);
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if((mask.value & (1 << other.gameObject.layer)) > 0)
			{
				HitHandler hitHandler;
				if(other.gameObject.TryGetComponent<HitHandler>(out hitHandler))
				{
					hitHandler.HandleHit(charcaterStats);
				}

				Despawn();
			}
		}

		private void Despawn()
		{
			StopAllCoroutines();
			ProjectileSpawner.Instance.Pool.Release(gameObject);
		}
	}
}