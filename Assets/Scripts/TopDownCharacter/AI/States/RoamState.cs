using System;
using UnityEngine;
using SRS.Extensions.Random;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    public class RoamState : State
    {
		[SerializeField] private float maxDeviationFromTarget;
		private float maxDeviationSquared;
		private Vector2 target;

		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

        public override void Enter(AIBrain brain)
        {
            FindRandomTarget();
        }

        public override void Execute(AIBrain brain)
        {
            if(VectorExtensions.SquareDistance(brain.transform.position, target) < maxDeviationSquared)
			{
				FindRandomTarget();
			}

			brain.MoveToward(target);
        }

        public override void Exit(AIBrain brain)
        {
            throw new NotImplementedException();
        }

        private void FindRandomTarget()
		{
			target = new Vector2(random.NextFloat(), random.NextFloat());
		}
    }
}