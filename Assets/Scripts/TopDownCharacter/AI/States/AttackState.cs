using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AttackState : AIState
    {
        public AttackState(GameObject self, GameObject target) : base(self, target)
        {
        }

        override protected void Enter()
        {
            attackManager.IsAttacking = true;
        }

        override public void Execute()
        {
        }

        override public void Exit()
        {
            attackManager.IsAttacking = false;
            base.Exit();
        }

        override public AIState OnZoneChanged(Collider2D other)
        {
            float distance = DistanceToOther(other);

            if(distance < brain.fleeRadius)
            {
                return new FleeState(self, target);
            }

            if(distance > brain.attackRadius)
            {
                return new ChaseState(self, target);
            }

            return this;
        }
    }
}