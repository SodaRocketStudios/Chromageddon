using UnityEngine;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Look at Player Action", menuName = "Enemies/AI/Actions/Look at Player Action")]
    public class LookAtPlayerAction : Action
    {
        public override void Execute(AIBrain brain)
        {
            brain.LookInput = (Vector2)(brain.Player.transform.position - brain.transform.position);
        }
    }
}