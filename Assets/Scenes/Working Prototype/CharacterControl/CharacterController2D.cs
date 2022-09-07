using UnityEngine;

namespace SodaRocket
{
	public class CharacterController2D : MonoBehaviour
	{
		// Raycast in the direction of movement
		// Translate the character based on velocity as long as it isn't colliding.

		public Vector2 Velocity{get; set;}

		[SerializeField] private LayerMask mask;


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

			RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one, 0, Vector2.right*Mathf.Sign(Velocity.x), 1, mask);
			Debug.DrawLine(transform.position, (Vector2)transform.position + Vector2.right*Mathf.Sign(Velocity.x));

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

			RaycastHit2D hit = Physics2D.BoxCast(transform.position, Vector2.one, 0, Vector2.up*Mathf.Sign(Velocity.y), 0, mask);
			Debug.DrawLine(transform.position, (Vector2)transform.position + Vector2.up*Mathf.Sign(Velocity.y));

			if(hit.collider != null)
			{
				Velocity = new Vector2(Velocity.x, 0);
			}
		 }

		private void Move()
		{
			// Need to stop movement on collisions
			transform.Translate(Velocity*Time.deltaTime, Space.World);
		}
	}
}