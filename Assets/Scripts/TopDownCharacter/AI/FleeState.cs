using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[CreateAssetMenu(fileName = "New Flee State", menuName = "AI/State/Flee State")]
    public class FleeState : State
    {
        public override void Enter(AIBrain brain)
        {
        }

        public override void Execute(AIBrain brain)
        {
            Vector2 targetPosition = 2 * brain.transform.position - brain.Target.position;
			brain.MoveToward(targetPosition);
			brain.LookAt(targetPosition);
        }

        public override void Exit(AIBrain brain)
        {
			brain.StopMoving();
        }
    }
}