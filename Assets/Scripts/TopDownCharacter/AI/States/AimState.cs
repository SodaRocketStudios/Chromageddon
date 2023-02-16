using System;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class AimState : AIState
    {
        public AimState(GameObject self) : base(self)
        {
        }

        override protected void Enter()
        {
            attackManager.IsAttacking = false;
        }

        override public Type Execute()
        {
            LookAtTarget(brain.Target.position);

            float squareDistance = VectorExtensions.SquareDistance(self.transform.position, brain.Target.position);

            if(squareDistance < brain.FleeRadius)
            {
                return typeof(FleeState);
            }

            if(squareDistance > brain.AttackRadius)
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