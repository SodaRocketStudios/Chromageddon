using UnityEngine;
using System.Collections.Generic;
using SRS.Stats;

namespace SRS.TopDownCharacterControl.AttackSystem
{
    [CreateAssetMenu(fileName = "Basic Melee Attack", menuName = "Attacks/Basic Melee Attack")]
	public class BasicMeleeAttack : AttackType
	{
        public override void Attack(Transform origin, float attackAngle, LayerMask mask)
        {
            float range = attackStats["Speed"].Value * attackStats["Lifetime"].Value;

			// Need to find all enemies within an attack zone.
            RaycastHit2D[] hits = Physics2D.CircleCastAll(origin.position, range, origin.forward, 0, mask);

            foreach(RaycastHit2D hit in hits)
            {
                float hitAngle = Vector2.Angle(origin.right, hit.transform.position - origin.position);
                
                if(hitAngle <= attackAngle/2)
                {
                    // TO DO -- perform all on hit logic. This is where an IDamageable interface could be useful.
                }
            }
        }
	}
}