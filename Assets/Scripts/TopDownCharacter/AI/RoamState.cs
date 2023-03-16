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

        [SerializeField]private LayerMask environmentLayer;

		private Vector2 target;
		private System.Random random = new System.Random(Guid.NewGuid().GetHashCode());

        private void Start()
        {
            Debug.Log("Running");
            // environmentLayer = LayerMask.NameToLayer("Environment");
        }

        public override void Enter(AIBrain brain)
        {
            FindRandomTarget(brain.transform.position);
        }

        public override void Execute(AIBrain brain)
        {
            if(VectorExtensions.SquareDistance(brain.transform.position, target) <= maxDeviationSquared)
			{
				FindRandomTarget(brain.transform.position);
			}

			brain.MoveToward(target);
            brain.LookAt(target);
        }

        public override void Exit(AIBrain brain)
        {
            brain.StopMoving();
        }

        private void FindRandomTarget(Vector2 position)
		{
            Vector2 direction = (new Vector2(random.NextFloat(), random.NextFloat()) - Vector2.one*0.5f) * 2;
            
            target = position + direction * 10;

            RaycastHit2D hit = Physics2D.Raycast(position, direction, Vector2.Distance(position, target), environmentLayer);

            if(hit)
            {
                target = hit.point + hit.normal*hit.distance*(1-hit.fraction);
            }
		}
    }
}