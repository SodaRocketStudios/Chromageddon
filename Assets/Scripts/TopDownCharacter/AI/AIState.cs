using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;
using SRS.StatSystem;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		protected GameObject self;
		protected AIBrain brain;
		protected GameObject target;

		protected TopDownCharacterController controller;
		protected AttackManager attackManager;

		private CharacterStats stats;

		public AIState(GameObject self, GameObject target)
		{
			this.self = self;
			this.target = target;

			brain = self.GetComponent<AIBrain>();
			controller = self.GetComponent<TopDownCharacterController>();
			attackManager = self.GetComponent<AttackManager>();
			stats = self.GetComponent<CharacterStats>();

			Enter();
		}

		virtual protected void Enter() {}

		virtual public void Execute() {}

		virtual public void Exit()
		{
			controller.Velocity = Vector2.zero;
		}

		abstract public AIState OnZoneChanged(Collider2D other);

		protected void MoveTowardTarget(Vector2 moveTarget)
		{
			Vector2 direction = (moveTarget - (Vector2)self.transform.position).normalized;
			controller.Velocity = direction*stats.Character["MoveSpeed"].Value;
		}

		protected void LookAtTarget(Vector2 lookTarget)
		{
			controller.LookTarget = lookTarget;
		}

		protected float DistanceToOther(Collider2D other)
		{
			return Vector2.Distance(other.ClosestPoint(self.transform.position), self.transform.position);
		}
	}
}