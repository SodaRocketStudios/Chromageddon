using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AttackState : AIState
    {
        private float aimTime = 5;
        private float attackTime = 0;

        public AttackState(GameObject self, GameObject target) : base(self, target)
        {
        }

        override protected void Enter()
        {
        }

        override public void Execute()
        {
            if(attackManager.attackActive)
            {
                attackTime = Time.time + aimTime;
                return;
            }

            if(Time.time >= attackTime)
            {
                Attack();
                attackTime = Time.time + aimTime;
                return;
            }

            Aim();
        }

        override public void Exit()
        {
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

        private void Attack()
        {
            attackManager.IsAttacking = true;
        }

        private void Aim()
        {
            attackManager.IsAttacking = false;

            LookAtTarget(target.transform.position);
        }
    }
}