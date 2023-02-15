using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{
		[SerializeField] private float detectionRadius;
		[SerializeField] private float attackRadius;
		[SerializeField] private float fleeRadius;

		protected Transform detectedObject;

		private CircleCollider2D detectionRangeCollider;

		private AIState currentState;

        private void Start()
		{
			detectionRangeCollider = gameObject.AddComponent<CircleCollider2D>();
			detectionRangeCollider.radius = detectionRadius;
			detectionRangeCollider.isTrigger = true;
		}

		private void OnEnable()
		{
			currentState = new RoamState(gameObject, transform, 0);
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
				detectedObject = other.transform;
				currentState = new ChaseState(gameObject, detectedObject, detectionRadius);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if(other.CompareTag("Player"))
			{
				detectedObject = null;
				currentState = new RoamState(gameObject, transform, 0);
			}
		}
	}
}