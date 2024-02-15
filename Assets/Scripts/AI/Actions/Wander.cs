using System;
using UnityEngine;
using SRS.Extensions.Random;

namespace SRS.AI
{
	[CreateAssetMenu(fileName = "New Wander Action", menuName = "Enemies/AI/Actions/Wander Action")]
    public class Wander : Action
    {
		[SerializeField] private float wanderRange;

		[SerializeField] private float tolerance;

	 	private System.Random random = new(Guid.NewGuid().GetHashCode());

		public override void Execute(AIBrain brain)
        {
			if(brain.TargetDistanceSquared <= tolerance || brain.Target == Vector2.zero)
			{
				brain.Target = random.WithinUnitCircle()*wanderRange;
			}
			
            brain.MoveInput = brain.Target - (Vector2)brain.transform.position;
        }
    }
}