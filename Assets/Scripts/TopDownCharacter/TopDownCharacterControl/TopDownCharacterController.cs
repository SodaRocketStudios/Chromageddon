using System.Collections.Generic;
using UnityEngine;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl
{
	public class TopDownCharacterController : MonoBehaviour
	{
		public Vector2 MoveDirection{get; set;}

		public Vector2 LookTarget{get; set;}

		private Rigidbody2D body;

		private CharacterStats characterStats;

		private CircleCollider2D collider2d;

		[SerializeField] private float colliderRadius = 1;
		public float ColliderRadius { get { return colliderRadius; } }

		[SerializeField] private Vector2 colliderOffset = Vector2.zero;
		public Vector2 ColliderOffset { get { return colliderOffset; } }

		[SerializeField] private LayerMask collisionMask;
		private ContactFilter2D contactFilter;
 
		[SerializeField] private float skinWidth = 0.1f;

		private void Awake()
		{
			characterStats = GetComponent<CharacterStats>();
			body = GetComponent<Rigidbody2D>();

			collider2d = gameObject.AddComponent<CircleCollider2D>();
			collider2d.radius = colliderRadius;
			collider2d.offset = colliderOffset;

			contactFilter.layerMask = collisionMask;
			contactFilter.useLayerMask = true;
			contactFilter.useTriggers = false;
		}

		private void Update()
		{
			LookAtTarget();
		}

		private void FixedUpdate()
		{
			Move();
		}

		private void Move()
		{
			Vector2 newPosition = MoveDirection*characterStats["Speed"]*Time.fixedDeltaTime;

			if(CollisionCheck(Vector2.right*newPosition.x))
			{
				newPosition = new Vector2(0, newPosition.y);
			}

			if(CollisionCheck(Vector2.up*newPosition.y))
			{
				newPosition = new Vector2(newPosition.x, 0);
			}

			body.MovePosition(body.position + newPosition);
		}

		private bool CollisionCheck(Vector2 direction)
		{
			if(collider2d.Cast(direction, contactFilter, new RaycastHit2D[5], skinWidth) > 0)
			{
				return true;
			}

			return false;
		}

		private void OnCollisionStay2D(Collision2D other)
        {
			List<ContactPoint2D> contacts = new List<ContactPoint2D>();
			body.GetContacts(contactFilter, contacts);

			foreach(ContactPoint2D contact in contacts)
			{
				Nudge(-contact.normal*contact.separation);
			}
        }

        private void Nudge(Vector2 nudgeVector)
        {
            body.position += nudgeVector;
        }

        private void LookAtTarget()
		{
			Vector2 directionVector = LookTarget - (Vector2)transform.position;

			float direction = Vector2.SignedAngle(Vector2.right, directionVector);

			transform.eulerAngles = new Vector3(0, 0, direction);
		}
	}
}