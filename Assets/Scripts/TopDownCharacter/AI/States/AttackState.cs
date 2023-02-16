using System;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class AttackState : AIState
    {
        private float aimTime = 5;
        private float attackTime = 0;

        public AttackState(GameObject self) : base(self)
        {
        }

        override protected void Enter()
        {
        }

        override public Type Execute()
        {
            float squareDistance = VectorExtensions.SquareDistance(self.transform.position, brain.Target.position);

            if(squareDistance < brain.FleeRadius)
            {
                return typeof(FleeState);
            }

            if(squareDistance > brain.AttackRadius)
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

            LookAtTarget(brain.Target.position);
        }
    }
}