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
		private Vector2 randomTarget;

		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

		public override void Initiailize(TopDownCharacterController controller, Transform target)
		{
			base.Initiailize(controller, target);
			maxDeviationSquared = Mathf.Pow(maxDeviationFromTarget, 2);
		}

        // protected override Type TickState(Vector2 position)
        // {
		// 	if(VectorExtensions.SquareDistance(position, target.position) < squaredRange)
		// 	{
		// 		return nextState.GetType();
		// 	}

		// 	if(VectorExtensions.SquareDistance(position, randomTarget) <= maxDeviationSquared)
		// 	{
		// 		FindRandomTarget();
		// 	}

		// 	MoveTowardTarget(position);
		// 	LookAtTarget();

        //     return this.GetType();
        // }

		private void FindRandomTarget()
		{
			randomTarget = new Vector2(random.NextFloat(), random.NextFloat());
		}
    }
}