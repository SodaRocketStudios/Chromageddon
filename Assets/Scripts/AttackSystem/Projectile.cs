using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

		private int remainingBounces = 0;
		private int remainingPierces = 0;
		
		private bool isExpended = false;

		private GameObject lastObjectHit;

		private void Awake()
		{
			rb = GetComponent<Rigidbody2D>();
		}

		public void Initialize(CharacterStats characterStats, LayerMask collisionMask)
		{
			this.characterStats = characterStats;
			mask = collisionMask;

            lifetime = characterStats["Range"]/speed;

			remainingBounces = (int)characterStats["Bounces"];
			remainingPierces = (int)characterStats["Pierces"];

			isExpended = false;

			lastObjectHit = null;

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
				if(other.gameObject == lastObjectHit)
				{
					return;
				}

				lastObjectHit = other.gameObject;

                if (other.gameObject.TryGetComponent(out HitHandler hitHandler))
                {
                    hitHandler.HandleHit(characterStats);
                }

                if (remainingBounces > 0)
				{
					Bounce();
					remainingBounces--;
					return;
				}

				if(remainingPierces > 0)
				{
					remainingPierces--;
					return;
				}

				isExpended = true;
			}

			if(isExpended) Despawn();
		}

		private void Bounce()
		{
			List<RaycastHit2D> hits = Physics2D.CircleCastAll(transform.position, 50, transform.right, 0, LayerMask.GetMask("Enemy"))
				.Where(hit => Vector2.Angle(hit.normal, transform.right) < 60 && hit.transform.gameObject != lastObjectHit).ToList();

			if(hits.Count > 0)
			{
				float rotation = Vector2.SignedAngle(transform.right,hits.First().transform.position - transform.position);
				transform.Rotate(new Vector3(0, 0, rotation));
			}
			else
			{
				RaycastHit2D hit = Physics2D.Raycast(transform.position-transform.right, transform.right);
				float rotation = Vector2.SignedAngle(transform.right, hit.normal)*2 - 180;
				transform.Rotate(new Vector3(0, 0, rotation));
			}

			StopAllCoroutines();
			DespawnTimer();
		}

		private void Despawn()
		{
			StopAllCoroutines();
			ProjectileSpawner.Instance.Despawn(gameObject);
		}
	}
}