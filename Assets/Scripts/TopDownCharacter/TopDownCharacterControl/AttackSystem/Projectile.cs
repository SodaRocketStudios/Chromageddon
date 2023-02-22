using System.Collections;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AttackSystem
{
	public class Projectile : MonoBehaviour
	{
		[SerializeField] private float speed;

		private float lifetime;

		private CharacterStats characterStats;
		private LayerMask mask;

		private Rigidbody2D rb;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		public void Initialize(CharacterStats characterStats, LayerMask collisionMask)
		{
			this.characterStats = characterStats;
			mask = collisionMask;

            lifetime = characterStats["Range"]/speed;

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
					hitHandler.HandleHit(characterStats);
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