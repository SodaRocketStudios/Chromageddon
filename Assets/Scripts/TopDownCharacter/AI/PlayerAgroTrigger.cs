using UnityEngine;
using SRS.LevelSystem;
using SRS.StatSystem;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
	public class PlayerAgroTrigger : MonoBehaviour
	{
		[SerializeField] private float radius;

		private CircleCollider2D triggerCollider;

		private CharacterStats stats;

		private void Awake()
		{
			triggerCollider = gameObject.AddComponent<CircleCollider2D>();
			triggerCollider.isTrigger = true;
			triggerCollider.radius = radius;

			stats = GetComponent<CharacterStats>();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			AIBrain brain;

			if(other.TryGetComponent<AIBrain>(out brain))
			{
				brain.SetTarget(transform);
			}
		}

		private void OnTriggerStay2D(Collider2D other)
		{
			XPPickup pickup;

			if(other.TryGetComponent<XPPickup>(out pickup))
			{
				if(pickup.Target != null) return;
				
				if(VectorExtensions.SquareDistance(pickup.transform.position, transform.position) <= Mathf.Pow(stats["Pickup Range"], 2))
				{
					pickup.Target = transform;
				}
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