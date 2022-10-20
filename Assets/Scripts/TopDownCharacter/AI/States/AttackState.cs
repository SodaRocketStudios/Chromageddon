using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AttackState : AIState
    {

        public override void Enter(AIBrain brain)
        {
            brain.IsAttacking = true;
            base.Enter(brain);
        }

        public override void Execute()
        {
            brain.MoveTowardTarget(brain.transform.position);
            brain.LookAtTarget(brain.DetectedObject.position);
        }

        public override void Exit()
        {
            brain.IsAttacking = false;
            base.Exit();
        }
    }
}