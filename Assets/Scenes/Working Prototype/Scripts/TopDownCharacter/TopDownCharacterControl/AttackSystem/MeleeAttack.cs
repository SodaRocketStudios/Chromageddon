using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterController.AttackSystem
{
	public class MeleeAttack : AttackType
	{
		public float Range{get; set;}
		
		public MeleeAttack(Dictionary<string, Stat> stats)
		{
			UpdateStats(stats);
		}

        public override void Attack(Transform origin, LayerMask mask)
        {
			// Need to find all enemies within an attack zone.
            RaycastHit2D[] hits = Physics2D.CircleCastAll(origin.position, Range, origin.forward, 0, mask);

            foreach(RaycastHit2D hit in hits)
            {
                float hitAngle = Vector2.Angle(origin.right, hit.transform.position - origin.position);
                
                if(hitAngle <= attackStats["AttackArc"].Value/2)
                {
                    // TO DO -- Implement damage
                }
            }
        }
	}
}