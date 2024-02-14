using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Wander Action", menuName = "Enemies/AI/Actions/Wander Action")]
    public class Wander : Action
    {
        public override void Execute(AIBrain brain)
        {
            brain.MoveInput = brain.Player.position - brain.transform.position;
        }
    }
}