using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	public class AIBrain : MonoBehaviour
	{
		[SerializeField]
		private float detectionRange;
		[SerializeField]
		private float aimRange;
		[SerializeField]
		private float fleeRange;

		private CircleCollider2D detectionRangeCollider;
		private CircleCollider2D aimRangeCollider;
		private CircleCollider2D fleeRangeCollider;

		private AIState currentState;

		private AIState roamState;
		private AIState ChaseState;
		private AIState AimState;
		private AIState AttackState;
		private AIState FleeState;

		private TopDownInputInterface input;

		private Transform target;

		private void Start()
		{
			detectionRangeCollider = new CircleCollider2D();
			detectionRangeCollider.radius = detectionRange;
			aimRangeCollider = new CircleCollider2D();
			aimRangeCollider.radius = aimRange;
			if(fleeRange > 0)
			{
				fleeRangeCollider = new CircleCollider2D();
				fleeRangeCollider.radius = fleeRange;
			}

			currentState = roamState;
			input = GetComponent<TopDownInputInterface>();
		}

		private void Update()
		{
			currentState.Execute();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				target = other.transform;
				float distance = Vector3.Distance(transform.position, target.position);
			}
		}
	}
}