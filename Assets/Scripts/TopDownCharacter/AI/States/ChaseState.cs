using System;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class ChaseState : AIState
    {
        public ChaseState(GameObject self) : base(self) {}

        protected override Type Execute()
        {
            float squareDistance = VectorExtensions.SquareDistance(self.transform.position, brain.Target.position);

            if(squareDistance > brain.DetectionRadiusSquared)
            {
                return typeof(RoamState);
            }

            if(squareDistance < brain.AttackRadiusSquared)
            {
                return typeof(AttackState);
            }

            MoveTowardTarget(brain.Target.position);
            LookAtTarget(brain.Target.position);

            return typeof(ChaseState);
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}