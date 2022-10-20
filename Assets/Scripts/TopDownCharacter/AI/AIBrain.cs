using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		public Transform DetectedObject{get; private set;}

		[SerializeField]
		private float detectionRadius;
		[SerializeField]
		private float attackRadius;
		[SerializeField]
		private float fleeRadius;

		private CircleCollider2D detectionRangeCollider;
		private CircleCollider2D attackRangeCollider;
		private CircleCollider2D fleeRangeCollider;

		private TopDownCharacterController characterController;
		private AttackManager attackManager;

		public bool IsAttacking;

		private AIState state;
		private AIState currentState
		{
			get
			{
				return state;
			}
			set
			{
				if(state == value)
				{
					return;
				}
				
				state?.Exit();
				state = value;
				state.Enter(this);
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
			detectionRangeCollider.radius = detectionRadius;
			detectionRangeCollider.isTrigger = true;
			attackRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			attackRangeCollider.radius = attackRadius;
			attackRangeCollider.isTrigger = true;
			if(fleeRadius > 0)
			{
				fleeRangeCollider = gameObject.AddComponent<CircleCollider2D>();
				fleeRangeCollider.radius = fleeRadius;
				fleeRangeCollider.isTrigger = true;
			}

			characterController = GetComponent<TopDownCharacterController>();
			attackManager = GetComponent<AttackManager>();

			currentState = roamState;
		}

		private void Update()
		{
			currentState.Execute();
			attackManager.IsAttacking = IsAttacking;
		}

		public void MoveTowardTarget(Vector2 target)
		{
			// Need to include move speed.
			Vector2 direction = (target - (Vector2)transform.position).normalized;
			characterController.Velocity = direction;
		}

		public void LookAtTarget(Vector2 target)
		{
			characterController.LookTarget = target;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				UpdateState(other);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				UpdateState(other);
			}
		}

		private void UpdateState(Collider2D target)
		{
			DetectedObject = target.transform;

			float distance = Vector3.Distance(transform.position, target.ClosestPoint(transform.position));

			if(distance <= fleeRadius)
			{
				currentState = fleeState;
				return;
			}
			else if(distance <= attackRadius)
			{
				currentState = attackState;
				return;
			}
			else if(distance <= detectionRadius)
			{
				currentState = chaseState;
				return;
			}
			else
			{
				currentState = roamState;
				return;
			}
		}
	}
}