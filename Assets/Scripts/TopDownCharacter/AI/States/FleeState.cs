using System;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class FleeState : AIState
    {
        private float maxFleeDistance = 1;

        public FleeState(GameObject self) : base(self)
        {
        }

        override protected void Enter()
        {
        }

        override public Type Execute()
        {
            float squareDistance = VectorExtensions.SquareDistance(self.transform.position, brain.Target.position);

            if(squareDistance > brain.FleeRadius)
            {
                return typeof(AttackState);
            }

            Vector2 fleePosition = self.transform.position + (self.transform.position - brain.Target.position).normalized*maxFleeDistance;

            MoveTowardTarget(fleePosition);
            LookAtTarget(fleePosition);

            return typeof(FleeState);
        }

        override public void Exit()
        {
            base.Exit();
        }
    }
}