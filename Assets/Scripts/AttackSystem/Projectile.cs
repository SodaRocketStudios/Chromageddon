using System.Collections;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.AttackSystem
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private float speed;
		public float Speed
		{
			get
			{
				return speed;
			}
			set
			{
				speed = value;
			}
		}

		private float lifetime;

		private CharacterStats characterStats;
		private LayerMask mask;

		private Rigidbody2D rb;
		
		private bool isExpended = false;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		public void Initialize(CharacterStats characterStats, LayerMask collisionMask)
		{
			this.characterStats = characterStats;
			mask = collisionMask;

            lifetime = characterStats["Range"]/speed;

			isExpended = false;

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
			HandleCollision(other.collider);
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			HandleCollision(other);
		}

		private void HandleCollision(Collider2D other)
		{
			if(isExpended) return;

			if((mask.value & (1 << other.gameObject.layer)) > 0)
			{
				HitHandler hitHandler;
				if(other.gameObject.TryGetComponent<HitHandler>(out hitHandler))
				{
					hitHandler.HandleHit(characterStats);
				}

				isExpended = true;
			}

			if(isExpended) Despawn();
		}

		private void Despawn()
		{
			StopAllCoroutines();
			ProjectileSpawner.Instance.Despawn(gameObject);
		}
	}
}