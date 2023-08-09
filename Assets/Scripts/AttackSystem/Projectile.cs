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

		private int remainingBounces = 0;
		private int remainingPierces = 0;
		
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

			remainingBounces = (int)characterStats["Bounces"];
			remainingPierces = (int)characterStats["Pierces"];

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
                if (other.gameObject.TryGetComponent<HitHandler>(out HitHandler hitHandler))
                {
                    hitHandler.HandleHit(characterStats);
                }

                if (remainingBounces > 0)
				{
					ContactPoint2D[] contactPoint = new ContactPoint2D[1];
					other.GetContacts(contactPoint);
					Bounce(contactPoint[0].normal);
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

		private void Bounce(Vector3 normal)
		{
			RaycastHit2D hit = Physics2D.BoxCast(transform.position - transform.right, new Vector2(1, 10)*transform.right, 0, -transform.right, 25, LayerMask.GetMask("Enemy"));

			Debug.Log($"{transform.right}, {normal}");

			if(hit)
			{
				transform.LookAt(hit.transform);
			}
			else
			{
				float angle = Vector3.Angle(transform.right, normal);
				transform.Rotate(new Vector3(0, 0, angle*2));
			}
		}

		private void Despawn()
		{
			StopAllCoroutines();
			ProjectileSpawner.Instance.Despawn(gameObject);
		}
	}
}