using UnityEngine;
using System;

namespace SRS.TopDownCharacterControl.AI
{
	public class RoamState : AIState
	{
        private const float MAX_DEVIATION = 10;
        private System.Random random = new System.Random();

        private Vector2 startPosition;

		public override void Enter()
        {
            // get start position
        }

        public override void Execute()
        {
            Vector2 targetLocation = GetRandomLocation();
        }

        private Vector2 GetRandomLocation()
        {
            return startPosition + new Vector2(random.Next(), random.Next())*MAX_DEVIATION;
        }
	}
}