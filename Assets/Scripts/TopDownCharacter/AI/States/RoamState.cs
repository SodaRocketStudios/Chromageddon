using System;
using UnityEngine;
using SRS.Extensions.Random;
using SRS.Extensions.Vector;

namespace SRS.TopDownCharacterControl.AI
{
	public class RoamState : AIState
	{
        private const float MAX_DISTANCE = 10;
        private const float MAX_DEVIATION = .1f;
        private const float MAX_TIME_FOR_TARGET = 5;

        private System.Random random = new System.Random();

        private Vector2 startPosition = new Vector2();
        private Vector2 moveTarget = new Vector2();
        private float newTargetTime = 0;

        public RoamState(GameObject self) : base(self) {}

        protected override void Enter()
        {
            startPosition = self.transform.position;
            moveTarget = GetRandomLocation();
        }

        protected override Type Execute()
        {

            if(VectorExtensions.SquareDistance(self.transform.position, brain.Target.position) < brain.DetectionRadiusSquared)
            {
                return typeof(ChaseState);
            }

            if(VectorExtensions.SquareDistance(self.transform.position, moveTarget) < MAX_DEVIATION*MAX_DEVIATION || Time.time >= newTargetTime)
            {
                moveTarget = GetRandomLocation();
                newTargetTime = Time.time + MAX_TIME_FOR_TARGET;
            }

            MoveTowardTarget(moveTarget);
            LookAtTarget(moveTarget);

            return typeof(RoamState);
        }

        public override void Exit()
        {
            base.Exit();
        }

        private Vector2 GetRandomLocation()
        {
            return startPosition + new Vector2(random.NextFloat(), random.NextFloat())*MAX_DISTANCE;
        }
	}
}