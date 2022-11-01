using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class ChaseState : AIState
    {
        public ChaseState(GameObject self, GameObject target) : base(self, target)
        {
        }

        override protected void Enter()
        {
        }

        override public void Execute()
        {
            MoveTowardTarget(target.transform.position);
            LookAtTarget(target.transform.position);
        }

        override public AIState OnZoneChanged(GameObject target)
        {
            if(Vector2.Distance(target.transform.position, self.transform.position) > brain.detectionRadius)
            {
                Debug.Log("Roam");
                return new RoamState(self, target);
            }

            Debug.Log("Aim");
            return new AimState(self, target);
        }
    }
}