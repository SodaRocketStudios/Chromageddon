using UnityEngine;

namespace SRS.AI
{
    [CreateAssetMenu(fileName = "New Lookl At Target Action", menuName = "Enemies/AI/Actions/Look At Target Action")]
    public class LookAtTargetAction : Action
    {
        public override void Execute(AIBrain brain)
        {
            brain.LookInput = (Vector2)(brain.Target - (Vector2)brain.transform.position);
        }
    }
}