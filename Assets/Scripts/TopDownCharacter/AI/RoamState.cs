using System;
using UnityEngine;
using SRS.Extensions.Random;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
    [CreateAssetMenu(fileName = "New Roam State", menuName = "AI/State/Roam State")]
    public class RoamState : State
    {
		[SerializeField] private float maxDeviationFromTarget;
		private float maxDeviationSquared => Mathf.Pow(maxDeviationFromTarget, 2);

		private Vector2 target;
		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

        public override void Enter(AIBrain brain)
        {
            target = FindRandomTarget()*10 + (Vector2)brain.transform.position;
        }

        public override void Execute(AIBrain brain)
        {
            if(VectorExtensions.SquareDistance(brain.transform.position, target) <= maxDeviationSquared)
			{
				target = FindRandomTarget()*10 + (Vector2)brain.transform.position;
			}

			brain.MoveToward(target);
            brain.LookAt(target);
        }

        public override void Exit(AIBrain brain)
        {
        }

        private Vector2 FindRandomTarget()
		{
            // TODO -- limit to points within the play area.
			return (new Vector2(random.NextFloat(), random.NextFloat()) - Vector2.one*0.5f) * 2;
		}
    }
}