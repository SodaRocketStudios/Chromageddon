using UnityEngine;
using System;
using SRS.Extensions;

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

        public RoamState(GameObject self, GameObject target) : base(self, target) {}

        override protected void Enter()
        {
            startPosition = self.transform.position;
            moveTarget = GetRandomLocation();
        }

        override public void Execute()
        {
            if(Vector2.Distance(self.transform.position, moveTarget) < MAX_DEVIATION || Time.time >= newTargetTime)
            {
                moveTarget = GetRandomLocation();
                newTargetTime = Time.time + MAX_TIME_FOR_TARGET;
            }

            MoveTowardTarget(moveTarget);
            LookAtTarget(moveTarget);
        }

        override public void Exit()
        {
            base.Exit();
        }

        override public AIState OnZoneChanged(Collider2D other)
        {
            float distance = DistanceToOther(other);

            if(distance < brain.detectionRadius)
            {
                return new ChaseState(self, other.gameObject);
            }

            return this;
        }

        private Vector2 GetRandomLocation()
        {
            return startPosition + new Vector2(random.NextFloat(), random.NextFloat())*MAX_DISTANCE;
        }
	}
}