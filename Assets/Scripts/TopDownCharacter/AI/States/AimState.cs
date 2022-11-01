using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AimState : AIState
    {
        public AimState(GameObject self, GameObject target) : base(self, target)
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