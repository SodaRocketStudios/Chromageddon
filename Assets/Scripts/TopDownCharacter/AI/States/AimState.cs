using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class AimState : AIState
    {
        public AimState(GameObject self, Transform target, float radius) : base(self, target, radius)
        {
        }

        override protected void Enter()
        {
            attackManager.IsAttacking = false;
        }

        override public void Execute()
        {
            LookAtTarget(target.transform.position);

            return;
        }

        override public void Exit()
        {
            base.Exit();
        }
    }
}