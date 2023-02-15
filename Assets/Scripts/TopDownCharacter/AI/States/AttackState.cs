using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AttackState : AIState
    {
        private float aimTime = 5;
        private float attackTime = 0;

        public AttackState(GameObject self, Transform target, float radius) : base(self, target, radius)
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

            return;
        }

        override public void Exit()
        {
            base.Exit();
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