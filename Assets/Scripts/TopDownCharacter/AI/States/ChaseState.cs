using UnityEngine;

namespace SRS.TopDownCharacterControl.AI
{
    public class ChaseState : AIState
    {

        public override void Enter(Transform transform)
        {
            Target = transform.position;
            this.transform = transform;
        }

        public override void Execute()
        {
            Target = transform.position;
        }
    }
}