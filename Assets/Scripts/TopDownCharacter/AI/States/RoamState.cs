using UnityEngine;
using System;

namespace SRS.TopDownCharacterControl.AI
{
	public class RoamState : AIState
	{
        private const float MAX_DISTANCE = 5;
        private const float MAX_DEVIATION = .1f;
        private System.Random random = new System.Random();

        private Vector2 startPosition;

        public override void Enter(Transform transform)
        {
            base.Enter(transform);
            startPosition = transform.position;
            Target = GetRandomLocation();
        }

        public override void Execute()
        {
            // Need to detect with some margin of error
            float distance = ((Vector2)transform.position - Target).magnitude;
            if(distance <= MAX_DEVIATION)
            {
                Target = GetRandomLocation();
                Debug.Log(Target);
            }
        }

        private Vector2 GetRandomLocation()
        {
            return startPosition + new Vector2(random.Next(-10, 10), random.Next(-10, 10))*MAX_DISTANCE/10;
        }
	}
}