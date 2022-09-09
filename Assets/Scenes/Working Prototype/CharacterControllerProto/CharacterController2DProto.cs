using UnityEngine;

namespace SodaRocket
{
	public class CharacterController2DProto : MonoBehaviour
	{
		public Vector2 Velocity{get; set;}

		[SerializeField] private LayerMask mask;

		private Bounds bounds;

		private void Start()
		{
			bounds = GetComponent<SpriteRenderer>().bounds;
		}


		private void Update()
		{
			DetectCollisionHorizontal();
			DetectCollisionVertical();
			Move();
		}

		 private void DetectCollisionHorizontal()
		 {
			if(Velocity.x == 0)
			{
				return;
			}

			Vector2 origin = (Vector2)transform.position + Vector2.right*bounds.extents.x*Mathf.Sign(Velocity.x);
			Vector2 size = new Vector2(0.1f, bounds.extents.y);

			RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0, Vector2.right*Mathf.Sign(Velocity.x), 0, mask);
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

			Vector2 origin = (Vector2)transform.position + Vector2.up*bounds.extents.y*Mathf.Sign(Velocity.y);
			Vector2 size = new Vector2(bounds.extents.x, 0.1f);

			RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0, Vector2.up*Mathf.Sign(Velocity.y), 0, mask);
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