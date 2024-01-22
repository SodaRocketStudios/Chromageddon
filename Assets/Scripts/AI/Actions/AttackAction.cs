using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Attack Action", menuName = "Enemies/AI/Actions/Attack Action")]
    public class AttackAction : Action
    {
        public override void Execute(AIBrain brain)
        {
            brain.AttackInput = true;
        }
    }
}