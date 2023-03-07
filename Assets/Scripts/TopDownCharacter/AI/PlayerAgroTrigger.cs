using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	public class PlayerAgroTrigger : MonoBehaviour
	{
		[SerializeField] private float radius;

		private CircleCollider2D triggerCollider;

		private void Awake()
		{
			triggerCollider = gameObject.AddComponent<CircleCollider2D>();
			triggerCollider.isTrigger = true;
			triggerCollider.radius = radius;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			AIBrain brain;

			if(other.TryGetComponent<AIBrain>(out brain))
			{
				brain.SetTarget(transform);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			AIBrain brain;

			if(other.TryGetComponent<AIBrain>(out brain))
			{
				brain.ClearTarget();
			}
		}
    }
}