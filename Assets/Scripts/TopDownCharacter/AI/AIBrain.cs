using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		[SerializeField]
		private float detectionRadius;
		[SerializeField]
		private float aimRadius;
		[SerializeField]
		private float fleeRadius;

		private CircleCollider2D detectionRangeCollider;
		private CircleCollider2D aimRangeCollider;
		private CircleCollider2D fleeRangeCollider;

		private TopDownCharacterController characterController;
		private AttackManager attackManager;

		private Vector2 moveVector;
		private Vector2 lookVector;
		private bool isAttacking;

		private AIState currentState;

		private AIState roamState = new RoamState();
		private AIState chaseState = new ChaseState();
		private AIState aimState = new AimState();
		private AIState attackState = new AttackState();
		private AIState fleeState = new FleeState();

        private void Start()
		{
			detectionRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			detectionRangeCollider.radius = detectionRadius;
			detectionRangeCollider.isTrigger = true;
			aimRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			aimRangeCollider.radius = aimRadius;
			aimRangeCollider.isTrigger = true;
			if(fleeRadius > 0)
			{
				fleeRangeCollider = gameObject.AddComponent<CircleCollider2D>();
				fleeRangeCollider.radius = fleeRadius;
				fleeRangeCollider.isTrigger = true;
			}

			characterController = GetComponent<TopDownCharacterController>();
			attackManager = GetComponent<AttackManager>();

			currentState = roamState;
			currentState.Enter(transform);
		}

		private void Update()
		{
			currentState.Execute();
			MoveTowardTarget();
			LookAtTarget();
		}

		private void MoveTowardTarget()
		{
			Vector2 direction = (currentState.Target - (Vector2)transform.position).normalized;
			characterController.Velocity = direction;
		}

		private void LookAtTarget()
		{
			characterController.LookTarget = currentState.Target;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				UpdateState(other);
				Debug.Log(currentState);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				UpdateState(other);
				Debug.Log(currentState);
			}
		}

		private void UpdateState(Collider2D target)
		{
			float distance = Vector3.Distance(transform.position, target.ClosestPoint(transform.position));

			Debug.Log(distance);

			if(distance <= fleeRadius)
			{
				currentState = fleeState;
				currentState.Enter(target.transform);
				return;
			}
			else if(distance <= aimRadius)
			{
				currentState = aimState;
				currentState.Enter(target.transform);
				return;
			}
			else if(distance <= detectionRadius)
			{
				currentState = chaseState;
				currentState.Enter(target.transform);
				return;
			}
			else
			{
				currentState = roamState;
				currentState.Enter(transform);
				return;
			}
		}
	}
}