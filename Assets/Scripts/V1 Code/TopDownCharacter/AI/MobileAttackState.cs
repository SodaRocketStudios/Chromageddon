using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
	[CreateAssetMenu(fileName = "New Mobile Attack State", menuName = "AI/State/Mobile Attack State")]
	public class MobileAttackState : State
	{
		public override void Enter(AIBrain brain)
        {
			brain.IsAttacking = true;
        }

        public override void Execute(AIBrain brain)
        {
			brain.MoveToward(brain.Target.position);
			brain.LookAt(brain.Target.position);
        }

        public override void Exit(AIBrain brain)
        {
			brain.IsAttacking = false;
			brain.StopMoving();
        }
	}
}