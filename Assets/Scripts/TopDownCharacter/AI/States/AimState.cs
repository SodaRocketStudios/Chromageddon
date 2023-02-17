using System;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class AimState : AIState
    {
        public AimState(GameObject self) : base(self) {}

        protected override void Enter()
        {
            attackManager.IsAttacking = false;
        }

        protected override Type Execute()
        {
            LookAtTarget(brain.Target.position);

            float squareDistance = VectorExtensions.SquareDistance(self.transform.position, brain.Target.position);

            if(squareDistance < brain.FleeRadiusSquared)
            {
                return typeof(FleeState);
            }

            if(squareDistance > brain.AttackRadiusSquared)
            {
                return typeof(ChaseState);
            }

            return typeof(AimState);
        }

        override public void Exit()
        {
            base.Exit();
        }
    }
}