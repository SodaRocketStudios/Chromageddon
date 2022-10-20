using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	public abstract class AIState
	{
		protected AIBrain brain;
		protected Vector2 target;


		virtual public void Enter(AIBrain brain)
		{
			this.brain = brain;
		}

		virtual public void Execute()
		{
			brain.MoveTowardTarget(target);
            brain.LookAtTarget(target);
		}

		virtual public void Exit()
		{
			target = brain.transform.position;
		}
	}
}