using UnityEngine;
using System;
using SRS.Extensions;

namespace SRS.TopDownCharacterControl.AI
{
	public class RoamState : AIState
	{
        private const float MAX_DISTANCE = 5;
        private const float MAX_DEVIATION = .1f;
        private const float MAX_TIME_FOR_TARGET = 5;

        private System.Random random = new System.Random();

        private Vector2 startPosition;
        private Vector2 moveTarget;
        private float newTargetTime = 0;

        public override void Enter()
        {
            startPosition = self.transform.position;
            moveTarget = startPosition;
        }

        public override void Execute()
        {
            if(Vector2.Distance(self.transform.position, moveTarget) < MAX_DEVIATION || Time.time >= newTargetTime)
            {
                moveTarget = GetRandomLocation();
                newTargetTime = Time.time + MAX_TIME_FOR_TARGET;
            }
        }

        public override AIState OnZoneChanged(GameObject target)
        {
            AIState newState = new ChaseState();
            newState.Initialize(self, target);
            return new ChaseState();
        }

        private Vector2 GetRandomLocation()
        {
            return startPosition + new Vector2(random.NextFloat(), random.NextFloat())*MAX_DISTANCE;
        }
	}
}