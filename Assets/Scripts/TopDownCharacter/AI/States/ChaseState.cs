using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class ChaseState : AIState
    {
        public ChaseState(GameObject self, GameObject target) : base(self, target){}

        override public void Execute()
        {
            MoveTowardTarget(target.transform.position);
            LookAtTarget(target.transform.position);
        }

        override public void Exit()
        {
            base.Exit();
        }

        override public AIState OnZoneChanged(Collider2D other)
        {
            float distance = DistanceToOther(other);

            if(distance > brain.detectionRadius)
            {
                return new RoamState(self, target);
            }

            return new AttackState(self, target);
        }
    }
}