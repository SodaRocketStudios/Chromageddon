using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    [CreateAssetMenu(fileName = "New Chase State", menuName = "AI/State/Chase State")]
    public class ChaseState : State
    {
        public override void Enter(AIBrain brain)
        {
        }

        public override void Execute(AIBrain brain)
        {
			if(brain.Target == null)
			{
				return;
			}

            brain.MoveToward(brain.Target.position);
			brain.LookAt(brain.Target.position);
        }

        public override void Exit(AIBrain brain)
        {
			brain.StopMoving();
        }
    }
}