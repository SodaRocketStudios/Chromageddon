using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class FleeState : AIState
    {
        private float maxFleeDistance = 1;

        public FleeState(GameObject self, Transform target, float radius) : base(self, target, radius)
        {
        }

        override protected void Enter()
        {
        }

        override public void Execute()
        {
            Vector2 fleePosition = self.transform.position + (self.transform.position - target.transform.position).normalized*maxFleeDistance;

            MoveTowardTarget(fleePosition);
            LookAtTarget(fleePosition);

            return;
        }

        override public void Exit()
        {
            base.Exit();
        }
    }
}