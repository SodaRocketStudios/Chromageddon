using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		public Transform DetectedObject{get; private set;}

		[SerializeField] private float detectionRadius;
		[SerializeField] private float attackRadius;
		[SerializeField] private float fleeRadius;

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
			currentState = new RoamState();
			currentState.Initialize(gameObject, gameObject);
		}

		private void Update()
		{
			currentState.Execute();
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			currentState = currentState.OnZoneChanged(other.gameObject);
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			currentState = currentState.OnZoneChanged(other.gameObject);
		}
	}
}