using UnityEngine;
using System;

namespace SRS.TopDownCharacterControl.AI
{
    public class RoamState : AIState
    {
		private Vector2 startPosition;

		private System.Random random = new System.Random();

        public override void Enter()
        {

        }

        public override void Execute()
        {
			
        }

		private Vector2 pickRandomPosition()
		{
			return startPosition + new Vector2(random.Next(), random.Next());
		}
    }
}