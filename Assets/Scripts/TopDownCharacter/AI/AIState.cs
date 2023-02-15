using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		protected GameObject self;
		protected Transform target;

		protected TopDownCharacterController controller;
		protected AttackManager attackManager;

		protected float radiusSquared;

		private CharacterStats stats;

		public AIState(GameObject self, Transform target, float radius)
		{
			this.self = self;
			this.target = target;
			this.radiusSquared = radius;

			controller = self.GetComponent<TopDownCharacterController>();
			attackManager = self.GetComponent<AttackManager>();
			stats = self.GetComponent<CharacterStats>();

			Enter();
		}

		virtual protected void Enter() {}

		abstract public void Execute();

		virtual public void Exit()
		{
			controller.MoveDirection = Vector2.zero;
		}

		protected void MoveTowardTarget(Vector2 moveTarget)
		{
			Vector2 direction = (moveTarget - (Vector2)self.transform.position).normalized;
			controller.MoveDirection = direction;
		}

		protected void LookAtTarget(Vector2 lookTarget)
		{
			controller.LookTarget = lookTarget;
		}
	}
}