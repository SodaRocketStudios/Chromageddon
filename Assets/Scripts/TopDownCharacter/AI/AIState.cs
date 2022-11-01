using UnityEngine;
using SRS.TopDownCharacterControl.AttackSystem;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		protected GameObject self;
		protected GameObject target;

		protected TopDownCharacterController controller;
		protected AttackManager attackManager;

		virtual public void Initialize(GameObject self, GameObject target)
		{
			this.self = self;
			this.target = target;

			Enter();
		}

		abstract public AIState OnZoneChanged(GameObject target);

		virtual public void Enter()
		{
		}

		virtual public void Execute()
		{
		}

		virtual public void Exit()
		{
		}

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