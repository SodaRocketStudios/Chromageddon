using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class FleeState : AIState
    {

        public override void Enter(AIBrain brain)
        {
            base.Enter(brain);
        }

        public override void Execute()
        {
            Vector2 targetDirection = brain.DetectedObject.position - brain.transform.position;
            target = (Vector2)brain.transform.position - targetDirection;
            base.Execute();
        }
    }
}