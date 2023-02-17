using System;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class AttackState : AIState
    {
        private float aimTime = 5;
        private float attackTime = 0;

        public AttackState(GameObject self) : base(self) {}

        protected override Type Execute()
        {
            float squareDistance = VectorExtensions.SquareDistance(self.transform.position, brain.Target.position);

            if(squareDistance < brain.FleeRadiusSquared)
            {
                return typeof(FleeState);
            }

            if(squareDistance > brain.AttackRadiusSquared)
            {
                return typeof(ChaseState);
            }

            if(attackManager.attackActive)
            {
                attackTime = Time.time + aimTime;
                return typeof(AttackState);
            }

            if(Time.time >= attackTime)
            {
                Attack();
                attackTime = Time.time + aimTime;
                return typeof(AttackState);
            }

            Aim();

            return typeof(AttackState);
        }

        public override void Exit()
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

            LookAtTarget(brain.Target.position);
        }
    }
}