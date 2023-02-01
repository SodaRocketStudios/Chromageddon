using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class FleeState : AIState
    {
        public FleeState(GameObject self, GameObject target) : base(self, target)
        {
        }

        override protected void Enter()
        {
        }

        override public void Execute()
        {
            Vector2 fleePosition = self.transform.position + (self.transform.position - target.transform.position).normalized*brain.fleeRadius;

            MoveTowardTarget(fleePosition);
            LookAtTarget(fleePosition);
        }

        override public void Exit()
        {
            base.Exit();
        }

        override public AIState OnZoneChanged(Collider2D other)
        {
            float distance = DistanceToOtherSquared(other);

            if(distance > brain.fleeRadius)
            {
                return new AttackState(self, target);
            }

            return this;
        }
    }
}