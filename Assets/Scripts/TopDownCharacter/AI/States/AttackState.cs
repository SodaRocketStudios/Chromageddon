using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AttackState : AIState
    {
        public AttackState(GameObject self, GameObject target) : base(self, target)
        {
        }

        override protected void Enter()
        {
        }

        override public void Execute()
        {
        }

        override protected void Exit()
        {
        }

        override public AIState OnZoneChanged(GameObject target)
        {
            return this;
        }
    }
}