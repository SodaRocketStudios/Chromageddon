using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
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

		private TopDownCharacterController characterController;
		private AttackManager attackManager;

		private Vector2 moveVector;
		private Vector2 lookVector;
		private bool isAttacking;

		private AIState state;
		private AIState currentState
		{
			get
			{
				return state;
			}
			set
			{
				if(currentState == value)
				{
					return;
				}

				state = value;
				state.Enter(transform);
			}
		}
		private AIState roamState = new RoamState();
		private AIState chaseState = new ChaseState();
		private AIState aimState = new AimState();
		private AIState attackState = new AttackState();
		private AIState fleeState = new FleeState();

        private void Start()
		{
			detectionRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			detectionRangeCollider.radius = detectionRange;
			detectionRangeCollider.isTrigger = true;
			aimRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			aimRangeCollider.radius = aimRange;
			aimRangeCollider.isTrigger = true;
			if(fleeRange > 0)
			{
				fleeRangeCollider = gameObject.AddComponent<CircleCollider2D>();
				fleeRangeCollider.radius = fleeRange;
				fleeRangeCollider.isTrigger = true;
			}

			characterController = GetComponent<TopDownCharacterController>();
			attackManager = GetComponent<AttackManager>();

			currentState = roamState;
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
				UpdateState(other.transform);	
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				UpdateState(other.transform);	
			}
		}

		private void UpdateState(Transform target)
		{
			float distance = Vector3.Distance(transform.position, target.position);

			if(distance <= fleeRange)
			{
				currentState = fleeState;
			}
			else if(distance <= aimRange)
			{
				currentState = aimState;
			}
			else if(distance <= detectionRange)
			{
				currentState = chaseState;
			}
			else
			{
				currentState = roamState;
			}
		}
	}
}