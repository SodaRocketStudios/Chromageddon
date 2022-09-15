using UnityEngine;

namespace SRS.CharacterControllerSystemProto
{
	[RequireComponent(typeof(InputInterfaceProto))]
	public class FollowProto : MonoBehaviour
	{
		private CircleCollider2D followRangeCollider;
		private Transform target;

		private InputInterfaceProto input;

		private LayerMask mask;

		private void Start()
		{
			input = GetComponent<InputInterfaceProto>();

			mask = LayerMask.NameToLayer("Player");

			followRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			followRangeCollider.isTrigger = true;
			followRangeCollider.radius = 10;
		}

		void Update()
		{
			if(target != null)
			{
				FollowTarget();
				LookAtTarget();
			}
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject.layer == mask)
			{
				//Follow the player
				target = other.transform;
			}
		}

		private void FollowTarget()
		{
			Vector2 direction = (target.position - transform.position).normalized;

			input.MoveDirection = direction;
		}

		private void LookAtTarget()
		{
			input.LookTarget = target.position;
		}
	}
}