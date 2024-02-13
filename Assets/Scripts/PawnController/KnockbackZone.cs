using UnityEngine;

namespace SRS.PawnController
{
	public class KnockbackZone : MonoBehaviour
	{
		[SerializeField] private float magnitude;

		[SerializeField] private float range;

		[SerializeField] private LayerMask collisionMask;

		public void Trigger()
		{
			Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, collisionMask);

			foreach(Collider2D collider in colliders)
			{
				Vector2 direction = (collider.transform.position - transform.position).normalized;
				collider.GetComponent<PawnMover>()?.AddVelocity(direction*magnitude);
			}
		}
	}
}