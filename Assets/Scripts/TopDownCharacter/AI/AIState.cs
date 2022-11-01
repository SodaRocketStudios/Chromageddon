using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		protected GameObject self;
		protected AIBrain brain;
		protected GameObject target;

		protected TopDownCharacterController controller;
		protected AttackManager attackManager;

		public AIState(GameObject self, GameObject target)
		{
			this.self = self;
			this.target = target;

			brain = self.GetComponent<AIBrain>();
			controller = self.GetComponent<TopDownCharacterController>();
			attackManager = self.GetComponent<AttackManager>();

			Enter();
		}


		virtual protected void Enter()
		{
		}

		virtual public void Execute()
		{
		}

		virtual protected void Exit()
		{
		}

		abstract public AIState OnZoneChanged(GameObject target);

		protected void MoveTowardTarget(Vector2 moveTarget)
		{
			// Need to include move speed.
			Vector2 direction = (moveTarget - (Vector2)self.transform.position).normalized;
			controller.Velocity = direction;
		}

		protected void LookAtTarget(Vector2 lookTarget)
		{
			controller.LookTarget = lookTarget;
		}
	}
}