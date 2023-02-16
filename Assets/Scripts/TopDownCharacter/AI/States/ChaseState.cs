using System;
using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class ChaseState : AIState
    {
        public ChaseState(GameObject self) : base(self){}

        override public Type Execute()
        {
            MoveTowardTarget(brain.Target.position);
            LookAtTarget(brain.Target.position);

            float squareDistance = VectorExtensions.SquareDistance(self.transform.position, brain.Target.position);

            if(squareDistance < brain.AttackRadius)
            {
                return typeof(AttackState);
            }
            return typeof(ChaseState);
        }

        override public void Exit()
        {
            base.Exit();
        }
    }
}