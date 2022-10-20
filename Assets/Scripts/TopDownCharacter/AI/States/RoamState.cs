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

        public override void Enter(AIBrain brain)
        {
            base.Enter(brain);
            startPosition = brain.transform.position;
            target = GetRandomLocation();
        }

        public override void Execute()
        {
            float distance = ((Vector2)brain.transform.position - target).magnitude;
            if(distance <= MAX_DEVIATION)
            {
                target = GetRandomLocation();
                Debug.Log(target);
            }

            base.Execute();
        }

        private Vector2 GetRandomLocation()
        {
            return startPosition + new Vector2(random.Next(-10, 10), random.Next(-10, 10))*MAX_DISTANCE/10;
        }
	}
}