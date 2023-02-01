using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AimState : AIState
    {
        public AimState(GameObject self, GameObject target) : base(self, target)
        {
        }

        override protected void Enter()
        {
            attackManager.IsAttacking = false;
        }

        override public void Execute()
        {
            LookAtTarget(target.transform.position);
        }

        override public void Exit()
        {
            base.Exit();
        }

        override public AIState OnZoneChanged(Collider2D other)
        {
            float distance = DistanceToOtherSquared(other);

            if(distance > brain.attackRadius)
            {
                return new ChaseState(self, target);
            }

            if(distance < brain.fleeRadius)
            {
                return new FleeState(self, target);
            }

            return this;
        }
    }
}