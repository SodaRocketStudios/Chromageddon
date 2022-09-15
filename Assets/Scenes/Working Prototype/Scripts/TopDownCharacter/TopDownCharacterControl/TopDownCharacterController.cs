using UnityEngine;

namespace SRS.TopDownCharacterController
{
	[RequireComponent(typeof(CircleCollider2D))]
	public class TopDownCharacterController : MonoBehaviour
	{
		public Vector2 Velocity{get; set;}

		[SerializeField] private LayerMask collisionMask;

		[SerializeField] private float boxWidth = 0.1f;
		public float BoxWidth => boxWidth;

		private Bounds bounds;

		private void Start()
		{
			bounds = GetComponent<CircleCollider2D>().bounds;
		}

		private void Update()
		{
			DetectCollisionsHorizontal();
			DetectCollisionVertical();
			Move();
		}

		private void DetectCollisionsHorizontal()
		{
			if(Velocity.x == 0)
			{
				return;
			}

			float direction = Mathf.Sign(Velocity.x);

			Vector2 origin = (Vector2)transform.position + Vector2.right*bounds.extents.x*direction;
			Vector2 size = new Vector2(boxWidth, bounds.extents.y);

			RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0, Vector2.right*Mathf.Sign(Velocity.x), 0, collisionMask);
			Debug.DrawLine(origin, origin + Vector2.right*size.x*Mathf.Sign(Velocity.x));

			if(hit.collider != null)
			{
				Velocity = new Vector2(0, Velocity.y);
			}
		}

		private void DetectCollisionVertical()
		{
			if(Velocity.y == 0)
			{
				return;
			}

			float direction = Mathf.Sign(Velocity.y);

			Vector2 origin = (Vector2)transform.position + Vector2.up*bounds.extents.y*direction;
			Vector2 size = new Vector2(bounds.extents.x, boxWidth);

			RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0, Vector2.up*Mathf.Sign(Velocity.y), 0, collisionMask);
			Debug.DrawLine(origin, origin + Vector2.up*size.y*Mathf.Sign(Velocity.y));

			if(hit.collider != null)
			{
				Velocity = new Vector2(Velocity.x, 0);
			}
		}

		private void Move()
		{
			transform.Translate(Velocity*Time.deltaTime, Space.World);
		}
	}
}