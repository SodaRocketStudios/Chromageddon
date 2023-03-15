using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    [CreateAssetMenu(fileName = "New Stationary Attack State", menuName = "AI/State/Stationary Attack State")]
    public class StationaryAttackState : State
    {
        public override void Enter(AIBrain brain)
        {
			brain.StopMoving();
			brain.AttackManager.IsAttacking = true;
        }

        public override void Execute(AIBrain brain)
        {
			Debug.Log("Attacking");
        }

        public override void Exit(AIBrain brain)
        {
			brain.AttackManager.IsAttacking = false;
        }
    }
}