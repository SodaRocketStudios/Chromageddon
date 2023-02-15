using UnityEngine;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class ChaseState : AIState
    {
        public ChaseState(GameObject self, Transform target, float radius) : base(self, target, radius){}

        override public void Execute()
        {
            MoveTowardTarget(target.transform.position);
            LookAtTarget(target.transform.position);

            return;
        }

        override public void Exit()
        {
            base.Exit();
        }
    }
}