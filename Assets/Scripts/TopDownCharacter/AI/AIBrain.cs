using UnityEngine;
using SRS.Extensions.Vector;
using SRS.TopDownCharacterControl.AttackSystem;

namespace SRS.TopDownCharacterControl.AI
{
	[RequireComponent(typeof(TopDownCharacterController))]
	public class AIBrain : MonoBehaviour
	{	
		[SerializeField] private float challengeRating;
		public float ChallengeRating { get {return challengeRating;} }

		[SerializeField] private float attackRadius;
		public float AttackRadiusSquared { get; private set;}

		private TopDownCharacterController controller;
		public TopDownCharacterController Controller => controller;

		private AttackManager attackManager;
		public AttackManager AttackManager => attackManager;

		private Transform target;
		public Transform Target => target;

		private State currentState;

		private void Awake()
		{
			controller = GetComponent<TopDownCharacterController>();

			AttackRadiusSquared = Mathf.Pow(attackRadius, 2);

			attackManager = GetComponent<AttackManager>();
		}

		private void Update()
		{
			if(currentState != null)
			{
				State nextState = currentState.Execute(this);

				if(nextState != currentState)
				{
					currentState.Exit(this);
					currentState = nextState;
					currentState.Enter(this);
				}
			}
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}

		public void ClearTarget()
		{
			target = null;
		}

		public void MoveToward(Vector2 position)
		{
			controller.MoveDirection = position - (Vector2)transform.position;
		}

		public void LookAt(Vector2 position)
		{
			controller.LookTarget = position;
		}
	}
}