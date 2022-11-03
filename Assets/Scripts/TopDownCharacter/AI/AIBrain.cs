using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		public Transform DetectedObject {get; private set;}

		public float detectionRadius;
		public float attackRadius;
		public float fleeRadius;

		private CircleCollider2D detectionRangeCollider;
		private CircleCollider2D attackRangeCollider;
		private CircleCollider2D fleeRangeCollider;

		private AIState currentState;

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
		}

		private void OnEnable()
		{
			currentState = new RoamState(gameObject, gameObject);
		}

		private void Update()
		{
			currentState.Execute();
		}

		private void OnDisable()
		{
			currentState.Exit();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				ChangeState(other);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				ChangeState(other);
			}
		}

		private void ChangeState(Collider2D other)
		{
			AIState previousState = currentState;
			currentState = currentState.OnZoneChanged(other);

			if(currentState != previousState)
			{
				previousState.Exit();
			}
		}
	}
}