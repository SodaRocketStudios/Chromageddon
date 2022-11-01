using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class FleeState : AIState
    {
        public FleeState(GameObject self, GameObject target) : base(self, target)
        {
        }

        override protected void Enter()
        {
        }

        override public void Execute()
        {
        }

        override public AIState OnZoneChanged(GameObject target)
        {
            return this;
        }
    }
}