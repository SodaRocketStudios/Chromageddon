using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AimState : AIState
    {

        public override void Enter(AIBrain brain)
        {
            base.Enter(brain);
        }

        public override void Execute()
        {
            target = brain.DetectedObject.position;
            brain.LookAtTarget(target);
            brain.MoveTowardTarget(brain.transform.position);
        }
    }
}