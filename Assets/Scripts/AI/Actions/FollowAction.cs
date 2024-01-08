using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Follow Action", menuName = "Enemies/AI/Actions/Follow Action")]
    public class FollowAction : Action
    {
        public override void Execute(AIBrain brain)
        {
            brain.MoveInput = brain.Player.position - brain.transform.position;
        }
    }
}