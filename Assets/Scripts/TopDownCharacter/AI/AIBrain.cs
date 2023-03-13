using UnityEngine;
using SRS.TopDownCharacterControl;

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

		private Transform target;
		public Transform Target => target;

		private void Awake()
		{
			controller = GetComponent<TopDownCharacterController>();

			AttackRadiusSquared = Mathf.Pow(attackRadius, 2);
		}

		private void Update()
		{
			if(target == null)
			{
				return;
			}

			MoveTowardTarget();
			LookAtTarget();
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}

		public void ClearTarget()
		{
			target = null;
		}

		private void MoveTowardTarget()
		{
			Vector2 direction = (target.position - transform.position);
			controller.MoveDirection = direction;
		}

		protected void LookAtTarget()
		{
			controller.LookTarget = target.position;
		}
	}
}