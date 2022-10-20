using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class ChaseState : AIState
    {

        public override void Enter(AIBrain brain)
        {
            base.Enter(brain);
        }

        public override void Execute()
        {
            target = brain.DetectedObject.position;
            base.Execute();
        }
    }
}